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
    public class LeagueController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /League/

        public ActionResult Index()
        {
            var league = db.league.Include(l => l.gameweek).Include(l => l.user);
            return View(league.ToList());
        }

        //
        // GET: /League/Details/5

        public ActionResult Details(int id = 0)
        {
            league league = db.league.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // GET: /League/Create

        public ActionResult Create()
        {
            ViewBag.fromGameweek = new SelectList(db.gameweek, "idGameWeek", "gameweekName");
            ViewBag.owner = new SelectList(db.user, "userId", "firstName");
            return View();
        }

        //
        // POST: /League/Create

        [HttpPost]
        public ActionResult Create(league league)
        {
            if (ModelState.IsValid)
            {
                db.league.Add(league);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fromGameweek = new SelectList(db.gameweek, "idGameWeek", "gameweekName", league.fromGameweek);
            ViewBag.owner = new SelectList(db.user, "userId", "firstName", league.owner);
            return View(league);
        }

        //
        // GET: /League/Edit/5

        public ActionResult Edit(int id = 0)
        {
            league league = db.league.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            ViewBag.fromGameweek = new SelectList(db.gameweek, "idGameWeek", "gameweekName", league.fromGameweek);
            ViewBag.owner = new SelectList(db.user, "userId", "firstName", league.owner);
            return View(league);
        }

        //
        // POST: /League/Edit/5

        [HttpPost]
        public ActionResult Edit(league league)
        {
            if (ModelState.IsValid)
            {
                db.Entry(league).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fromGameweek = new SelectList(db.gameweek, "idGameWeek", "gameweekName", league.fromGameweek);
            ViewBag.owner = new SelectList(db.user, "userId", "firstName", league.owner);
            return View(league);
        }

        //
        // GET: /League/Delete/5

        public ActionResult Delete(int id = 0)
        {
            league league = db.league.Find(id);
            if (league == null)
            {
                return HttpNotFound();
            }
            return View(league);
        }

        //
        // POST: /League/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            league league = db.league.Find(id);
            db.league.Remove(league);
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