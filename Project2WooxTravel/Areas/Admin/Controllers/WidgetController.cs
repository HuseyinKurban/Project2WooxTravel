using Project2WooxTravel.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class WidgetController : Controller
    {
        // GET: Admin/Widget
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            ViewBag.AdminSayısı = context.Admins.Count();
            ViewBag.KategoriSayısı = context.Categories.Count();
            ViewBag.TurSayısı=context.Destinations.Count();
            ViewBag.SehirSayisi = context.Destinations.Select(x => x.City).Distinct().Count();

            ViewBag.GuncelTur = context.Destinations.OrderByDescending(x => x.DestinationId).Select(c => c.Title).FirstOrDefault();
            ViewBag.GuncelTurGun = context.Destinations.OrderByDescending(x => x.DestinationId).Select(c => c.DayNight).FirstOrDefault();
            ViewBag.GuncelTurFiyat=context.Destinations.OrderByDescending(x => x.DestinationId).Select(c => c.Price).FirstOrDefault();
            ViewBag.GuncelKapasite = context.Destinations.OrderByDescending(x => x.DestinationId).Select(c => c.Capacity).FirstOrDefault();

            ViewBag.ToplamRezervasyon = context.Reservations.Count();
            ViewBag.OnaylıRezervasyonSayısı = context.Reservations.Count(x => x.Status == true);
            ViewBag.OnayBekleyenRezervasyonSayısı = context.Reservations.Count(x => x.Status == false);
            ViewBag.EnYuksekRezervasyon = context.Reservations.Max(x => x.PersonCount);
            return View();
        }
    }
}