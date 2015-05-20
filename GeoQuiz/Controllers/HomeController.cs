using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeoQuiz.Models;
using System.Web.UI;
using System.Web.Services;
using System.Web.Script.Serialization;

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

        [WebMethod]
        public string DohvatiPodatak(string stisnuta)
        {
            //string val = Show();
            //List<string> novaval = GlobVar.val.Split(',').ToList();

            /*var podaci= from drzava in db.Drzava
                        where db.Drzava.NazivDrzaveEng=stisnutaDrzava
                        select *;  PODACI DRZAVE */        
             
            //List<Drzava> dd = db.Drzava.ToList();
            //List<int> myValues = new List<int>(new int[] { 1, 2, 3 });             
            //var ids = from drzava in db.Drzava
            //          where sifkon.Contains(drzava.SifraKontinent)
            //          select drzava.NazivDrzavaEng;

            //List<string> drzave = new List<string>();

            //foreach (var item in ids)
            //    drzave.Add(item.Trim());


            //int r = rand.Next(drzave.Count);
            //string odabrana = ((string)drzave[r]);
            //return Json(bla, JsonRequestBehaviour.AllowGet);
            //return new JavaScriptSerializer().Serialize(new { errMsg = "test" });
            return "podaci";
            //return View();
        }
        [WebMethod]
        public string SpremiScore(string nick, int score)
        {
            return "patkica";
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
            ViewBag.Message = "Instructions";

            return View();
        }

        public ActionResult Learning()
        {
            ViewBag.Message = "Learning";

            return View();
        }
    }
}