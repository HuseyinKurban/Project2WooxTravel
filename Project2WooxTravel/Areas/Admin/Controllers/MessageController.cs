using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        // GET: Admin/Message
        TravelContext context = new TravelContext();

        public ActionResult Inbox()
        {
            return View();
        }
    }
}