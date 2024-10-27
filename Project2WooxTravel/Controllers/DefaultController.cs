using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;
using PagedList;
using PagedList.Mvc;
using Newtonsoft.Json.Linq;

namespace Project2WooxTravel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        TravelContext context = new TravelContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var hakkımızda =  context.Destinations.OrderByDescending(x => x.DestinationId).Take(10).ToList();
            ViewBag.ToplamTurKapasitesi = context.Destinations.Sum(x => x.Capacity);
            ViewBag.ToplamTur = context.Destinations.Count();
            ViewBag.GuncelTur = context.Destinations.OrderByDescending(x => x.DestinationId).Select(c => c.Title).FirstOrDefault();
            ViewBag.ToplamGun = context.Destinations.OrderByDescending(x => x.DestinationId).Select(c => c.DayNight).FirstOrDefault();
            return View(hakkımızda);
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialBanner()
        {
            var values = context.Destinations.OrderByDescending(x => x.DestinationId).Take(4).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCountry(int p = 1)
        {
            var values = context.Destinations.ToList().ToPagedList(p, 3);
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public ActionResult TurBilgileri(int id)
        {
            var turdetay = context.Destinations.Where(x => x.DestinationId == id).ToList();
            return View(turdetay);
        }

        [HttpGet]
        public ActionResult Rezervasyon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Rezervasyon(Reservation rezerv)
        {
            context.Reservations.Add(rezerv);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}