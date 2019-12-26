using Kristin2.Context;
using Kristin2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kristin2.Controllers
{
    public class CalanderController : Controller
    {
        MyContext Products = new MyContext();
        MyContext db = new MyContext();
        // GET: Home
        public ActionResult Calander()
        {



            var tuple = new Tuple<List<CustomerModel>, List<ProductModel>>(db.Customers.ToList(), Products.ProductDb.ToList());
            return View(tuple);
        }

        public JsonResult GetEvents()
        {
            using (MyContext dc = new MyContext())
            {
                var events = dc.Eventsdb.ToList();
                foreach (var e in events)
                {
                    string st = e.StartTime.ToString("dd MMM yyyy hh:mm");
                    e.StartTime = Convert.ToDateTime(st);
                    string et = e.EndTime.ToString("dd MMM yyyy hh:mm");
                    e.EndTime = Convert.ToDateTime(et);

                }
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(CalanderModel e)
        {
            var status = false;
            using (MyContext dc = new MyContext())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Eventsdb.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.StartTime = e.StartTime;
                        v.EndTime = e.EndTime;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Eventsdb.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status } };
        }




        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (MyContext dc = new MyContext())
            {
                var v = dc.Eventsdb.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Eventsdb.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status } };
        }
    }
}