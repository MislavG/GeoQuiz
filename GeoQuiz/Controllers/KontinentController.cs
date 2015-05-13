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
    public class KontinentController : Controller
    {
        private GeoQuizEntities db = new GeoQuizEntities();

        // GET: /Kontinent/
        public ActionResult Index()
        {
            return View(db.Kontinent.ToList());
        }

        // GET: /Kontinent/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontinent kontinent = db.Kontinent.Find(id);
            if (kontinent == null)
            {
                return HttpNotFound();
            }
            return View(kontinent);
        }

        // GET: /Kontinent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Kontinent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraKontinent,NazivKontinent")] Kontinent kontinent)
        {
            if (ModelState.IsValid)
            {
                db.Kontinent.Add(kontinent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kontinent);
        }

        // GET: /Kontinent/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontinent kontinent = db.Kontinent.Find(id);
            if (kontinent == null)
            {
                return HttpNotFound();
            }
            return View(kontinent);
        }

        // POST: /Kontinent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraKontinent,NazivKontinent")] Kontinent kontinent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontinent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kontinent);
        }

        // GET: /Kontinent/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontinent kontinent = db.Kontinent.Find(id);
            if (kontinent == null)
            {
                return HttpNotFound();
            }
            return View(kontinent);
        }

        // POST: /Kontinent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            Kontinent kontinent = db.Kontinent.Find(id);
            db.Kontinent.Remove(kontinent);
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
