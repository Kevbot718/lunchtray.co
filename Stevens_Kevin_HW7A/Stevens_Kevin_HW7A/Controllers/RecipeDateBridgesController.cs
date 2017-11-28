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
    public class RecipeDateBridgesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: RecipeDateBridges
        public ActionResult Index()
        {
            var recipeDateBridges = db.RecipeDateBridges.Include(r => r.Date).Include(r => r.RecipeViewModel);
            return View(recipeDateBridges.ToList());
        }

        // GET: RecipeDateBridges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeDateBridge recipeDateBridge = db.RecipeDateBridges.Find(id);
            if (recipeDateBridge == null)
            {
                return HttpNotFound();
            }
            return View(recipeDateBridge);
        }

        // GET: RecipeDateBridges/Create
        public ActionResult Create()
        {
            ViewBag.MenuNumber = new SelectList(db.Dates, "MenuNumber", "RecipeName");
            ViewBag.RecipeViewModelID = new SelectList(db.RecipeViewModels, "RecipeViewModelID", "RecipeName");
            return View();
        }

        // POST: RecipeDateBridges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RDB,MenuNumber,RecipeViewModelID,MenuDate")] RecipeDateBridge recipeDateBridge)
        {
            if (ModelState.IsValid)
            {
                db.RecipeDateBridges.Add(recipeDateBridge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuNumber = new SelectList(db.Dates, "MenuNumber", "RecipeName", recipeDateBridge.MenuNumber);
            ViewBag.RecipeViewModelID = new SelectList(db.RecipeViewModels, "RecipeViewModelID", "RecipeName", recipeDateBridge.RecipeViewModelID);
            return View(recipeDateBridge);
        }

        // GET: RecipeDateBridges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeDateBridge recipeDateBridge = db.RecipeDateBridges.Find(id);
            if (recipeDateBridge == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuNumber = new SelectList(db.Dates, "MenuNumber", "RecipeName", recipeDateBridge.MenuNumber);
            ViewBag.RecipeViewModelID = new SelectList(db.RecipeViewModels, "RecipeViewModelID", "RecipeName", recipeDateBridge.RecipeViewModelID);
            return View(recipeDateBridge);
        }

        // POST: RecipeDateBridges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RDB,MenuNumber,RecipeViewModelID,MenuDate")] RecipeDateBridge recipeDateBridge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeDateBridge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuNumber = new SelectList(db.Dates, "MenuNumber", "RecipeName", recipeDateBridge.MenuNumber);
            ViewBag.RecipeViewModelID = new SelectList(db.RecipeViewModels, "RecipeViewModelID", "RecipeName", recipeDateBridge.RecipeViewModelID);
            return View(recipeDateBridge);
        }

        // GET: RecipeDateBridges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeDateBridge recipeDateBridge = db.RecipeDateBridges.Find(id);
            if (recipeDateBridge == null)
            {
                return HttpNotFound();
            }
            return View(recipeDateBridge);
        }

        // POST: RecipeDateBridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeDateBridge recipeDateBridge = db.RecipeDateBridges.Find(id);
            db.RecipeDateBridges.Remove(recipeDateBridge);
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
