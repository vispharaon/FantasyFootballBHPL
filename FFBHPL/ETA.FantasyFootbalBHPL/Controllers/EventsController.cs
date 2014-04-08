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
    public class EventsController : Controller
    {
        private fantasyEntities1 db = new fantasyEntities1();

        //
        // GET: /Events/

        public ActionResult Index()
        {
            return View(db.events.ToList());
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id = 0)
        {
            events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Events/Create

        [HttpPost]
        public ActionResult Create(events events)
        {
            if (ModelState.IsValid)
            {
                db.events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);
        }

        //
        // GET: /Events/Edit/5

        public ActionResult Edit(int id = 0)
        {
            events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // POST: /Events/Edit/5

        [HttpPost]
        public ActionResult Edit(events events)
        {
            if (ModelState.IsValid)
            {
                db.Entry(events).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        //
        // GET: /Events/Delete/5

        public ActionResult Delete(int id = 0)
        {
            events events = db.events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        //
        // POST: /Events/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            events events = db.events.Find(id);
            db.events.Remove(events);
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