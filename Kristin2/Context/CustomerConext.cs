using Kristin2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Kristin2.Context
{
    public class CustomerConext : DbContext
    {
        public CustomerConext() : base("name =DefaultConnection")
        {

        }
        public DbSet<CustomerModel> Customers { get; set; }
    }
}