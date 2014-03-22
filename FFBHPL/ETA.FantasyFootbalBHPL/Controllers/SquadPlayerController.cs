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
    public class SquadPlayerController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /SquadPlayer/

        public ActionResult Index()
        {
            var squadplayer = db.squadplayer.Include(s => s.footballplayer).Include(s => s.squad);
            return View(squadplayer.ToList());
        }

        //
        // GET: /SquadPlayer/Details/5

        public ActionResult Details(int id = 0)
        {
            squadplayer squadplayer = db.squadplayer.Find(id);
            if (squadplayer == null)
            {
                return HttpNotFound();
            }
            return View(squadplayer);
        }

        //
        // GET: /SquadPlayer/Create

        public ActionResult Create()
        {
            ViewBag.FootballPlayerFK = new SelectList(db.footballplayer, "idFootballPlayer", "firstName");
            ViewBag.PlayersTeamFK = new SelectList(db.squad, "idPlayersTeam", "playersTeamName");
            return View();
        }

        //
        // POST: /SquadPlayer/Create

        [HttpPost]
        public ActionResult Create(squadplayer squadplayer)
        {
            if (ModelState.IsValid)
            {
                db.squadplayer.Add(squadplayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FootballPlayerFK = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", squadplayer.FootballPlayerFK);
            ViewBag.PlayersTeamFK = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", squadplayer.PlayersTeamFK);
            return View(squadplayer);
        }

        //
        // GET: /SquadPlayer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            squadplayer squadplayer = db.squadplayer.Find(id);
            if (squadplayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.FootballPlayerFK = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", squadplayer.FootballPlayerFK);
            ViewBag.PlayersTeamFK = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", squadplayer.PlayersTeamFK);
            return View(squadplayer);
        }

        //
        // POST: /SquadPlayer/Edit/5

        [HttpPost]
        public ActionResult Edit(squadplayer squadplayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squadplayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FootballPlayerFK = new SelectList(db.footballplayer, "idFootballPlayer", "firstName", squadplayer.FootballPlayerFK);
            ViewBag.PlayersTeamFK = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", squadplayer.PlayersTeamFK);
            return View(squadplayer);
        }

        //
        // GET: /SquadPlayer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            squadplayer squadplayer = db.squadplayer.Find(id);
            if (squadplayer == null)
            {
                return HttpNotFound();
            }
            return View(squadplayer);
        }

        //
        // POST: /SquadPlayer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            squadplayer squadplayer = db.squadplayer.Find(id);
            db.squadplayer.Remove(squadplayer);
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