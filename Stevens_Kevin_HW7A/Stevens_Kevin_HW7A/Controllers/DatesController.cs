﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stevens_Kevin_HW7A.Models;

namespace Stevens_Kevin_HW7A.Controllers
{
    public class DatesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Dates
        public ActionResult Index()
        {
            return View(db.Dates.ToList());
        }

        // GET: Dates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // GET: Dates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuDayNumber,MenuDate,RecipeViewModelID")] Date date)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(date);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(date);
        }

        // GET: Dates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Dates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuDayNumber,MenuDate,RecipeViewModelID")] Date date)
        {
            if (ModelState.IsValid)
            {
                db.Entry(date).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(date);
        }

        // GET: Dates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Date date = db.Dates.Find(id);
            if (date == null)
            {
                return HttpNotFound();
            }
            return View(date);
        }

        // POST: Dates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Date date = db.Dates.Find(id);
            db.Dates.Remove(date);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
