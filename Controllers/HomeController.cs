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
            int month = DateTime.Now.Month;

            string[] peod = new string[12] { "Uus aasta", "Isamaa kaitsja päev", "Naistepäev", "Aprillinali", "Võidupüha", "esimene suvepäev", "Ülemaailmne UFO päev", "Arbuusipäev", "Esimene september", "Arstide päev", "November", "Jõulud"};
            
            //string pidu = "";
            //if(DateTime.Now.Month==1)
            //{
                //pidu = "Jaanuari pidu";
            //}
            ViewBag.Message = "Ootan sind oma peole! " + peod[month-1] + " Palun tule kindlasti!";

            //ViewBag.Message = "Ootan sind oma peole";
            int hour = DateTime.Now.Hour;

            ViewBag.greeting = hour < 12 && hour > 4 ? "Tere Hommikust!" : "Tere päevast";
            ViewBag.greeting = hour < 16 && hour > 12 ? "Tere Paevast!" : "Tere Õhtust";
            ViewBag.greeting = hour > 16 && hour < 20 ? "Tere Õhtust!" : "Tere Ööd";
            ViewBag.greeting = hour > 20 && hour < 4 ? "Tere Ööd!" : "Tere Hommikust";
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
                WebMail.Password = "2.kuursus tarpv20";
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