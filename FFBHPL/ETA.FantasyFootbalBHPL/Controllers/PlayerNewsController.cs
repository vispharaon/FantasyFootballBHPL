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
    public class PlayerNewsController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /PlayerNews/

        public ActionResult Index()
        {
            var playernews = db.playernews.Include(p => p.footballplayer);
            return View(playernews.ToList());
        }

        //
        // GET: /PlayerNews/Details/5

        public ActionResult Details(int id = 0)
        {
            playernews playernews = db.playernews.Find(id);
            if (playernews == null)
            {
                return HttpNotFound();
            }
            return View(playernews);
        }

        //
        // GET: /PlayerNews/Create

        public ActionResult Create()
        {
            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName");
            return View();
        }

        //
        // POST: /PlayerNews/Create

        [HttpPost]
        public ActionResult Create(playernews playernews)
        {
            if (ModelState.IsValid)
            {
                db.playernews.Add(playernews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", playernews.idFootballPlayer1);
            return View(playernews);
        }

        //
        // GET: /PlayerNews/Edit/5

        public ActionResult Edit(int id = 0)
        {
            playernews playernews = db.playernews.Find(id);
            if (playernews == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", playernews.idFootballPlayer1);
            return View(playernews);
        }

        //
        // POST: /PlayerNews/Edit/5

        [HttpPost]
        public ActionResult Edit(playernews playernews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playernews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFootballPlayer1 = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", playernews.idFootballPlayer1);
            return View(playernews);
        }

        //
        // GET: /PlayerNews/Delete/5

        public ActionResult Delete(int id = 0)
        {
            playernews playernews = db.playernews.Find(id);
            if (playernews == null)
            {
                return HttpNotFound();
            }
            return View(playernews);
        }

        //
        // POST: /PlayerNews/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            playernews playernews = db.playernews.Find(id);
            db.playernews.Remove(playernews);
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