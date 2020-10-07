using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMVC.Models;

namespace BlogMVC.Controllers
{
    public class ProductController : Controller
    {
        private BlogContext db = new BlogContext();


        public ActionResult List(int? id, string q)
        {
            var urunler = db.Products
              .Where(i => i.Onay == true)
              .Select(i => new UrunModel()
              {
                  Id = i.Id,
                  Baslik = i.Baslik.Length > 20 ? i.Baslik.Substring(0, 20) + "..." : i.Baslik,
                  Aciklama = i.Aciklama,
                  EklenmeTarihi = i.EklenmeTarihi,
                  Anasayfa = i.Anasayfa,
                  Onay = i.Onay,
                  Resim = i.Resim,
                  CategoryId = i.CategoryId
              }).AsQueryable();


             


            if (id != null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }


         
            if (string.IsNullOrEmpty("q") == false)
            {
                urunler = urunler.Where(i => i.Baslik.Contains(q) || i.Aciklama.Contains(q));
            }








            return View(urunler.ToList());
        }

        //-----------------------------------------------------------------
        public ActionResult Arama(string q)
        {
            var urunler = db.Products
              .Where(i => i.Onay == true)
              .Select(i => new UrunModel()
              {
                  Id = i.Id,
                  Baslik = i.Baslik.Length > 20 ? i.Baslik.Substring(0, 20) + "..." : i.Baslik,
                  Aciklama = i.Aciklama,
                  EklenmeTarihi = i.EklenmeTarihi,
                  Anasayfa = i.Anasayfa,
                  Onay = i.Onay,
                  Resim = i.Resim,
                  CategoryId = i.CategoryId
              }).AsQueryable();


            if (string.IsNullOrEmpty("q") == false)
            {
                urunler = urunler.Where(i => i.Baslik.Contains(q) || i.Aciklama.Contains(q));
            }

            return View(urunler.ToList());
        }




        //-----------------------------------------------------------------------------

        // GET: Product
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).OrderByDescending(i => i.EklenmeTarihi);
           
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "KategoryAdi");
            return View();
        }

        // POST: Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Baslik,Aciklama,Resim,Icerik,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.EklenmeTarihi = DateTime.Now;

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "KategoryAdi", product.CategoryId);
            return View(product);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "KategoryAdi", product.CategoryId);
            return View(product);
        }

        // POST: Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Onay,Anasayfa,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {

                var urun = db.Products.Find(product.Id);
                if (urun != null)
                {
                    urun.Baslik = product.Baslik;
                    urun.Aciklama = product.Aciklama;
                    urun.Resim = product.Resim;
                    urun.Icerik = product.Icerik;
                    urun.Onay = product.Onay;
                    urun.Anasayfa = product.Anasayfa;
                    urun.CategoryId = product.CategoryId;
                    db.SaveChanges();
                    TempData["Urun"] = urun;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "KategoryAdi", product.CategoryId);
            return View(product);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
