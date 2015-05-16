using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeoQuiz.Models;

namespace GeoQuiz.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet] 
        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
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


            
            return View(new CheckContinent());
        }

        [HttpPost]
        public string Show(FormCollection postedForm, CheckContinent model)
        {

            string val = "";

            foreach (var con in model.Continents)
            {

                if (postedForm[con].ToString().Contains("true"))
                {

                    val = val + " " + con;

                }

            }

            return "Selected continents are: <b>" + val + "</b>";
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}