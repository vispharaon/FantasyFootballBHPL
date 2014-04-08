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
    public class FootballPlayerController : Controller
    {
        private fantasyEntities1 db = new fantasyEntities1();

        //
        // GET: /FootballPlayer/

        public ActionResult Index()
        {
            var footballplayer = db.footballplayer.Include(f => f.footballteam).Include(f => f.position);
            return View(footballplayer.ToList());
        }

        //
        // GET: /FootballPlayer/Details/5

        public ActionResult Details(int id = 0)
        {
            footballplayer footballplayer = db.footballplayer.Find(id);
            if (footballplayer == null)
            {
                return HttpNotFound();
            }
            return View(footballplayer);
        }

        //
        // GET: /FootballPlayer/Create

        public ActionResult Create()
        {
            ViewBag.idFootballTeam1 = new SelectList(db.footballteam, "idFootballTeam", "teamName");
            ViewBag.idPosition1 = new SelectList(db.position, "idPosition", "positionName");
            return View();
        }

        //
        // POST: /FootballPlayer/Create

        [HttpPost]
        public ActionResult Create(footballplayer footballplayer)
        {
            if (ModelState.IsValid)
            {
                db.footballplayer.Add(footballplayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFootballTeam1 = new SelectList(db.footballteam, "idFootballTeam", "teamName", footballplayer.idFootballTeam1);
            ViewBag.idPosition1 = new SelectList(db.position, "idPosition", "positionName", footballplayer.idPosition1);
            return View(footballplayer);
        }

        //
        // GET: /FootballPlayer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            footballplayer footballplayer = db.footballplayer.Find(id);
            if (footballplayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFootballTeam1 = new SelectList(db.footballteam, "idFootballTeam", "teamName", footballplayer.idFootballTeam1);
            ViewBag.idPosition1 = new SelectList(db.position, "idPosition", "positionName", footballplayer.idPosition1);
            return View(footballplayer);
        }

        //
        // POST: /FootballPlayer/Edit/5

        [HttpPost]
        public ActionResult Edit(footballplayer footballplayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(footballplayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFootballTeam1 = new SelectList(db.footballteam, "idFootballTeam", "teamName", footballplayer.idFootballTeam1);
            ViewBag.idPosition1 = new SelectList(db.position, "idPosition", "positionName", footballplayer.idPosition1);
            return View(footballplayer);
        }

        //
        // GET: /FootballPlayer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            footballplayer footballplayer = db.footballplayer.Find(id);
            if (footballplayer == null)
            {
                return HttpNotFound();
            }
            return View(footballplayer);
        }

        //
        // POST: /FootballPlayer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            footballplayer footballplayer = db.footballplayer.Find(id);
            db.footballplayer.Remove(footballplayer);
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