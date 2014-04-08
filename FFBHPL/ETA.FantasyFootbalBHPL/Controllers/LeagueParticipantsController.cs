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
    public class LeagueParticipantsController : Controller
    {
        private fantasyEntities1 db = new fantasyEntities1();

        //
        // GET: /LeagueParticipants/

        public ActionResult Index()
        {
            var leagueparticipants = db.leagueparticipants.Include(l => l.league).Include(l => l.user);
            return View(leagueparticipants.ToList());
        }

        //
        // GET: /LeagueParticipants/Details/5

        public ActionResult Details(int id = 0)
        {
            leagueparticipants leagueparticipants = db.leagueparticipants.Find(id);
            if (leagueparticipants == null)
            {
                return HttpNotFound();
            }
            return View(leagueparticipants);
        }

        //
        // GET: /LeagueParticipants/Create

        public ActionResult Create()
        {
            ViewBag.participatesIntoLeague = new SelectList(db.league, "idLeague", "leagueName");
            ViewBag.participant = new SelectList(db.user, "userId", "firstName");
            return View();
        }

        //
        // POST: /LeagueParticipants/Create

        [HttpPost]
        public ActionResult Create(leagueparticipants leagueparticipants)
        {
            if (ModelState.IsValid)
            {
                db.leagueparticipants.Add(leagueparticipants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.participatesIntoLeague = new SelectList(db.league, "idLeague", "leagueName", leagueparticipants.participatesIntoLeague);
            ViewBag.participant = new SelectList(db.user, "userId", "firstName", leagueparticipants.participant);
            return View(leagueparticipants);
        }

        //
        // GET: /LeagueParticipants/Edit/5

        public ActionResult Edit(int id = 0)
        {
            leagueparticipants leagueparticipants = db.leagueparticipants.Find(id);
            if (leagueparticipants == null)
            {
                return HttpNotFound();
            }
            ViewBag.participatesIntoLeague = new SelectList(db.league, "idLeague", "leagueName", leagueparticipants.participatesIntoLeague);
            ViewBag.participant = new SelectList(db.user, "userId", "firstName", leagueparticipants.participant);
            return View(leagueparticipants);
        }

        //
        // POST: /LeagueParticipants/Edit/5

        [HttpPost]
        public ActionResult Edit(leagueparticipants leagueparticipants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leagueparticipants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.participatesIntoLeague = new SelectList(db.league, "idLeague", "leagueName", leagueparticipants.participatesIntoLeague);
            ViewBag.participant = new SelectList(db.user, "userId", "firstName", leagueparticipants.participant);
            return View(leagueparticipants);
        }

        //
        // GET: /LeagueParticipants/Delete/5

        public ActionResult Delete(int id = 0)
        {
            leagueparticipants leagueparticipants = db.leagueparticipants.Find(id);
            if (leagueparticipants == null)
            {
                return HttpNotFound();
            }
            return View(leagueparticipants);
        }

        //
        // POST: /LeagueParticipants/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            leagueparticipants leagueparticipants = db.leagueparticipants.Find(id);
            db.leagueparticipants.Remove(leagueparticipants);
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