using Kutse_App_RolanMaslennikov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_App_RolanMaslennikov.Controllers
{
    public class HomeController : Controller
    {
        Guest guest;
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind minu peole! Palun tule!!!";
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 10 ? "Tere hommikust!" : "Tere päevast!";
            return View();
        }

        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if (ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            else { return View(); }
        }

        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeeriminemvc@gmail.com";
                WebMail.Password = "************";
                WebMail.From = "programmeeriminemvc@gmail.com";
                WebMail.Send("marina.oleinik@gmail.ee", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ?
                    "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!!!";
            }
        }

        GuestContext db = new GuestContext();

        public ActionResult Guests()
        {
            IEnumerable<Guest> guests = db.Guests;
            return View(guests);
        }

        /*public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }*/
    }
}