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
        //show all the requests
        public ActionResult Index()
        {
            var requests = db.Requests.Include(r => r.Module);
            return View(requests.ToList());
        }


        //show the list of all rooms
        public ActionResult EditPool()
        {
            var rooms = db.Rooms.Include(r => r.Building);
            return View(rooms.ToList());
        }

        //show the list of all facilities
        public ActionResult ShowFacility()
        {
            var facilities = db.Facilities;
            return View(facilities.ToList());
        }




        //show selected facility
        public ActionResult EditFacility(int id = 0)
        {
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }

            return View(facility);
        }

        //save changes to facility
        [HttpPost]
        public ActionResult EditFacility(Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShowFacility");
            }

            return View(facility);
        }


        public ActionResult DeleteFacility(int id=0)
        {
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index");
            }
            return View(facility);
        }


        [HttpPost, ActionName("DeleteFacility")]
        public ActionResult DeleteConfirmed1(int id)
        {
            Facility facility = db.Facilities.Find(id);
            db.Facilities.Remove(facility);

            var fcltDelete = db.RoomFacilities.Where(a => a.FacilityID == id).ToList();
            foreach (var vp in fcltDelete)
            db.RoomFacilities.Remove(vp);
            
            
            
            
            db.SaveChanges();

            //var v = (db.Facilities.AsEnumerable().Where(a => a.FacilityID.Equals(id)));



            //foreach (var row in v.ToList())
          //  {
                
            ///}
           // var fcltDelete = db.RoomFacilities.Where(a => a.FacilityID== id).ToList();
            //foreach (var vp in fcltDelete)
               // db.RoomFacilities.Remove(vp);
           // db.SaveChanges();

            return RedirectToAction("ShowFacility");
        }

        // GET: /Admin/Details/5


        public ActionResult CreateFacility()
        {
          
            return View();
        }


        [HttpPost]

        public ActionResult CreateFacility(Facility facility)
        {

            if (ModelState.IsValid)
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
                return RedirectToAction("ShowFacility");
            }

            return View(facility);
        }

        
        
        //add new room
        public ActionResult Create()
        {
            // ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title");
            ViewBag.BuildingCode = new SelectList(db.Buildings, "BuildingCode", "BuildingName");
            // ViewBag.Building = new SelectList(db.Rooms, "BuildingCode"); add another create :)
            return View();
        }


        [HttpPost]

        public ActionResult Create(Room room)
        {
           
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildingCode = new SelectList(db.Buildings, "BuildingCode", "BuildingName");
            return View(room);
        }

           //get request deatails 
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
        //change request status 

        public ActionResult Edit(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }

            return View(request);
        }

        //
        // POST: /Admin/Edit/5
        //change request status
        [HttpPost]
        public ActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
   
            return View(request);
        }

        //
        // GET: /Admin/Delete/5
        //chabge room
        public ActionResult EditRoom(string id1)
        {
            Room room = db.Rooms.Find(id1);
            if (room == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index");
            }
            return View(room);
        }
        
        [HttpPost]
        public ActionResult EditRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EditPool");
            }

            return View(room);
        }


           //delete room

        public ActionResult Delete(string id1)
        {
            Room room = db.Rooms.Find(id1);
            if (room== null)
            {
                return HttpNotFound();
              // return RedirectToAction("Index");
            }
            return View(room);
        }

        //
        // POST: /Admin/Delete/5

       [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id1)
        {
            Room room = db.Rooms.Find(id1);
            db.Rooms.Remove(room);
            db.SaveChanges();
            return RedirectToAction("EditPool");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}