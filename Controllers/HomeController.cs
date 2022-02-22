using Kutse_TSYBIREV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Kutse_TSYBIREV.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind oma peole";
            int hour = DateTime.Now.Hour;
            ViewBag.greeting = hour < 12 ? "Tere Hommikust!" : "Tere päevast";
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
            if (ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }

        public void Email(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "programmeeriminemvc@gmail.com";
                WebMail.Password = "************";
                WebMail.From = "programmeeriminemvc@gmail.com";
                WebMail.Send("maks61ts@gmail.com", "Vastus kutsele", guest.Name + "vastas" + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud";
            }
            catch (Exception)
            {

                ViewBag.Message = "Mul on khju ! Ei saa kirja saada!!!";
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}