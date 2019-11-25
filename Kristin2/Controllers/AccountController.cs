using Kristin2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kristin2.Dal;

namespace Kristin2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {


            return View();
        }

        public ActionResult Register()
        {

            return View();
        }

        public ActionResult SubmitRegister(CustomerModel c)
        {
            if (!c.AdminCode.Equals(1992))
                c.AdminCode = 0;
            c.ID = 1;


            CustomerDal dal = new CustomerDal();
            dal.Customers.Add(c);
            dal.SaveChanges();
            return View("Index", c);

        }
    }
}