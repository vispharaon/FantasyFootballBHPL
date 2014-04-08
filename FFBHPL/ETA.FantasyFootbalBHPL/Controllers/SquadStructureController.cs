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
    public class SquadStructureController : Controller
    {
       

        //
        // GET: /SquadStructure/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SquadStructure/Details/5

        public ActionResult Details(int id = 0)
        {
            return View();
        }

        //
        // GET: /SquadStructure/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SquadStructure/Create

        [HttpPost]
        public ActionResult Create(squadstructure squadstructure)
        {
            if (ModelState.IsValid)
            {
                return View();
            }

            return View(squadstructure);
        }

        //
        // GET: /SquadStructure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            return View();
        }

        //
        // POST: /SquadStructure/Edit/5

        [HttpPost]
        public ActionResult Edit(squadstructure squadstructure)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(squadstructure);
        }

        //
        // GET: /SquadStructure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            return View();
        }

        //
        // POST: /SquadStructure/Delete/5

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