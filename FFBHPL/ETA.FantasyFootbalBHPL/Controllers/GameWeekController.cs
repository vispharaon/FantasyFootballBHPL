using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETA.FantasyFootbalBHPL.Models;

namespace ETA.FantasyFootbalBHPL.Controllers
{
    public class GameWeekController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /GameWeek/

        public ActionResult Index()
        {
            var gameweek = db.gameweek.Include(g => g.season);
            return View(gameweek.ToList());
        }

        //
        // GET: /GameWeek/Details/5

        public ActionResult Details(int id = 0)
        {
            gameweek gameweek = db.gameweek.Find(id);
            if (gameweek == null)
            {
                return HttpNotFound();
            }
            return View(gameweek);
        }

        //
        // GET: /GameWeek/Create

        public ActionResult Create()
        {
            ViewBag.idSeason1 = new SelectList(db.season, "idSeason", "seasonName");
            return View();
        }

        //
        // POST: /GameWeek/Create

        [HttpPost]
        public ActionResult Create(gameweek gameweek)
        {
            if (ModelState.IsValid)
            {
                db.gameweek.Add(gameweek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSeason1 = new SelectList(db.season, "idSeason", "seasonName", gameweek.idSeason1);
            return View(gameweek);
        }

        //
        // GET: /GameWeek/Edit/5

        public ActionResult Edit(int id = 0)
        {
            gameweek gameweek = db.gameweek.Find(id);
            if (gameweek == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSeason1 = new SelectList(db.season, "idSeason", "seasonName", gameweek.idSeason1);
            return View(gameweek);
        }

        //
        // POST: /GameWeek/Edit/5

        [HttpPost]
        public ActionResult Edit(gameweek gameweek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gameweek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSeason1 = new SelectList(db.season, "idSeason", "seasonName", gameweek.idSeason1);
            return View(gameweek);
        }

        //
        // GET: /GameWeek/Delete/5

        public ActionResult Delete(int id = 0)
        {
            gameweek gameweek = db.gameweek.Find(id);
            if (gameweek == null)
            {
                return HttpNotFound();
            }
            return View(gameweek);
        }

        //
        // POST: /GameWeek/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            gameweek gameweek = db.gameweek.Find(id);
            db.gameweek.Remove(gameweek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}