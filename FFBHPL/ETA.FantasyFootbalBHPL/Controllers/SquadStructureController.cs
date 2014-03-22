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
    public class SquadStructureController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /SquadStructure/

        public ActionResult Index()
        {
            return View(db.squadstructure.ToList());
        }

        //
        // GET: /SquadStructure/Details/5

        public ActionResult Details(int id = 0)
        {
            squadstructure squadstructure = db.squadstructure.Find(id);
            if (squadstructure == null)
            {
                return HttpNotFound();
            }
            return View(squadstructure);
        }

        //
        // GET: /SquadStructure/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SquadStructure/Create

        [HttpPost]
        public ActionResult Create(squadstructure squadstructure)
        {
            if (ModelState.IsValid)
            {
                db.squadstructure.Add(squadstructure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(squadstructure);
        }

        //
        // GET: /SquadStructure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            squadstructure squadstructure = db.squadstructure.Find(id);
            if (squadstructure == null)
            {
                return HttpNotFound();
            }
            return View(squadstructure);
        }

        //
        // POST: /SquadStructure/Edit/5

        [HttpPost]
        public ActionResult Edit(squadstructure squadstructure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squadstructure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(squadstructure);
        }

        //
        // GET: /SquadStructure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            squadstructure squadstructure = db.squadstructure.Find(id);
            if (squadstructure == null)
            {
                return HttpNotFound();
            }
            return View(squadstructure);
        }

        //
        // POST: /SquadStructure/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            squadstructure squadstructure = db.squadstructure.Find(id);
            db.squadstructure.Remove(squadstructure);
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