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
    public class MatchEventsController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /MatchEvents/

        public ActionResult Index()
        {
            var matchevents = db.matchevents.Include(m => m.events).Include(m => m.footballplayer).Include(m => m.match);
            return View(matchevents.ToList());
        }

        //
        // GET: /MatchEvents/Details/5

        public ActionResult Details(int id = 0)
        {
            matchevents matchevents = db.matchevents.Find(id);
            if (matchevents == null)
            {
                return HttpNotFound();
            }
            return View(matchevents);
        }

        //
        // GET: /MatchEvents/Create

        public ActionResult Create()
        {
            ViewBag.idEvents1 = new SelectList(db.events, "idEvents", "eventName");
            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName");
            ViewBag.idMatch1 = new SelectList(db.match, "idMatch", "idMatch");
            return View();
        }

        //
        // POST: /MatchEvents/Create

        [HttpPost]
        public ActionResult Create(matchevents matchevents)
        {
            if (ModelState.IsValid)
            {
                db.matchevents.Add(matchevents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEvents1 = new SelectList(db.events, "idEvents", "eventName", matchevents.idEvents1);
            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", matchevents.idFootballPlayer1);
            ViewBag.idMatch1 = new SelectList(db.match, "idMatch", "idMatch", matchevents.idMatch1);
            return View(matchevents);
        }

        //
        // GET: /MatchEvents/Edit/5

        public ActionResult Edit(int id = 0)
        {
            matchevents matchevents = db.matchevents.Find(id);
            if (matchevents == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEvents1 = new SelectList(db.events, "idEvents", "eventName", matchevents.idEvents1);
            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", matchevents.idFootballPlayer1);
            ViewBag.idMatch1 = new SelectList(db.match, "idMatch", "idMatch", matchevents.idMatch1);
            return View(matchevents);
        }

        //
        // POST: /MatchEvents/Edit/5

        [HttpPost]
        public ActionResult Edit(matchevents matchevents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matchevents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEvents1 = new SelectList(db.events, "idEvents", "eventName", matchevents.idEvents1);
            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", matchevents.idFootballPlayer1);
            ViewBag.idMatch1 = new SelectList(db.match, "idMatch", "idMatch", matchevents.idMatch1);
            return View(matchevents);
        }

        //
        // GET: /MatchEvents/Delete/5

        public ActionResult Delete(int id = 0)
        {
            matchevents matchevents = db.matchevents.Find(id);
            if (matchevents == null)
            {
                return HttpNotFound();
            }
            return View(matchevents);
        }

        //
        // POST: /MatchEvents/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            matchevents matchevents = db.matchevents.Find(id);
            db.matchevents.Remove(matchevents);
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