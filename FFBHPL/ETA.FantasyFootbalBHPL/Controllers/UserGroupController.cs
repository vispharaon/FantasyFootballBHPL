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
    public class UserGroupController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /UserGroup/

        public ActionResult Index()
        {
            return View(db.usergroup.ToList());
        }

        //
        // GET: /UserGroup/Details/5

        public ActionResult Details(int id = 0)
        {
            usergroup usergroup = db.usergroup.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        //
        // GET: /UserGroup/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserGroup/Create

        [HttpPost]
        public ActionResult Create(usergroup usergroup)
        {
            if (ModelState.IsValid)
            {
                db.usergroup.Add(usergroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usergroup);
        }

        //
        // GET: /UserGroup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            usergroup usergroup = db.usergroup.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        //
        // POST: /UserGroup/Edit/5

        [HttpPost]
        public ActionResult Edit(usergroup usergroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usergroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usergroup);
        }

        //
        // GET: /UserGroup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            usergroup usergroup = db.usergroup.Find(id);
            if (usergroup == null)
            {
                return HttpNotFound();
            }
            return View(usergroup);
        }

        //
        // POST: /UserGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            usergroup usergroup = db.usergroup.Find(id);
            db.usergroup.Remove(usergroup);
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