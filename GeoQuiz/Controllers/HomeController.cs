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
            //string val = Show();
            List<string> novaval = GlobVar.val.Split(',').ToList();

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
            //List<Drzava> dd = db.Drzava.ToList();
            //List<int> myValues = new List<int>(new int[] { 1, 2, 3 });             
            var ids = from drzava in db.Drzava
                      where sifkon.Contains(drzava.SifraKontinent)
                      select drzava.NazivDrzavaEng;

            List<string> drzave = new List<string>();

            foreach (var item in ids)
                drzave.Add(item.Trim());


            int r = rand.Next(drzave.Count);
            string odabrana = ((string)drzave[r]);
            return odabrana;
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