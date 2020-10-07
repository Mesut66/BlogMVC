using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {

            List<Category> kategoriler = new List<Category>()
            {
                new Category(){ KategoryAdi="C#"},
                new Category(){ KategoryAdi="C# Console "},
                new Category(){ KategoryAdi="C# WinForm"},
                new Category(){ KategoryAdi="C# Asp.Net MVC"},

            };

            foreach (var item in kategoriler)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();

            List<Product> products = new List<Product>()
            {
                new Product(){ Baslik="C# Hakkında incelemelerde ve araştırmalarda bulunulacak", Aciklama="C# Dili Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10),
                    Anasayfa =true,Onay=true,Icerik="C# Dili Hakkında Bilgiler",Resim="1.jpeg", CategoryId=1},
                new Product(){ Baslik="C# Hakkında", Aciklama="C# Dili Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10),
                    Anasayfa =true,Onay=true,Icerik="C# Dili Hakkında Bilgiler",Resim="1.jpeg", CategoryId=1},
                new Product(){ Baslik="C# Hakkında incelemelerde ve araştırmalarda bulunulac", Aciklama="C# Dili Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-30),
                    Anasayfa =false,Onay=true,Icerik="C# Dili Hakkında Bilgiler",Resim="1.jpeg", CategoryId=1},

                new Product(){ Baslik="C# Console", Aciklama="C# Console Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-20),
                    Anasayfa =true,Onay=false,Icerik="C# Console Hakkında Bilgiler",Resim="2.jpeg", CategoryId=2},
                new Product(){ Baslik="C# Console Hakkında incelemelerde ve araştırmalarda bulunulac", Aciklama="C# Console Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-5),
                    Anasayfa =false,Onay=true,Icerik="C# Console Hakkında Bilgiler",Resim="2.jpeg", CategoryId=2},
                new Product(){ Baslik="C# Console", Aciklama="C# Console Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10),
                    Anasayfa =true,Onay=false,Icerik="C# Console Hakkında Bilgiler",Resim="2.jpeg", CategoryId=2},

                new Product(){ Baslik="C# WinForm", Aciklama="C# WinForm Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-3),
                    Anasayfa =true,Onay=true,Icerik="C# WinForm Hakkında Bilgiler",Resim="3.jpeg", CategoryId=3},
                new Product(){ Baslik="C# WinForm", Aciklama="C# WinForm Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-1),
                    Anasayfa =false,Onay=true,Icerik="C# WinForm Hakkında Bilgiler",Resim="3.jpeg", CategoryId=3},
                new Product(){ Baslik="C# WinForm", Aciklama="C# WinForm Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-9),
                    Anasayfa =true,Onay=false,Icerik="C# WinForm Hakkında Bilgiler",Resim="3.jpeg", CategoryId=3},

                new Product(){ Baslik="C# Asp.Net MVC", Aciklama="C# Asp.Net MVC Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10),
                    Anasayfa =true,Onay=true,Icerik="C# Asp.Net MVC Hakkında Bilgiler",Resim="4.jpeg", CategoryId=4},
                new Product(){ Baslik="C# Asp.Net MVC", Aciklama="C# Asp.Net MVC Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-8),
                    Anasayfa =false,Onay=false,Icerik="C# Asp.Net MVC Hakkında Bilgiler",Resim="4.jpeg", CategoryId=4},
                new Product(){ Baslik="C# Asp.Net MVC", Aciklama="C# Asp.Net MVC Hakkında", EklenmeTarihi=DateTime.Now.AddDays(-10),
                    Anasayfa =true,Onay=true,Icerik="C# Asp.Net MVC Hakkında Bilgiler",Resim="4.jpeg", CategoryId=4},
            };

            foreach (var item in products)
            {
                context.Products.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}