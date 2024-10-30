using Project2WooxTravel.Context;
using Project2WooxTravel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2WooxTravel.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Admin/Reservation
        TravelContext context = new TravelContext();
        public ActionResult ReservationList(string p)
        {
            var degerler = context.Reservations.ToList();
            var ad = context.Reservations.Where(x => x.Name == p).ToList();
            if (!string.IsNullOrEmpty(p))
            {
                return View(ad);
            }
            else {

                return View(degerler);
            }
        }
        public ActionResult DeleteReservation(int id)
        {
            var value = context.Reservations.Find(id);
            context.Reservations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }

        public ActionResult ReservationStatusTrue(int id)
        {
            var value = context.Reservations.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }

        public ActionResult ReservationStatusFalse(int id)
        {
            var value = context.Reservations.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateReservation(Reservation reservasyon)
        {
            var value = context.Reservations.Find(reservasyon.ReservationId);
            value.Name = reservasyon.Name;
            value.Phone = reservasyon.Phone;
            value.PersonCount = reservasyon.PersonCount;
            value.ReservationDate = reservasyon.ReservationDate;
            value.Description = reservasyon.Description;
            value.Status = reservasyon.Status;
            context.SaveChanges();
            return RedirectToAction("ReservationList", "Reservation", "Admin");
        }
    }
}