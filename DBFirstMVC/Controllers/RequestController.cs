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
            ViewBag.Modules = db.Modules; //this will be used as the list of modules
            var allRooms = from room in db.Rooms select room;  //same as SELECT * from Room

            var allFacilities = from fac in db.Facilities select fac; //same as SELECT * from Facility
            ViewBag.Facility = new SelectList(db.Facilities, "FacilityName", "FacilityName"); //Facility1 as the table name is Facility so the column name must be Facility1
            ViewBag.Park = new SelectList(db.Parks, "ParkName", "ParkName");
            return View(new CreateNewRequest() {Rooms = allRooms, Facilities = allFacilities});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRequest(CreateNewRequest myRequest, string[] facList, bool cbPriorityRequest = false, string Park = "")
        {
            bool validFacilities = true;
            if (cbPriorityRequest) //take boolean of checkbox and turn into 1 or 0
                myRequest.Request.PriorityRequest = 1;
            else
                myRequest.Request.PriorityRequest = 0;

              //set auto defined variables, these should be calculated later
              myRequest.Request.RoundID = 1;
              myRequest.Request.UserID = 1;
              myRequest.Request.Semester = 1;
              myRequest.Request.AdhocRequest = 0;
            
              //check any facilities have been chosen
              if(facList == null)
                  validFacilities = false;


              db.Requests.Add(myRequest.Request); //add the request to the table
              db.SaveChanges();
              int key = myRequest.Request.RequestID; //get the newly created key made for the new request

                if (validFacilities)
                {
                    FacilityRequest facilityRequest = new FacilityRequest(); //create a list of facilityRequest rows to add to the table
                    if (validFacilities == true)
                    {
                        for (var i = 0; i < facList.Length; i++) //loop through list of chosen facilities
                        {
                            string fac = facList[i]; //put facility into string so it can be used in LINQ
                            int id = (from d in db.Facilities
                                      where (d.FacilityName == fac)
                                      select d.FacilityID).SingleOrDefault();
                            //assign the values to the object
                            facilityRequest.FacilityID = id; 
                            facilityRequest.RequestID = key;
                            db.FacilityRequests.Add(facilityRequest); //add the facilityRequest to the table
                            db.SaveChanges();
                        }
                    }
                }
            
               
               
               return RedirectToAction("Index"); //redirect to the list of requests
        }




        //Function thats posted to which returns the list of buildings of a given park
        [HttpPost]
        public ActionResult GetBuildings(string chosenPark)
        {
            var b = from d in db.Buildings
                    where (d.ParkName == chosenPark.Substring(0, 1))
                    select d.BuildingName;

            return Json(b);
        }

        //Function thats posted to which returns the list of rooms of a given building
        [HttpPost]
        public ActionResult GetRooms(string chosenBuilding)
        {
            var rm = from d in db.Rooms
                    where (d.Building.BuildingName == chosenBuilding)
                    select d.RoomName;

            return Json(rm);
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