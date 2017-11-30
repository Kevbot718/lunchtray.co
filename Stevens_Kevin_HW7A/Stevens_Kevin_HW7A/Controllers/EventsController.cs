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

namespace Stevens_Kevin_HW7A.Controllers
{
    public class EventsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AllCommittees = GetAllCommittees();
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventTitle,EventDate,EventLocation,MembersOnly")] Event @event, Int32 CommitteeID)
        {
            //find selected committee
            Committee SelectedCommittee = db.Committees.Find(CommitteeID);

            //associate committee with event
            @event.Committee = SelectedCommittee;

            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllCommittees = GetAllCommittees(@event);
            return View(@event);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            //Add to viewbag
            ViewBag.AllCommittees = GetAllCommittees(@event);
            ViewBag.AllMembers = GetAllMembers(@event);

            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventTitle,EventDate,EventLocation,MembersOnly")] Event @event, Int32 CommitteeID, string[] SelectedMembers)
        {
            if (ModelState.IsValid)
            {

                //Find associated event
                Event eventToChange = db.Events.Find(@event.EventID);

                //change committee if necessary
                if (eventToChange.Committee.CommitteeID != CommitteeID)
                {
                    //find committee
                    Committee SelectedCommittee = db.Committees.Find(CommitteeID);

                    //update the committee
                    eventToChange.Committee = SelectedCommittee;
                }

                //change members
                //remove any existing members
                eventToChange.Users.Clear();

                //if there are members to add, add them
                if (SelectedMembers != null)
                {
                    foreach (string Id in SelectedMembers)
                    {
                        AppUser memberToAdd = db.Users.Find(Id);
                        eventToChange.Users.Add(memberToAdd);
                    }
                }

                //update the rest of the fields
                eventToChange.EventTitle = @event.EventTitle;
                eventToChange.EventDate = @event.EventDate;
                eventToChange.EventLocation = @event.EventLocation;
                eventToChange.MembersOnly = @event.MembersOnly;


                db.Entry(eventToChange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //re-populate lists
            //Add to viewbag
            ViewBag.AllCommittees = GetAllCommittees(@event);
            ViewBag.AllMembers = GetAllMembers(@event);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public SelectList GetAllCommittees(Event @event)  //COMMITTEE ALREADY CHOSEN
        {
            //populate list of committees
            var query = from c in db.Committees
                        orderby c.CommitteeName
                        select c;
            //create list and execute query
            List<Committee> allCommittees = query.ToList();

            //convert to select list
            SelectList list = new SelectList(allCommittees, "CommitteeID", "CommitteeName", @event.Committee.CommitteeID);
            return list;
        }

        public SelectList GetAllCommittees()  //NO COMMITTEE CHOOSEN
        {
            //create query to find all committees
            var query = from c in db.Committees
                        orderby c.CommitteeName
                        select c;
            //execute query and store in list
            List<Committee> allCommittees = query.ToList();

            //convert list to select list format needed for HTML
            SelectList allCommitteeslist = new SelectList(allCommittees, "CommitteeID", "CommitteeName");

            return allCommitteeslist;
        }

        public MultiSelectList GetAllMembers(Event @event)
        {
            //find the list of members
            var query = from m in db.Users
                        orderby m.Email
                        select m;
            //convert to list and execute query
            List<AppUser> allMembers = query.ToList();

            //create list of selected members
            List<string> SelectedMembers = new List<string>();

            //Loop through list of members and add MemberId
            foreach (AppUser m in @event.Users)
            {
                SelectedMembers.Add(m.Id);
            }

            //convert to multiselect
            MultiSelectList allMembersList = new MultiSelectList(allMembers, "Id", "Email", SelectedMembers);

            return allMembersList;
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
