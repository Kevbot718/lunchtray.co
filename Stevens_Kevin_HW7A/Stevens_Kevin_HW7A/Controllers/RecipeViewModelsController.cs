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
    public class RecipeViewModelsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: RecipeViewModels
        public ActionResult Index()
        {
            return View(db.RecipeViewModels.ToList());
        }

        // GET: RecipeViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeViewModel recipeViewModel = db.RecipeViewModels.Find(id);
            if (recipeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(recipeViewModel);
        }

        // GET: RecipeViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeViewModelID,Name,IngredientName,MeasurementType,MeasurementQuantity,PrepTime,CookTime,TotalCost,Notes,InstructionText")] RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RecipeViewModels.Add(recipeViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipeViewModel);
        }

        // GET: RecipeViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeViewModel recipeViewModel = db.RecipeViewModels.Find(id);
            if (recipeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(recipeViewModel);
        }

        // POST: RecipeViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeViewModelID,Name,IngredientName,MeasurementType,MeasurementQuantity,PrepTime,CookTime,TotalCost,Notes,InstructionText")] RecipeViewModel recipeViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipeViewModel);
        }

        // GET: RecipeViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeViewModel recipeViewModel = db.RecipeViewModels.Find(id);
            if (recipeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(recipeViewModel);
        }

        // POST: RecipeViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeViewModel recipeViewModel = db.RecipeViewModels.Find(id);
            db.RecipeViewModels.Remove(recipeViewModel);
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
