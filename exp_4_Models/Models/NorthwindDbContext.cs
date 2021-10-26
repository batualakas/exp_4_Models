﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext()
        {
            this.Database.Connection.ConnectionString = "Server=.;Database=Northwind;User Id=sa;Password=123;";
        }
        public DbSet<Category> Categories { get; set; }



    }
    
}
// migration gerektiği durumda
//enable-migrations
// add-migration MigrationAdi
//update database