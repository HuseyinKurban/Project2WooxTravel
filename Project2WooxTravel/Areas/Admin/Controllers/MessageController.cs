using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
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
            var a = Session["x"];
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault();
            var values=context.Messages.Where(x=>x.ReceiverMail==email).ToList();
            return View(values);
        }

        public ActionResult SendBox()
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault();
            var values = context.Messages.Where(x => x.SenderMail == email).ToList();
            return View(values);
        }

        public ActionResult SendMessage()
        {
            
            var adminuser = Session["x"]?.ToString();
            var adminemail=context.Admins.Where(x => x.UserName == adminuser).Select(y => y.Email).FirstOrDefault();

            List<SelectListItem> degerler=(from x in context.Admins.ToList()
                                           where x.Email !=adminemail
                                           select new SelectListItem
                                           {
                                               Text=x.Email,
                                               Value=x.Email
                                           }).ToList();
            ViewBag.emaillistesi = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            var a = Session["x"];
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault();
            message.SenderMail = email;
            message.SendDate=DateTime.Now;
            message.IsRead=false;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("SendBox", "Message", new {area="Admin"});
        }

        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ChangeAllMessagesStatusToRead()
        {
            var a = Session["x"];
            var admin = context.Admins
                .Where(x => x.UserName == a)
                .Select(y => y.Email)
                .FirstOrDefault();


            var okunmamismesaj = context.Messages
                .Where(x => x.ReceiverMail == admin && x.IsRead == false)
                .ToList();

            foreach (var x in okunmamismesaj)
            {
                x.IsRead = true; 
            }

            context.SaveChanges(); 
            return RedirectToAction("Inbox"); 
        }

    }
}