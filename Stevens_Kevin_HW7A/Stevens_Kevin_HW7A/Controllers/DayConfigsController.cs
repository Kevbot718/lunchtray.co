using System;
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
    public class DayConfigsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: DayConfigs
        public ActionResult Index()
        {
            var dayConfigs = db.DayConfigs.Include(d => d.Recipe);
            return View(dayConfigs.ToList());
        }

        // GET: DayConfigs/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayConfig dayConfig = db.DayConfigs.Find(id);
            if (dayConfig == null)
            {
                return HttpNotFound();
            }
            return View(dayConfig);
        }

        // GET: DayConfigs/Create
        public ActionResult Create()
        {
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName");
            return View();
        }

        // POST: DayConfigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,MenuType,RecipeID")] DayConfig dayConfig)
        {
            if (ModelState.IsValid)
            {
                db.DayConfigs.Add(dayConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", dayConfig.RecipeID);
            return View(dayConfig);
        }

        // GET: DayConfigs/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayConfig dayConfig = db.DayConfigs.Find(id);
            if (dayConfig == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", dayConfig.RecipeID);
            return View(dayConfig);
        }

        // POST: DayConfigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,MenuType,RecipeID")] DayConfig dayConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dayConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", dayConfig.RecipeID);
            return View(dayConfig);
        }

        // GET: DayConfigs/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DayConfig dayConfig = db.DayConfigs.Find(id);
            if (dayConfig == null)
            {
                return HttpNotFound();
            }
            return View(dayConfig);
        }

        // POST: DayConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            DayConfig dayConfig = db.DayConfigs.Find(id);
            db.DayConfigs.Remove(dayConfig);
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
