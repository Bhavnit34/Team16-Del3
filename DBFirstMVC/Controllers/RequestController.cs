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
    public class RequestController : BaseController //Inherits our own overrided controller. Please see BaseController
    {
        private team16Entities db = new team16Entities();

        //
        // GET: /Request/

        public ActionResult Index()
        {
            ViewBag.CurrentUser = getCurrentUser();
            var requests = db.Requests.Include(r => r.Module);
            return View(requests.ToList());
        }

        //
        // GET: /Request/Details/5

        public ActionResult Details(int id = 0)
        {
            ViewBag.CurrentUser = getCurrentUser();
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        public ActionResult GetRequest(int id = 0)
        {
            ViewBag.CurrentUser = getCurrentUser();
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

            //ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "FullModule"); //Add list of modules to the view. It will referred to as ModCode
            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);
            ViewBag.CurrentUser = row.FullDept;

            ViewBag.Modules = db.Modules.Where(a => a.DeptCode.Equals(userSession.Username)); //this will be used as the list of modules

            List<SelectListItem> Period = new List<SelectListItem>();
            Period.Add(new SelectListItem{Text = "p1 - 9:00", Value = "1"});
            Period.Add(new SelectListItem{Text = "p2 - 10:00", Value = "2"});
            Period.Add(new SelectListItem{Text = "p3 - 11:00", Value = "3"});
            Period.Add(new SelectListItem{Text = "p4 - 12:00", Value = "4"});
            Period.Add(new SelectListItem{Text = "p5 - 13:00", Value = "5"});
            Period.Add(new SelectListItem{Text = "p6 - 14:00", Value = "6"});
            Period.Add(new SelectListItem{Text = "p7 - 15:00", Value = "7"});
            Period.Add(new SelectListItem{Text = "p8 - 16:00", Value = "8"});
            Period.Add(new SelectListItem{Text = "p9 - 17:00", Value = "9"});

            ViewBag.Periods = Period; //This will be passed into the view for the dropdownlist
            
            
            
            
            
            var allRooms = from room in db.Rooms select room;  //same as SELECT * from Room

            var allFacilities = from fac in db.Facilities select fac; //same as SELECT * from Facility
            ViewBag.Facility = new SelectList(db.Facilities, "FacilityName", "FacilityName"); //Facility1 as the table name is Facility so the column name must be Facility1
            ViewBag.Park = new SelectList(db.Parks, "ParkName", "ParkName");
            return View(new CreateNewRequest() {Rooms = allRooms, Facilities = allFacilities});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRequest(CreateNewRequest myRequest, string[] facList, string[] chosenRooms, bool cbPriorityRequest = false, string Park = "")
        {
            bool validFacilities = true;
            bool validRooms = true;
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

            //check any rooms have been chosen
            if (chosenRooms == null)
                validRooms = false;


              db.Requests.Add(myRequest.Request); //add the request to the table
              db.SaveChanges();
              int newRequestID = myRequest.Request.RequestID; //get the newly created key made for the new request

                //Add facility requests
                if (validFacilities)
                {
                    FacilityRequest facilityRequest = new FacilityRequest(); //create a list of facilityRequest rows to add to the table
                    if (validFacilities == true)
                    {
                        for (int i = 0; i < facList.Length; i++) //loop through list of chosen facilities
                        {
                            string fac = facList[i]; //put facility into string so it can be used in LINQ
                            int id = (from d in db.Facilities
                                      where (d.FacilityName == fac)
                                      select d.FacilityID).SingleOrDefault();
                            //assign the values to the object
                            facilityRequest.FacilityID = id; 
                            facilityRequest.RequestID = newRequestID;
                            db.FacilityRequests.Add(facilityRequest); //add the facilityRequest to the table
                            db.SaveChanges();
                        }
                    }
                }

                //Add room requests
                int newRoomRequestID = 0;
                if (validRooms)
                {
                    RequestToRoom requestToRoom = new RequestToRoom();
                    

                    for (int i = 0; i < chosenRooms.Length; i++)
                    {
                        //we must re-instantiate the roomRequest for each iteration to stop errors with the auto-primary-key function
                        RoomRequest roomRequest = new RoomRequest();
                        string room = chosenRooms[i];
                        roomRequest.RoomRequestID = 0;
                        roomRequest.GroupSize = 0;
                        roomRequest.PriorityRoom = 0;
                        roomRequest.RoomName = room;

                        //create RoomRequest row and add to table
                        db.RoomRequests.Add(roomRequest);
                        db.SaveChanges();
                        newRoomRequestID = roomRequest.RoomRequestID; //take the newly created ID

                        //create RequestToRoom row and add to table
                        requestToRoom.RequestID = newRequestID;
                        requestToRoom.RoomRequestID = newRoomRequestID; //this is the newly created ID from above
                        db.RequestToRooms.Add(requestToRoom);
                        db.SaveChanges();
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

        [HttpPost]
        public ActionResult GetModules(string searchString)
        {
            User userSession = (User)HttpContext.Session["User"]; //Use session to filter results to the user's dept.
            var modules = from d in db.Modules
                          where (((d.ModCode.Contains(searchString)) || (d.Title.Contains(searchString))) && (d.DeptCode.Equals(userSession.Username)))
                          select new { Whole = d.ModCode + " - " + d.Title};
            

            return Json(modules);
        }




        //
        // GET: /Request/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ViewBag.CurrentUser = getCurrentUser();
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
            ViewBag.CurrentUser = getCurrentUser();
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
            ViewBag.CurrentUser = getCurrentUser();
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

        private string getCurrentUser()
        {
            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);
            return(row.FullDept);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}