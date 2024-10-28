using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: Admin/AdminLayout/
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.ReceiverMail == email && x.IsRead==false).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAdmin()
        {
            var a = Session["x"];
            var admin = context.Admins.Where(x => x.UserName == a).ToList();
            return PartialView(admin);
        }
        public PartialViewResult PartialBildirim()
        {
            var a=context.Destinations.OrderByDescending(x=>x.DestinationId).Take(4).ToList();
            return PartialView(a);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialCustom()
        {
            return PartialView();
        }
    }
}