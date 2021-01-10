using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using News.Models;

namespace News.Entities
{
    public class NewsContext : DbContext
    {
        public NewsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ANNA-PC\\SQLEXPRESS;Database=News;Trusted_Connection=True;");
        }

        public DbSet<NewsEntity> News { get; set; }
        public DbSet<NewsCategoryEntity> Categories { get; set; }     


    }
}