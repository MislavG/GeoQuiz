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

        List<int> sifkon = new List<int>();
       
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
        public List<string> PunjenjeDrzava()
        {
            List<string> novaval = GlobVar.val.Split(',').ToList();
            GlobVar.drzave.Clear();
            
            foreach (var drz in novaval)
            {
                string caseSwitch = drz.Trim();
                switch (caseSwitch)
                {
                    case "":
                        break;
                    case "Europe":
                        sifkon.Add(1);
                        break;
                    case "Africa":
                        sifkon.Add(2);
                        break;
                    case "Asia":
                        sifkon.Add(3);
                        break;
                    case "North America":
                        sifkon.Add(4);
                        break;
                    case "South America":
                        sifkon.Add(5);
                        break;
                    case "Australia":
                        sifkon.Add(6);
                        break;
                    case "Whole World":

                        for (int i = 1; i <= 6; i++)
                        {
                            sifkon.Add(i);
                        }
                        break;

                }

            }           
            var ids = from drzava in db.Drzava
                      where sifkon.Contains(drzava.SifraKontinent)
                      select drzava.NazivDrzavaEng;
            foreach (var d in ids)
            {
                GlobVar.drzave.Add(d.Trim());
            }
            return GlobVar.drzave;
        }
        [WebMethod]
        public string RandomDrzava2()
        {
            GlobVar.odabrana = string.Empty;
            int r = rand.Next(GlobVar.drzave.Count);           
            GlobVar.odabrana = ((string)GlobVar.drzave[r]);
            string pomodabrana = String.Copy(GlobVar.odabrana);
            return pomodabrana;
        }
        [WebMethod]
        public string BrisanjePogodene()
        {
            GlobVar.drzave.Remove(GlobVar.odabrana);
            return "ok";
        }

        [HttpPost]
        public string Show(FormCollection postedForm, CheckContinent model)
        {
            GlobVar.val = string.Empty;

            foreach (var con in model.Continents)
            {

                if (postedForm[con].ToString().Contains("true"))
                {
                    GlobVar.val = GlobVar.val + "," + con;
                }

            }

            return GlobVar.val;
        }

        public ActionResult Instructions()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}