using DBFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstMVC.Controllers
{
    public class AdminController : Controller
    {
        private team16Entities db = new team16Entities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Module);
            return View(requests.ToList());
        }



        public ActionResult EditPool()
        {
            var rooms = db.Rooms.Include(r => r.Building);
            return View(rooms.ToList());
        }
        //
        // GET: /Admin/Details/5
        public ActionResult Create()
        {
            // ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title");
            ViewBag.BuildingCode = new SelectList(db.Buildings, "BuildingCode", "BuildingName");
            // ViewBag.Building = new SelectList(db.Rooms, "BuildingCode"); add another create :)
            return View();
        }




        public ActionResult GetRequest(int id = 0)
        {

            Request r = db.Requests.Find(id); //input id from chosen request
            if (r == null)
                return RedirectToAction("Index"); //back to home page if request doesnt exist

            var v = (db.FacilityRequests.Where(a => a.RequestID.Equals(r.RequestID)));
            var res = (db.RequestToRooms.Where(a => a.RequestID.Equals(r.RequestID)));
            if (v != null)
            {
                var facReq = v.Include(b => b.Facility); //add foreign key for facilityID
                var roomReq = res.Include(c => c.RoomRequest);
                return View(new RequestAndFacility() { Request = r, FacilityRequests = facReq, RequestToRooms = roomReq }); //return view with the data filled model
            }
            return View();
        }


        //


        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            // ViewBag.WeekID = new SelectList(db.Weeks, "WeekID", "WeekID", request.WeekID);
            return View(request);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            // ViewBag.WeekID = new SelectList(db.Weeks, "WeekID", "WeekID", request.WeekID);
            return View(request);
        }

        //
        // GET: /Admin/Delete/5

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
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
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