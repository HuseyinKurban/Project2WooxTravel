using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class ChartController : Controller
    {
        // GET: Admin/Chart
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {

            ViewBag.ReservationsName = context.Reservations.OrderByDescending(x => x.ReservationId).Take(20).Select(x=>x.Name).ToList();
            ViewBag.ReservationPerson = context.Reservations.OrderByDescending(x => x.ReservationId).Take(20).Select(x => x.PersonCount).ToList();
            ViewBag.TurSayısıAdı = context.Destinations.Select(x => x.Title).ToList();
            ViewBag.TurKapasitesi = context.Destinations.Select(x => x.Capacity).ToList();
            ViewBag.TurFiyatı = context.Destinations.Select(x => x.Price).ToList();
            ViewBag.TopResName = context.Reservations.OrderByDescending(x => x.PersonCount).Select(x => x.Name).Take(10).ToList();
            ViewBag.TopResPerson = context.Reservations.OrderByDescending(x => x.PersonCount).Select(x => x.PersonCount).Take(10).ToList();


            return View();
        }
    }
}