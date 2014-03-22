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
    public class SelectedSquadCheckedController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /SelectedSquadChecked/

        public ActionResult Index()
        {
            var selectedsquadchecked = db.selectedsquadchecked.Include(s => s.gameweek).Include(s => s.squad);
            return View(selectedsquadchecked.ToList());
        }

        //
        // GET: /SelectedSquadChecked/Details/5

        public ActionResult Details(int id = 0)
        {
            selectedsquadchecked selectedsquadchecked = db.selectedsquadchecked.Find(id);
            if (selectedsquadchecked == null)
            {
                return HttpNotFound();
            }
            return View(selectedsquadchecked);
        }

        //
        // GET: /SelectedSquadChecked/Create

        public ActionResult Create()
        {
            ViewBag.idGameWeek1 = new SelectList(db.gameweek, "idGameWeek", "gameweekName");
            ViewBag.Squad_idPlayersTeam = new SelectList(db.squad, "idPlayersTeam", "playersTeamName");
            return View();
        }

        //
        // POST: /SelectedSquadChecked/Create

        [HttpPost]
        public ActionResult Create(selectedsquadchecked selectedsquadchecked)
        {
            if (ModelState.IsValid)
            {
                db.selectedsquadchecked.Add(selectedsquadchecked);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idGameWeek1 = new SelectList(db.gameweek, "idGameWeek", "gameweekName", selectedsquadchecked.idGameWeek1);
            ViewBag.Squad_idPlayersTeam = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", selectedsquadchecked.Squad_idPlayersTeam);
            return View(selectedsquadchecked);
        }

        //
        // GET: /SelectedSquadChecked/Edit/5

        public ActionResult Edit(int id = 0)
        {
            selectedsquadchecked selectedsquadchecked = db.selectedsquadchecked.Find(id);
            if (selectedsquadchecked == null)
            {
                return HttpNotFound();
            }
            ViewBag.idGameWeek1 = new SelectList(db.gameweek, "idGameWeek", "gameweekName", selectedsquadchecked.idGameWeek1);
            ViewBag.Squad_idPlayersTeam = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", selectedsquadchecked.Squad_idPlayersTeam);
            return View(selectedsquadchecked);
        }

        //
        // POST: /SelectedSquadChecked/Edit/5

        [HttpPost]
        public ActionResult Edit(selectedsquadchecked selectedsquadchecked)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selectedsquadchecked).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idGameWeek1 = new SelectList(db.gameweek, "idGameWeek", "gameweekName", selectedsquadchecked.idGameWeek1);
            ViewBag.Squad_idPlayersTeam = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", selectedsquadchecked.Squad_idPlayersTeam);
            return View(selectedsquadchecked);
        }

        //
        // GET: /SelectedSquadChecked/Delete/5

        public ActionResult Delete(int id = 0)
        {
            selectedsquadchecked selectedsquadchecked = db.selectedsquadchecked.Find(id);
            if (selectedsquadchecked == null)
            {
                return HttpNotFound();
            }
            return View(selectedsquadchecked);
        }

        //
        // POST: /SelectedSquadChecked/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            selectedsquadchecked selectedsquadchecked = db.selectedsquadchecked.Find(id);
            db.selectedsquadchecked.Remove(selectedsquadchecked);
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