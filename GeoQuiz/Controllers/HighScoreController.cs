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
    public class HighScoreController : Controller
    {
        private GeoQuizEntities db = new GeoQuizEntities();

        // GET: /HighScore/
        public ActionResult Index()
        {
            return View(db.HighScore.ToList());
        }

        // GET: /HighScore/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighScore highscore = db.HighScore.Find(id);
            if (highscore == null)
            {
                return HttpNotFound();
            }
            return View(highscore);
        }

        // GET: /HighScore/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HighScore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SifraHS,Nadimak,Bodovi")] HighScore highscore)
        {
            if (ModelState.IsValid)
            {
                db.HighScore.Add(highscore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(highscore);
        }

        // GET: /HighScore/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighScore highscore = db.HighScore.Find(id);
            if (highscore == null)
            {
                return HttpNotFound();
            }
            return View(highscore);
        }

        // POST: /HighScore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SifraHS,Nadimak,Bodovi")] HighScore highscore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(highscore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(highscore);
        }

        // GET: /HighScore/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighScore highscore = db.HighScore.Find(id);
            if (highscore == null)
            {
                return HttpNotFound();
            }
            return View(highscore);
        }

        // POST: /HighScore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            HighScore highscore = db.HighScore.Find(id);
            db.HighScore.Remove(highscore);
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
