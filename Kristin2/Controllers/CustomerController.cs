using Kristin2.Context;
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
        CustomerConext db = new CustomerConext();
        // GET: Customer
        public ActionResult CustomersList()
        {

            return View(db.Customers.ToList());

        }


    }
}