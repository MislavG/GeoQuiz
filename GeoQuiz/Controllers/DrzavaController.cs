using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeoQuiz.Models;

namespace GeoQuiz.Controllers
{
    public class DrzavaController : Controller
    {
        private GeoQuizEntities db = new GeoQuizEntities();

        // GET: /Drzava/
        public ActionResult Index()
        {
            var drzava = db.Drzava.Include(d => d.Kontinent);
            return View(drzava.ToList());
        }

        // GET: /Drzava/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzava.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // GET: /Drzava/Create
        public ActionResult Create()
        {
            ViewBag.SifraKontinent = new SelectList(db.Kontinent, "SifraKontinent", "NazivKontinentHr");
            return View();
        }

        // POST: /Drzava/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraDrzava,SifraKontinent,GlavniGrad,Zastava,BrojStanovnika,NazivDrzavaHr,NazivDrzavaEng")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Drzava.Add(drzava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SifraKontinent = new SelectList(db.Kontinent, "SifraKontinent", "NazivKontinentHr", drzava.SifraKontinent);
            return View(drzava);
        }

        // GET: /Drzava/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzava.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            ViewBag.SifraKontinent = new SelectList(db.Kontinent, "SifraKontinent", "NazivKontinentHr", drzava.SifraKontinent);
            return View(drzava);
        }

        // POST: /Drzava/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraDrzava,SifraKontinent,GlavniGrad,Zastava,BrojStanovnika,NazivDrzavaHr,NazivDrzavaEng")] Drzava drzava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drzava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SifraKontinent = new SelectList(db.Kontinent, "SifraKontinent", "NazivKontinentHr", drzava.SifraKontinent);
            return View(drzava);
        }

        // GET: /Drzava/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drzava drzava = db.Drzava.Find(id);
            if (drzava == null)
            {
                return HttpNotFound();
            }
            return View(drzava);
        }

        // POST: /Drzava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Drzava drzava = db.Drzava.Find(id);
            db.Drzava.Remove(drzava);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
