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
    public class SquadController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /Squad/

        public ActionResult Index()
        {
            return View(db.squad.ToList());
        }

        //
        // GET: /Squad/Details/5

        public ActionResult Details(int id = 0)
        {
            squad squad = db.squad.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        //
        // GET: /Squad/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Squad/Create

        [HttpPost]
        public ActionResult Create(squad squad)
        {
            if (ModelState.IsValid)
            {
                db.squad.Add(squad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(squad);
        }

        //
        // GET: /Squad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            squad squad = db.squad.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        //
        // POST: /Squad/Edit/5

        [HttpPost]
        public ActionResult Edit(squad squad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(squad);
        }

        //
        // GET: /Squad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            squad squad = db.squad.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        //
        // POST: /Squad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            squad squad = db.squad.Find(id);
            db.squad.Remove(squad);
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