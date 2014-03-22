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
    public class PositionController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /Position/

        public ActionResult Index()
        {
            return View(db.position.ToList());
        }

        //
        // GET: /Position/Details/5

        public ActionResult Details(int id = 0)
        {
            position position = db.position.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        //
        // GET: /Position/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Position/Create

        [HttpPost]
        public ActionResult Create(position position)
        {
            if (ModelState.IsValid)
            {
                db.position.Add(position);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        //
        // GET: /Position/Edit/5

        public ActionResult Edit(int id = 0)
        {
            position position = db.position.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        //
        // POST: /Position/Edit/5

        [HttpPost]
        public ActionResult Edit(position position)
        {
            if (ModelState.IsValid)
            {
                db.Entry(position).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(position);
        }

        //
        // GET: /Position/Delete/5

        public ActionResult Delete(int id = 0)
        {
            position position = db.position.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        //
        // POST: /Position/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            position position = db.position.Find(id);
            db.position.Remove(position);
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