//Author: Kevin Stevens
//Date: April 14, 2017
//Assignment: Homework 7
//Description: Implement identity into expanded member tracker MVC website linked with entity framework

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stevens_Kevin_HW7A.Models;
using Microsoft.AspNet.Identity;

namespace Stevens_Kevin_HW7A.Controllers
{
    public class MembersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Members
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Members/Details/5
        [Authorize]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser member = db.Users.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,FirstName,LastName,Email,Phone,OKToText,Majors")] AppUser member)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser member = db.Users.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            //allow users to edit their own user info, but not others
            if (member.Id != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Login", "Account");
            }

            //Add to viewbag
            ViewBag.AllEvents = GetAllEvents(member);

            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,Email,PhoneNumber,OKToText,Major")] AppUser member, string[] SelectedEvents)
        {
            if (ModelState.IsValid)
            {
                //Find associated member
                AppUser memberToChange = db.Users.Find(member.Id);

                //change events
                //remove any existing events
                memberToChange.Events.Clear();

                //if there are members to add, add them
                if (SelectedEvents != null)
                {
                    foreach (string Id in SelectedEvents)
                    {
                        Event eventToAdd = db.Events.Find(Id);
                        memberToChange.Events.Add(eventToAdd);
                    }
                }

                ////update the rest of the fields
                memberToChange.FName = member.FName;
                memberToChange.LName = member.LName;
                memberToChange.Email = member.Email;
                memberToChange.PhoneNumber = member.PhoneNumber;
                memberToChange.OKToText = member.OKToText;
                memberToChange.Major = member.Major;

                db.Entry(memberToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //re-populate lists
            //Add to viewbag
            ViewBag.AllEvents = GetAllEvents(member);

            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppUser member = db.Users.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AppUser member = db.Users.Find(id);
            db.Users.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //define method
        public MultiSelectList GetAllEvents(AppUser member)
        {
            //find the list of events
            var query = from e in db.Events
                        orderby e.EventTitle
                        select e;
            //convert to list and execute query
            List<Event> allEvents = query.ToList();

            //create list of selected events
            List<Int32> SelectedEvents = new List<Int32>();

            //Loop through list of events and add EventId
            foreach (Event e in member.Events)
            {
                SelectedEvents.Add(e.EventID);
            }

            //convert to multiselect
            MultiSelectList allEventsList = new MultiSelectList(allEvents, "EventID", "EventTitle", SelectedEvents);

            return allEventsList;
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