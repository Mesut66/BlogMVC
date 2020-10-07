using BlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();

        // GET: Home
        public ActionResult Index()
        {

            var urunler = context.Products
                 .Where(i => i.Onay == true && i.Anasayfa == true)
                .Select(i => new UrunModel()
                 {
                     Id = i.Id,
                     Baslik = i.Baslik.Length > 20 ? i.Baslik.Substring(0, 20) + "..." : i.Baslik,
                     Aciklama = i.Aciklama,
                     EklenmeTarihi = i.EklenmeTarihi,
                     Anasayfa = i.Anasayfa,
                     Onay = i.Onay,
                     Resim = i.Resim
                 });
             

            
            return View(urunler.ToList());
        }
    }
}