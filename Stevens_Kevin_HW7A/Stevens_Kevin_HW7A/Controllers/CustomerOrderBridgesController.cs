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
    public class CustomerOrderBridgesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CustomerOrderBridges
        public ActionResult Index()
        {
            var customerOrderBridges = db.CustomerOrderBridges.Include(c => c.Customer).Include(c => c.Order);
            return View(customerOrderBridges.ToList());
        }

        // GET: CustomerOrderBridges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderBridge customerOrderBridge = db.CustomerOrderBridges.Find(id);
            if (customerOrderBridge == null)
            {
                return HttpNotFound();
            }
            return View(customerOrderBridge);
        }

        // GET: CustomerOrderBridges/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
            return View();
        }

        // POST: CustomerOrderBridges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,OrderID")] CustomerOrderBridge customerOrderBridge)
        {
            if (ModelState.IsValid)
            {
                db.CustomerOrderBridges.Add(customerOrderBridge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", customerOrderBridge.CustomerID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", customerOrderBridge.OrderID);
            return View(customerOrderBridge);
        }

        // GET: CustomerOrderBridges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderBridge customerOrderBridge = db.CustomerOrderBridges.Find(id);
            if (customerOrderBridge == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", customerOrderBridge.CustomerID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", customerOrderBridge.OrderID);
            return View(customerOrderBridge);
        }

        // POST: CustomerOrderBridges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,OrderID")] CustomerOrderBridge customerOrderBridge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerOrderBridge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", customerOrderBridge.CustomerID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", customerOrderBridge.OrderID);
            return View(customerOrderBridge);
        }

        // GET: CustomerOrderBridges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerOrderBridge customerOrderBridge = db.CustomerOrderBridges.Find(id);
            if (customerOrderBridge == null)
            {
                return HttpNotFound();
            }
            return View(customerOrderBridge);
        }

        // POST: CustomerOrderBridges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerOrderBridge customerOrderBridge = db.CustomerOrderBridges.Find(id);
            db.CustomerOrderBridges.Remove(customerOrderBridge);
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
