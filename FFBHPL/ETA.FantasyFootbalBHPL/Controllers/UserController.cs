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
    public class UserController : Controller
    {
        private fantasyEntities db = new fantasyEntities();

        //
        // GET: /User/

        public ActionResult Index()
        {
            var user = db.user.Include(u => u.squad).Include(u => u.usergroup);
            return View(user.ToList());
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            ViewBag.idPlayersTeam1 = new SelectList(db.squad, "idPlayersTeam", "playersTeamName");
            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName");
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(user user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPlayersTeam1 = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", user.idPlayersTeam1);
            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName", user.UserGroup_idUserGroup);
            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPlayersTeam1 = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", user.idPlayersTeam1);
            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName", user.UserGroup_idUserGroup);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPlayersTeam1 = new SelectList(db.squad, "idPlayersTeam", "playersTeamName", user.idPlayersTeam1);
            ViewBag.UserGroup_idUserGroup = new SelectList(db.usergroup, "idUserGroup", "groupName", user.UserGroup_idUserGroup);
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            user user = db.user.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.user.Find(id);
            db.user.Remove(user);
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