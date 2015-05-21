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
using System.Data.Linq;

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
            return View(db.HighScore.ToList());
        }

        [HttpGet]
        public ActionResult Play()
        {
            return View(GetCheckContinentsInitialModel());
        }
        [HttpPost]
        public ActionResult Play(PostedCheckContinents postedCheckContinents)
        {
            return View(GetCheckContinentModel(postedCheckContinents));
        }
        public CheckContinentViewModel GetCheckContinentModel(PostedCheckContinents postedCheckContinents)
        {


            Array.Clear(GlobVar.postedCheckCon, 0, GlobVar.postedCheckCon.Length);

            
            var model = new CheckContinentViewModel();
            var selectedCheckContinents = new List<CheckContinent>();
            var postedCheckContinentIds = new string[0];
            if (postedCheckContinents == null) postedCheckContinents = new PostedCheckContinents();

            
            if (postedCheckContinents.CheckContinentIds != null && postedCheckContinents.CheckContinentIds.Any())
            {
                postedCheckContinentIds = postedCheckContinents.CheckContinentIds;
                GlobVar.postedCheckCon = postedCheckContinents.CheckContinentIds;
            }
            
            // if there are any selected ids saved, create a list of checkcontinents
            if (postedCheckContinentIds.Any())
            {
                selectedCheckContinents = CheckContinentRepository.GetAll()
                 .Where(x => postedCheckContinentIds.Any(s => x.Id.ToString().Equals(s)))
                 .ToList();

            }

          
            model.AvailableCheckContinents = CheckContinentRepository.GetAll().ToList();
            model.SelectedCheckContinents= selectedCheckContinents;
            model.PostedCheckContinents = postedCheckContinents;

            return model;
        }
        public CheckContinentViewModel GetCheckContinentsInitialModel()
        {
            //setup properties
            var model = new CheckContinentViewModel();
            var selectedCheckContinents = new List<CheckContinent>();

            //setup a view model
            model.AvailableCheckContinents = CheckContinentRepository.GetAll().ToList();
            model.SelectedCheckContinents = selectedCheckContinents;

            return model;
        }
        [WebMethod]
        public int PunjenjeDrzava()
        {
            GlobVar.drzave.Clear();
            
            foreach (var drz in GlobVar.postedCheckCon)
            {
                string caseSwitch = drz;
                switch (caseSwitch)
                {
                    case "0":
                        break;
                    case "1":
                        sifkon.Add(1);
                        break;
                    case "2":
                        sifkon.Add(2);
                        break;
                    case "3":
                        sifkon.Add(3);
                        break;
                    case "4":
                        sifkon.Add(4);
                        break;
                    case "5":
                        sifkon.Add(5);
                        break;
                    case "6":
                        sifkon.Add(6);
                        break;
                    case "7":

                        for (int i = 1; i <= 6; i++)
                        {
                            sifkon.Add(i);
                        }
                        break;
                   default:
                        break;
                }

            }
            int m = sifkon.Count;
            var ids = from drzava in db.Drzava
                      where sifkon.Contains(drzava.SifraKontinent)
                      select drzava.NazivDrzavaEng;
            foreach (var d in ids)
            {
                GlobVar.drzave.Add(d.Trim());
            }
            return m;
        }
        [WebMethod]
        public string RandomDrzava2()
        {
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
        public List<string> DohvatiPodatak(string stisnuta)
        {

            List<string> podaciODrzavi = new List<string>();

            var podaci = from drzava in db.Drzava
                         where drzava.NazivDrzavaEng == stisnuta
                         select new { drzava.GlavniGrad, drzava.BrojStanovnika }; //dohvaća samo ovo dvoje, ostalo nema smisla ili su nule

            //sad treba smisliti kako koristiti ova gore dva podatka, to jest izvući ih iz ovog var podaci
            //foreach (var atribut in podaci)
            //{
            //    atribut.ToString();
            //    podaciODrzavi.Add(atribut);
            //}

            return podaciODrzavi;
        }
        [WebMethod]
        public void SpremiScore(string nick, int score)
        {
            // Create a new Order o;
            GeoQuizEntities CTX;
            CTX = new GeoQuizEntities();
            HighScore hig = new HighScore
            {
                Nick = nick,
                Score = score
            };
            CTX.HighScore.Add(hig);
            

            // Submit the change to the database. 
            try
            {
                CTX.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // Make some adjustments. 
                // ... 
                // Try again.
                CTX.SaveChanges();
            }
            //return "";
        }


        public ActionResult Instructions()
        {
            ViewBag.Message = "Instructions";

            return View();
        }

        public ActionResult HighScore()
        {
            ViewBag.Message = "Highscore";

            return View(db.HighScore.ToList());
        }

        public ActionResult Learning()
        {
            ViewBag.Message = "Learning";

            return View();
        }
    }
}