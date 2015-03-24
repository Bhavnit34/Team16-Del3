using DBFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DBFirstMVC.Controllers
{
    public class RequestController : Controller
    {
        private team16Entities db = new team16Entities();

        //
        // GET: /Request/

        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Module);
            return View(requests.ToList());
        }

        //
        // GET: /Request/Details/5

        public ActionResult Details(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        public ActionResult GetRequest(int id = 0)
        {
    
            Request r = db.Requests.Find(id); //input id from chosen request
            if (r == null)
                return RedirectToAction("Index"); //back to home page if request doesnt exist

            var v = (db.FacilityRequests.Where(a => a.RequestID.Equals(r.RequestID)));
            if (v != null)
            {
               var results = v.Include(b => b.Facility); //add foreign key for facilityID
               return View(new RequestAndFacility() { Request = r, FacilityRequests = results }); //return view with the data filled model
            }
            return View();
        }



        //
        // GET: /Request/Create

        public ActionResult Create()
        {
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title");
            return View();
        }

        //
        // POST: /Request/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Request request, bool cbPriorityRequest)
        {
            if (cbPriorityRequest) //take boolean of checkbox and turn into 1 or 0
                request.PriorityRequest = 1;
            else
                request.PriorityRequest = 0;

            request.RoundID = 1;
            request.UserID = 1;
            request.Semester = 1;
            request.AdhocRequest = 0;

            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            return View(request);
        }

        public ActionResult CreateNew()
        {
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title"); //Add list of modules to the view. It will referred to as ModCode
            var allRooms = from room in db.Rooms select room;  //same as SELECT * from Room

            var allFacilities = from fac in db.Facilities select fac; //same as SELECT * from Facility
            ViewBag.Facility = new SelectList(db.Facilities, "FacilityName", "FacilityName"); //Facility1 as the table name is Facility so the column name must be Facility1
            ViewBag.Park = new SelectList(db.Parks, "ParkName", "ParkName");

            return View(new CreateNewRequest() {Rooms = allRooms, Facilities = allFacilities});
        }

        public ActionResult GetBuildings()
        {
           return RedirectToAction("CreateNew");
        }

        [HttpPost]
        public ActionResult GetBuildings(string chosenPark)
        {
            var v = db.Buildings.Where(p => p.Park.Buildings.Equals(chosenPark)); 
            ViewBag.Building = new SelectList(v, "BuildingName", "BuildingName");

            return RedirectToAction("CreateNew");
        }








        //
        // GET: /Request/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            return View(request);
        }

        //
        // POST: /Request/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            return View(request);
        }

        //
        // GET: /Request/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        //
        // POST: /Request/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}