using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class BlogContext:DbContext
    {

        public BlogContext():base("BlogDb")
        {
            Database.SetInitializer(new BlogInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}