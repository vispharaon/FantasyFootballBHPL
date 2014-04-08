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
        

        //
        // GET: /User/

        public ActionResult Index()
        {
           
            return View();
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
                 return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(user user)
        {
           return View();
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
           return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(user user)
        {
            return View();
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
           return View();
        }

        protected override void Dispose(bool disposing)
        {
            
        }
    }
}