﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;

namespace Jespar.DatabaseContext.DatabaseContext
{
    public class JesparDbContext:DbContext
    {
        public DbSet<Supplier> Suppliers { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Purchase> Purchases { set; get; }
    }
}
