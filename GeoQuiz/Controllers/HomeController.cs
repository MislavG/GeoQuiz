using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeoQuiz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Play()
        {
            Random rand = new Random();
            List<string> drzave = new List<string>();
            drzave.Add("Croatia");
            drzave.Add("Serbia & Montenegro");
            drzave.Add("Bosnia & Herzegovina");
            drzave.Add("Germany");
            drzave.Add("Switzerland");
            int r = rand.Next(drzave.Count);

            ViewBag.ListDrzave = drzave;
            ViewBag.Random = ((string)drzave[r]); //OVO JE DRZAVA KOJA SE SALJE U Play.cshtml U 20. LINIJU KODA
            ViewBag.Message = "Test lista";
            Console.WriteLine(ViewBag.Random);


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}