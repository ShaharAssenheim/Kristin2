using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Kristin2.Models;
namespace Kristin2.Dal
{
    public class CustomerDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerModel>().ToTable("Customer_db");
        }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}