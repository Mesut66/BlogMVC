using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string KategoryAdi { get; set; }
        

        public List<Product> Urunler { get; set; }
    }
}