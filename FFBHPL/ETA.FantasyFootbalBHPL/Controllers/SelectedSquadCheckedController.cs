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
       

        //
        // GET: /SelectedSquadChecked/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SelectedSquadChecked/Details/5

        public ActionResult Details(int id = 0)
        {
            
            return View();
        }

        //
        // GET: /SelectedSquadChecked/Create

        public ActionResult Create()
        {
            
            return View();
        }

        //
        // POST: /SelectedSquadChecked/Create

        [HttpPost]
        public ActionResult Create(selectedsquadchecked selectedsquadchecked)
        {
            
            return View(selectedsquadchecked);
        }

        //
        // GET: /SelectedSquadChecked/Edit/5

        public ActionResult Edit(int id = 0)
        {
           
            
            return View();
        }

        //
        // POST: /SelectedSquadChecked/Edit/5

        [HttpPost]
        public ActionResult Edit(selectedsquadchecked selectedsquadchecked)
        {
            
            return View(selectedsquadchecked);
        }

        //
        // GET: /SelectedSquadChecked/Delete/5

        public ActionResult Delete(int id = 0)
        {
           
            return View();
        }

        //
        // POST: /SelectedSquadChecked/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
        }
    }
}