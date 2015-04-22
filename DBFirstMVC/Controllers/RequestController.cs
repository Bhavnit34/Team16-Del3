﻿using DBFirstMVC.Models;
using Newtonsoft.Json;
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

        public ActionResult DisplayRoomInfo(string id = "0", string rooms = "")
        {
            ViewBag.CurrentUser = getCurrentUser();
            Room room = db.Rooms.Find(id);

            return View(room);
        }

        public ActionResult BackToCreate()
        {
            return View();
        }

        public ActionResult GetRequest(int id = 0)
        {
            ViewBag.CurrentUser = getCurrentUser();
            Request r = db.Requests.Find(id); //input id from chosen request
            if (r == null)
                return RedirectToAction("Index"); //back to home page if request doesnt exist

            var v = (db.FacilityRequests.Where(a => a.RequestID.Equals(r.RequestID)));
            var res = (db.RequestToRooms.Where(a => a.RequestID.Equals(r.RequestID)));
            var wk = (from d in db.Weeks
                     where d.WeekID == r.WeekID
                     select d).FirstOrDefault();
            if (v != null)
            {
               var facReq = v.Include(b => b.Facility); //add foreign key for facilityID
               var roomReq = res.Include(c => c.RoomRequest);
               return View(new RequestInfo() { Request = r, FacilityRequests = facReq, RequestToRooms = roomReq, Week = wk }); //return view with the data filled model
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

            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);
            ViewBag.CurrentUser = row.FullDept;

            if (row.DeptCode == "CA")
                ViewBag.Modules = db.Modules; //this will be used as the list of modules
            else
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
            ViewBag.Facility = new SelectList(db.Facilities, "FacilityName", "FacilityName"); 
            ViewBag.Park = new SelectList(db.Parks, "ParkName", "ParkName");

            Request r = new Request();
            if (Session["State"] != null)
            {
                RequestState state = (RequestState)HttpContext.Session["State"];
                r = state.Request;
                string x = string.Join(",", state.Facilities.ToArray()); //add in facilities
                ViewBag.facList = x;
                string y =  string.Join(",", state.Rooms.ToArray()); //add in rooms
                ViewBag.roomList = y;
                string z = string.Join(",", state.Sizes.ToArray()); //add in sizes
                ViewBag.sizeList = z;

                ViewBag.PriorityRoomName = state.PriorityRoomName; //add the priority room choice

            }




            return View(new CreateNewRequest() {Rooms = allRooms, Facilities = allFacilities, Request = r});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRequest(CreateNewRequest myRequest, string Command, string[] facList, string[] chosenRooms, string[] groupSizes, bool[] pRooms, string selectedWeeks, bool cbPriorityRequest = false, string Park = "")
        {   
            bool validFacilities = true;
            bool validRooms = true;
            if (cbPriorityRequest) //take boolean of checkbox and turn into 1 or 0
                myRequest.Request.PriorityRequest = 1;
            else
                myRequest.Request.PriorityRequest = 0;

            //set auto defined variables, these should be calculated later
            myRequest.Request.RoundID = 1;
            User user = (User)Session["User"];
            myRequest.Request.UserID = user.UserID;
            myRequest.Request.Semester = 1;
            myRequest.Request.AdhocRequest = 0;
               
            //take in the string array of weeks and add it to the week table (if it doesnt already exist)
            List<string> weeks = new List<string>();
            if(selectedWeeks.Contains(','))
                weeks = selectedWeeks.Split(',').ToList<string>();
            else
                weeks.Add(selectedWeeks);
            Week week = new Week();

            for (var i = 0; i < weeks.Count; i++)
            {
                byte chosenWeek = Convert.ToByte(weeks[i]);
                switch (chosenWeek)
                {
                    case 1: week.Week1 = 1;
                        continue;
                    case 2: week.Week2 = 1;
                        continue;
                    case 3: week.Week3 = 1;
                        continue;
                    case 4: week.Week4 = 1;
                        continue;
                    case 5: week.Week5 = 1;
                        continue;
                    case 6: week.Week6 = 1;
                        continue;
                    case 7: week.Week7 = 1;
                        continue;
                    case 8: week.Week8 = 1;
                        continue;
                    case 9: week.Week9 = 1;
                        continue;
                    case 10: week.Week10 = 1;
                        continue;
                    case 11: week.Week11 = 1;
                        continue;
                    case 12: week.Week12 = 1;
                        continue;
                    case 13: week.Week13 = 1;
                        continue;
                    case 14: week.Week14 = 1;
                        continue;
                    case 15: week.Week15 = 1;
                        continue;
                }
                    
            }
            //long winded but only way to make all null weeks into a 0
            if (week.Week1 == null)
                week.Week1 = 0;
            if (week.Week2 == null)
                week.Week2 = 0;
            if (week.Week3 == null)
                week.Week3 = 0;
            if (week.Week4 == null)
                week.Week4 = 0;
            if (week.Week5 == null)
                week.Week5 = 0;
            if (week.Week6 == null)
                week.Week6 = 0;
            if (week.Week7 == null)
                week.Week7 = 0;
            if (week.Week8 == null)
                week.Week8 = 0;
            if (week.Week9 == null)
                week.Week9 = 0;
            if (week.Week10 == null)
                week.Week10 = 0;
            if (week.Week11 == null)
                week.Week11 = 0;
            if (week.Week12 == null)
                week.Week12 = 0;
            if (week.Week13 == null)
                week.Week13 = 0;
            if (week.Week14 == null)
                week.Week14 = 0;
            if (week.Week15 == null)
                week.Week15 = 0;

            var q = db.Weeks.Where(w => (w.Week1 == week.Week1) && (w.Week2 == week.Week2) && (w.Week3 == week.Week3) && (w.Week4 == week.Week4) && (w.Week5 == week.Week5) && (w.Week6 == week.Week6) && (w.Week7 == week.Week7) && (w.Week8 == week.Week8) && (w.Week9 == week.Week9) && (w.Week10 == week.Week10) && (w.Week11 == week.Week11) && (w.Week12 == week.Week12) && (w.Week13) == (week.Week13) && (w.Week14 == week.Week14) && (w.Week15 == week.Week15)).FirstOrDefault();
            var newWeek = true;
            if (q != null)
            {
                week.WeekID = q.WeekID;
                newWeek = false;
            }
            if (newWeek)
            {
                db.Weeks.Add(week);
                db.SaveChanges();
            }
            int weekID = week.WeekID;
            myRequest.Request.WeekID = weekID;
           
       
            
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

                    //pRooms will be false if unchecked, and true + false if checked, so we must try to take out only the correct bool values
                    List<bool> pRoomsNew = new List<bool>();
                    for (var i = 0; i < pRooms.Length; i++)
                    {
                        if (i == 0)
                        {
                            pRoomsNew.Add(pRooms[0]);
                            continue;
                        }

                        if ((i > 0) && (pRooms[i - 1] == false))
                            pRoomsNew.Add(pRooms[i]);

                        if ((i > 0) && (pRooms[i - 1] == true))
                            continue;

                    }
                    //here pRoomsNew is now the correct array of bool values

                    for (int i = 0; i < chosenRooms.Length; i++)
                    {
                        //we must re-instantiate the roomRequest for each iteration to stop errors with the auto-primary-key function
                        RoomRequest roomRequest = new RoomRequest();
                        string room = chosenRooms[i];
                        short size = Int16.Parse(groupSizes[i]); //groupSize is declared short in the table                       

                        roomRequest.RoomRequestID = 0;
                        roomRequest.GroupSize = size;
                        roomRequest.PriorityRoom = Convert.ToByte(pRoomsNew[i]);
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

        //Function to update the Module list based off the user search string
        [HttpPost]
        public ActionResult GetModules(string searchString)
        {
            User userSession = (User)HttpContext.Session["User"]; //Use session to filter results to the user's dept.
            var modules = from d in db.Modules
                          where (((d.ModCode.Contains(searchString)) || (d.Title.Contains(searchString))) && (d.DeptCode.Equals(userSession.Username)))
                          select new { Whole = d.ModCode + " - " + d.Title};

            if (userSession.Username == "CA")
            {
                modules = from d in db.Modules
                              where ((d.ModCode.Contains(searchString)) || (d.Title.Contains(searchString)))
                              select new { Whole = d.ModCode + " - " + d.Title };
            }


            return Json(modules);
        }

        //function to return a list of rooms that contain all of the chosen facilities
        [HttpPost]
        public ActionResult getMatchedRooms(string facList)
        {
            string[] facs = facList.Split(','); //turn string concatenated facilities into an array
           
            //Query to return all rooms that have at least one of the given facilities
            var room= from d in db.RoomFacilities
                       where (facs.Any(fac => d.Facility.FacilityName.Equals(fac)))
                       select d;
            var len = facs.Length;

            /*query to group the rows by RoomName and then take only the rooms that have appeared the same no
            of times as the no of facilities in the array, thus taking rooms that contain all of the facilities
             */ 
            var q = room.GroupBy(n => n.RoomName).
                    Select(g => new
                    {
                        Name = g.Key,
                        Count = g.Count()
                    }).Where(g => g.Count == len);


            return Json(q);
        }

        //function to return the no of students of a module
        public ActionResult getModuleStudents(string modCode)
        {
            var students = from d in db.Modules
                           where (d.ModCode == modCode)
                           select d.Students;

            return Json(students);
        }

        //function to return the no of students of a module
        public ActionResult getModuleLecturers(string modCode)
        {
            var lecturers = from d in db.ModuleLecturers
                            where (d.ModCode == modCode)
                            select new { Whole = d.Lecturer.FirstName + " " + d.Lecturer.LastName };
                           

            return Json(lecturers);
        }

        //function to return the capacity of a room
        public ActionResult getRoomSize(string roomName)
        {
            var size = from d in db.Rooms
                       where (d.RoomName == roomName)
                       select d.Capacity;

            return Json(size);
        }


        //Function to save the information on the request page into a session, to be reloaded when neccessary
        [HttpPost]
        public void SaveState(Request r, string Fac, string selectedWeeks, string SelectedRoom, string Rooms, string Sizes, string PriorityRoomName)
        {
            RequestState state = new RequestState();
            state.Request = r;
            state.Facilities = Fac.Split(',').ToList<string>();
            state.Weeks = selectedWeeks.Split(',').ToList<string>();
            state.Rooms = Rooms.Split(',').ToList<string>();
            state.Sizes = Sizes.Split(',').ToList<string>();
            state.PriorityRoomName = PriorityRoomName;
            Session["State"] = state; //save session
            DisplayRoomInfo(SelectedRoom);
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
            //Delete any associated room requests
            var ReqToRooms = (from d in db.RequestToRooms
                                  where d.RequestID == id
                                  select d).ToList();

            for (var i = 0; i < ReqToRooms.Count; i++)
            {
                //take each roomRequestID
                var rID = ReqToRooms[i].RoomRequestID;
                //find the row in the RequestToRoom table and delete it
                RequestToRoom row = db.RequestToRooms.Where(a => a.RoomRequestID.Equals(rID)).FirstOrDefault();
                db.RequestToRooms.Remove(row);
                db.SaveChanges();
                //find the row in the RooomRequest table and delete it
                RoomRequest RoomRow = db.RoomRequests.Where(a => a.RoomRequestID.Equals(rID)).FirstOrDefault();
                db.RoomRequests.Remove(RoomRow);
                db.SaveChanges();
            } 

            //Delete any associated facility requests
            var FacilityRequests = (from d in db.FacilityRequests
                                    where d.RequestID.Equals(id)
                                    select d).ToList();

            for (var i = 0; i < FacilityRequests.Count; i++)
            {
                //find id of the row with the given requestID
                var fID = FacilityRequests[i].FacilityRequestID;
                FacilityRequest fac = db.FacilityRequests.Find(fID);
                //delete the row
                db.FacilityRequests.Remove(fac);
                db.SaveChanges();
            }


            //Remove the Request row
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