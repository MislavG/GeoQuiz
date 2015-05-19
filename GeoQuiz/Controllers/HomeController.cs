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
        //List<string> drzave = new List<string>();
        [HttpGet] 
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Play()
        {
            return View(new CheckContinent());
        }
        
        [WebMethod]
        public string RandomDrzava2()
        {
            var ids = from drzava in db.Drzava
                      select drzava.NazivDrzavaEng;
            List<string> drzave = new List<string>();
            
            foreach (var item in ids)
            {
                drzave.Add(item.Trim());

            }
            int r = rand.Next(drzave.Count);
            string odabrana = ((string)drzave[r]);
            drzave.Remove(odabrana);
            return odabrana;
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
        
    }
}