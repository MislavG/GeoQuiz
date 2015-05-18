using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeoQuiz.Models;
using System.Web.UI;
using System.Web.Services;

namespace GeoQuiz.Controllers
{
    
    public class HomeController : Controller
    {
        private GeoQuizEntities db = new GeoQuizEntities();
        Random rand = new Random();
        List<string> drzave = new List<string>();
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

            /*ViewBag.ListDrzave = drzave;
            ViewBag.Random = ((string)drzave[r]); //OVO JE DRZAVA KOJA SE SALJE U Play.cshtml U 20. LINIJU KODA
            ViewBag.Message = "Test lista";
            Console.WriteLine(ViewBag.Random); 
            var ids = from drzava in db.Drzava
                      select drzava.NazivDrzavaEng;
            List<string> drzave = new List<string>();
            Random rand = new Random();*/
            /*foreach (var item in ids)
            {
                drzave.Add(item.Trim());

            }
            int r = rand.Next(drzave.Count);*/
            ViewBag.Drz = ((string)drzave[r]);

            

            return View(new CheckContinent());
        }

        [ChildActionOnly]
        public ActionResult RandomDrzava()
        {
            /*var ids = from drzava in db.Drzava
                      select drzava.NazivDrzavaEng;*/
            List<string> drzave = new List<string>();
            Random rand = new Random();
            /*foreach (var item in ids)
            {
                drzave.Add(item);

            }*/
            int r = rand.Next(drzave.Count);
            string odabrana = ((string)drzave[r]);
            drzave.Remove(odabrana);
            ViewBag.Drz = odabrana;
            return View();
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

        public ActionResult Instructions()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [WebMethod]
        public string RandomDrzava2()
        {
            List<string> drzave = new List<string>();
            drzave.Add("Croatia");
            drzave.Add("Serbia & Montenegro");
            drzave.Add("Bosnia & Herzegovina");
            drzave.Add("Germany");
            drzave.Add("Switzerland");
            //Random rand = new Random();
            int r = rand.Next(drzave.Count);
            string odabrana = ((string)drzave[r]);
           /* ScriptManager.RegisterStartupScript(this,
                                                        this.GetType(),
                                                        "Funct",
                                                        "drz = " + odabrana + ";",
                                                        true);*/

            //return Content(odabrana, "text/html");
            //return Json(odabrana, JsonRequestBehavior.AllowGet);
            ViewBag.Drz = odabrana;
            return odabrana;
        }
    }
}