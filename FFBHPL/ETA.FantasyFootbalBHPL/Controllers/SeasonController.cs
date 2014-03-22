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
    public class SeasonController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /Season/

        public ActionResult Index()
        {
            var season = db.season.Include(s => s.squadstructure);
            return View(season.ToList());
        }

        //
        // GET: /Season/Details/5

        public ActionResult Details(int id = 0)
        {
            season season = db.season.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        //
        // GET: /Season/Create

        public ActionResult Create()
        {
            ViewBag.SquadStructure_idSquadStructure = new SelectList(db.squadstructure, "idSquadStructure", "idSquadStructure");
            return View();
        }

        //
        // POST: /Season/Create

        [HttpPost]
        public ActionResult Create(season season)
        {
            if (ModelState.IsValid)
            {
                db.season.Add(season);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SquadStructure_idSquadStructure = new SelectList(db.squadstructure, "idSquadStructure", "idSquadStructure", season.SquadStructure_idSquadStructure);
            return View(season);
        }

        //
        // GET: /Season/Edit/5

        public ActionResult Edit(int id = 0)
        {
            season season = db.season.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            ViewBag.SquadStructure_idSquadStructure = new SelectList(db.squadstructure, "idSquadStructure", "idSquadStructure", season.SquadStructure_idSquadStructure);
            return View(season);
        }

        //
        // POST: /Season/Edit/5

        [HttpPost]
        public ActionResult Edit(season season)
        {
            if (ModelState.IsValid)
            {
                db.Entry(season).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SquadStructure_idSquadStructure = new SelectList(db.squadstructure, "idSquadStructure", "idSquadStructure", season.SquadStructure_idSquadStructure);
            return View(season);
        }

        //
        // GET: /Season/Delete/5

        public ActionResult Delete(int id = 0)
        {
            season season = db.season.Find(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return View(season);
        }

        //
        // POST: /Season/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            season season = db.season.Find(id);
            db.season.Remove(season);
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