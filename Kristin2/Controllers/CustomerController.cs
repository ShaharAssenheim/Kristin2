using Kristin2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kristin2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomersList()
        {


            List<CustomerModel> Customers = new List<CustomerModel>();
            Customers.Add(new CustomerModel { FirstName = "Tim", LastName = "corey", LastTime = Convert.ToDateTime("1/1/2010 12:10:15 PM") });
            Customers.Add(new CustomerModel { FirstName = "shahar", LastName = "assen", LastTime = Convert.ToDateTime("4/1/2010 12:10:15 PM") });
            Customers.Add(new CustomerModel { FirstName = "kristin", LastName = "yagu", LastTime = Convert.ToDateTime("3/1/2010 12:10:15 PM") });

            return View(Customers);

        }


    }
}