using Kristin2.Context;
using Kristin2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Kristin2.Controllers
{
    public class CustomerController : Controller
    {
        MyContext db = new MyContext();
        // GET: Customer
        public ActionResult CustomersList()
        {

            return View(db.Customers.ToList());

        }


        public ActionResult Delete(int id)
        {

            CustomerModel customer = db.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("CustomersList", "Customer");

        }

        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            customer.CreatedDate = DateTime.Now;
            customer.LastLoginDate = DateTime.Now;
            if (customer.AdminCode != 222)
                customer.AdminCode = 0;

            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("CustomersList", "Customer");
        }

        [HttpPost]
        public ActionResult Find(string searchString)
        {
            var c = from m in db.Customers
                    select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                c = c.Where(s => s.FirstName.Contains(searchString));
            }

            return View(c.ToList());
        }




    }
}