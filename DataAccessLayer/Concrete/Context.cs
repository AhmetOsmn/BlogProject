﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BHGN45D\\AHMETSDBSERVER;database=(MY)CoreBlogDb; integrated security=true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs{ get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Writer> Writers{ get; set; }
        public DbSet<NewsLetter> NewsLetters{ get; set; }
    }
}
