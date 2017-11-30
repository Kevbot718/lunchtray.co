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
    public class RecipeIngredientBridgesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: RecipeIngredientBridges
        public ActionResult Index()
        {
            var recipeIngredientBridges = db.RecipeIngredientBridges.Include(r => r.Ingredient).Include(r => r.Recipe);
            return View(recipeIngredientBridges.ToList());
        }

        // GET: RecipeIngredientBridges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredientBridge recipeIngredientBridge = db.RecipeIngredientBridges.Find(id);
            if (recipeIngredientBridge == null)
            {
                return HttpNotFound();
            }
            return View(recipeIngredientBridge);
        }

        // GET: RecipeIngredientBridges/Create
        public ActionResult Create()
        {
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName");
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName");
            return View();
        }

        // POST: RecipeIngredientBridges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,IngredientID,IngredientName,MeasurementType,MeasurementQuantity")] RecipeIngredientBridge recipeIngredientBridge)
        {
            if (ModelState.IsValid)
            {
                db.RecipeIngredientBridges.Add(recipeIngredientBridge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName", recipeIngredientBridge.IngredientID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", recipeIngredientBridge.RecipeID);
            return View(recipeIngredientBridge);
        }

        // GET: RecipeIngredientBridges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredientBridge recipeIngredientBridge = db.RecipeIngredientBridges.Find(id);
            if (recipeIngredientBridge == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName", recipeIngredientBridge.IngredientID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", recipeIngredientBridge.RecipeID);
            return View(recipeIngredientBridge);
        }

        // POST: RecipeIngredientBridges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,IngredientID,IngredientName,MeasurementType,MeasurementQuantity")] RecipeIngredientBridge recipeIngredientBridge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeIngredientBridge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientID = new SelectList(db.Ingredients, "IngredientID", "IngredientName", recipeIngredientBridge.IngredientID);
            ViewBag.RecipeID = new SelectList(db.Recipes, "RecipeID", "RecipeName", recipeIngredientBridge.RecipeID);
            return View(recipeIngredientBridge);
        }

        // GET: RecipeIngredientBridges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredientBridge recipeIngredientBridge = db.RecipeIngredientBridges.Find(id);
            if (recipeIngredientBridge == null)
            {
                return HttpNotFound();
            }
            return View(recipeIngredientBridge);
        }

        // POST: RecipeIngredientBridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeIngredientBridge recipeIngredientBridge = db.RecipeIngredientBridges.Find(id);
            db.RecipeIngredientBridges.Remove(recipeIngredientBridge);
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
