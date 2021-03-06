﻿using DBFirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.Objects.SqlClient;

namespace DBFirstMVC.Controllers
{
    public class AdminController : BaseController
    {
        private team16Entities db = new team16Entities();


        public ActionResult Index(string sortOrder, string yearSelect, string searchString, int? page, string statusFilter, string roundFilter, string typeFilter, string semesterFilter, string priorityFilter)
        {        

            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
       
            User userSession = (User)HttpContext.Session["User"]; //This is needed to find the current user

            //These alternate sort parameter for switch statement
            ViewBag.StatusSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : ""; //default sort method
            ViewBag.TitleSortParm = sortOrder == "title" ? "title_desc" : "title";
            ViewBag.UserSortParm = sortOrder == "user" ? "user_desc" : "user";
            ViewBag.LengthSortParm = sortOrder == "length" ? "length_desc" : "length";
            ViewBag.DaySortParm = sortOrder == "day" ? "day_desc" : "day";
            ViewBag.SemesterSortParm = sortOrder == "semester" ? "semester_desc" : "semester";
            ViewBag.RoundSortParm = sortOrder == "round" ? "round_desc" : "round";
            ViewBag.TypeSortParm = sortOrder == "type" ? "type_desc" : "type";
            ViewBag.PrioritySortParm = sortOrder == "priority" ? "priority_desc" : "priority";
            ViewBag.AdhocSortParm = sortOrder == "adhoc" ? "adhoc_desc" : "adhoc";
            ViewBag.PeriodSortParm = sortOrder == "period" ? "period_desc" : "period";

            //alternates year parameter for switch statement
            //ViewBag.YearFilter = String.IsNullOrEmpty(yearSelect) ? "past" : "";

            var requests = from r in db.Requests
                           where r.UserID == userSession.UserID
                           select r; ;

            //if central admin
            if (userSession.UserID == 0)
            {
                requests = (from r in db.Requests
                            select r); ;
            }

            //add the search string to the query
            if (!String.IsNullOrEmpty(searchString))
            {
                requests = requests.Where(s => s.Module.Title.Contains(searchString)
                                       || s.Module.ModCode.Contains(searchString)
                                       || SqlFunctions.StringConvert((double)s.RequestID).Contains(searchString));
            }

            //finds the current academic year
            DateTime current = DateTime.Now;
            string year = current.Year + "/" + (current.Year - 1999);

            if (current.Month >= 1 && current.Month <= 6)
            {
                year = (current.Year - 1) + "/" + (current.Year - 2000);
            }

            //alternates year between current academic year and all past years
            switch (yearSelect)
            {
                case "past":
                    requests = requests.Where(r => r.Year != year);
                    break;
                default:
                    requests = requests.Where(r => r.Year == year);
                    break;
            }

            //applies status filter to query
            switch (statusFilter)
            {
                case "approved":
                    requests = requests.Where(r => r.Status == "1");
                    break;
                case "denied":
                    requests = requests.Where(r => r.Status == "2");
                    break;
                case "pending":
                    requests = requests.Where(r => r.Status == "0");
                    break;
                case "modified":
                    requests = requests.Where(r => r.Status == "3");
                    break;
                default:

                    break;
            }
            //applies type filter to query
            switch (typeFilter)
            {
                case "1":
                    requests = requests.Where(r => r.SessionType == "Lecture");
                    break;
                case "2":
                    requests = requests.Where(r => r.SessionType == "Tutorial");
                    break;
                default:
                    break;
            }

            switch (semesterFilter)
            {
                case "1":
                    requests = requests.Where(r => r.Semester == 1);
                    break;
                case "2":
                    requests = requests.Where(r => r.Semester == 2);
                    break;
                default:
                    break;
            }

            switch (priorityFilter)
            {
                case "true":
                    requests = requests.Where(r => r.PriorityRequest == 1);
                    break;
                default:

                    break;
            }

            switch (roundFilter)
            {
                case "1":
                    requests = requests.Where(r => r.RoundID == 1);
                    break;
                case "2":
                    requests = requests.Where(r => r.RoundID == 2);
                    break;
                case "3":
                    requests = requests.Where(r => r.RoundID == 3);
                    break;
                case "4":
                    requests = requests.Where(r => r.RoundID == 4);
                    break;
                case "5":
                    requests = requests.Where(r => r.RoundID == 5);
                    break;
                case "6":
                    requests = requests.Where(r => r.RoundID == 6);
                    break;
                default:

                    break;
            }

            //handles which sort method to use
            switch (sortOrder)
            {
                case "title":
                    requests = requests.OrderBy(r => r.Module.Title);
                    break;
                case "title_desc":
                    requests = requests.OrderByDescending(r => r.Module.Title);
                    break;
                case "user":
                    requests = requests.OrderBy(r => r.User.Username);
                    break;
                case "user_desc":
                    requests = requests.OrderByDescending(r => r.User.Username);
                    break;
                case "length":
                    requests = requests.OrderBy(r => r.SessionLength);
                    break;
                case "length_desc":
                    requests = requests.OrderByDescending(r => r.SessionLength);
                    break;
                case "day":
                    requests = requests.OrderBy(r => r.DayID);
                    break;
                case "day_desc":
                    requests = requests.OrderByDescending(r => r.DayID);
                    break;
                case "semester":
                    requests = requests.OrderBy(r => r.Semester);
                    break;
                case "semester_desc":
                    requests = requests.OrderByDescending(r => r.Semester);
                    break;
                case "status_desc":
                    requests = requests.OrderByDescending(r => r.Status);
                    break;
                case "round":
                    requests = requests.OrderBy(r => r.RoundID);
                    break;
                case "round_desc":
                    requests = requests.OrderByDescending(r => r.RoundID);
                    break;
                case "type":
                    requests = requests.OrderBy(r => r.SessionType);
                    break;
                case "type_desc":
                    requests = requests.OrderByDescending(r => r.SessionType);
                    break;
                case "adhoc":
                    requests = requests.OrderBy(r => r.AdhocRequest);
                    break;
                case "adhoc_desc":
                    requests = requests.OrderByDescending(r => r.AdhocRequest);
                    break;
                case "priority":
                    requests = requests.OrderBy(r => r.PriorityRequest);
                    break;
                case "priority_desc":
                    requests = requests.OrderByDescending(r => r.PriorityRequest);
                    break;
                case "period":
                    requests = requests.OrderBy(r => r.PeriodID);
                    break;
                case "period_desc":
                    requests = requests.OrderByDescending(r => r.PeriodID);
                    break;

                default:
                    requests = requests.OrderBy(r => r.Status);
                    break;
            }
            
            var pageSize = 10;

            if ((statusFilter == "" && roundFilter == "" && typeFilter == "" && semesterFilter == "" && searchString == "") || (statusFilter == null))
            {
                pageSize = 10;
            }
            else {
                pageSize = requests.Count();
                if (pageSize < 1)
                    pageSize = 1;
            }
                //creates the page for the view
                var requestPage = requests.ToPagedList(pageIndex, pageSize);

                ViewBag.Page = requestPage;

                return View();
            
           
        }


        //show the list of all rooms . filtered
        public ActionResult EditPool(string sortOrder)
        {

            ViewBag.RoomSortParm = sortOrder == "room" ? "room_desc" : "room";
            ViewBag.BuildingSortParm = sortOrder == "building" ? "building_desc" : "building";
            ViewBag.CapacitySortParm = sortOrder == "capacity" ? "capacity_desc" : "capacity";
            ViewBag.LabSortParm = sortOrder == "lab" ? "lab_desc" : "lab";
            ViewBag.DeptSortParm = sortOrder == "dept" ? "dept_desc" : "dept";
            ViewBag.ParkSortParm = sortOrder == "park" ? "park_desc" : "park";
            var rooms = db.Rooms.Include(r => r.Building);

            switch (sortOrder)
            {
                case "room_desc":
                    rooms = rooms.OrderByDescending(r => r.RoomName);
                    break;
                case "room":
                    rooms = rooms.OrderBy(r => r.RoomName);
                    break;
                case "building_desc":
                    rooms = rooms.OrderByDescending(r => r.Building.BuildingName);
                    break;
                case "building":
                    rooms = rooms.OrderBy(r => r.Building.BuildingName);
                    break;
                case "capacity_desc":
                    rooms = rooms.OrderByDescending(r => r.Capacity);
                    break;
                case "capacity":
                    rooms = rooms.OrderBy(r => r.Capacity);
                    break;
                case "lab_desc":
                    rooms = rooms.OrderByDescending(r => r.Lab);
                    break;
                case "lab":
                    rooms = rooms.OrderBy(r => r.Lab);
                    break;
                case "dept_desc":
                    rooms = rooms.OrderByDescending(r => r.DeptCode);
                    break;
                case "dept":
                    rooms = rooms.OrderBy(r => r.DeptCode);
                    break;
                case "park_desc":
                    rooms = rooms.OrderByDescending(r => r.Building.ParkName);
                    break;
                case "park":
                    rooms = rooms.OrderBy(r => r.Building.ParkName);
                    break;
            }
            return View(rooms.ToList());
        }

        //show the list of all facilities
        public ActionResult ShowFacility()
        {
            var facilities = db.Facilities;
            return View(facilities.ToList());
        }
        //show facilities for a particular room (dynamically updated)
        public ActionResult ShowRoomFacility()
        {
            ViewBag.CurrentUser = getCurrentUser();
            ViewBag.BuildingCode = new SelectList(db.Buildings, "BuildingCode", "BuildingName");
            return View();
        }


        //get rooms in a particular building 



        [HttpPost]
        public ActionResult GetRooms(string chosenBuilding)
        {
            var rm = from d in db.Rooms
                     where (d.BuildingCode == chosenBuilding)
                     select d.RoomName;

            return Json(rm);
        }

        //get facilities for a particular room
        [HttpPost]
        public ActionResult GetFacility(string chosenRoom)
        {
            var rm = from d in db.RoomFacilities
                     where (d.RoomName == chosenRoom)
                     select d.Facility.FacilityName;

            return Json(rm);
        }

        //get all facilities from facility table. 
        [HttpPost]
        public ActionResult GetAllFacility()
        {
            var rm = from d in db.Facilities

                     select d.FacilityName;

            return Json(rm);


        }
        //Get all parks
        [HttpPost]
        public ActionResult GetPark()
        {
            var rm = from d in db.Parks

                     select d.ParkName;

            return Json(rm);


        }

        [HttpPost]
        public ActionResult CheckRooms(string id)
        {
            string[] Splittedwords = id.Split(new string[] { "?" }, System.StringSplitOptions.None);

            List<string> list = new List<string>();
            for (var i = 0; i < Splittedwords.Length; i = i + 2)
            {
                string temp = Splittedwords[i];
                var temp1 = Convert.ToInt16(Splittedwords[i + 1]);
                bool roomExit = db.Rooms.Any(o => o.RoomName == temp);
                bool capacity = db.Rooms.Any(o => o.RoomName == temp && o.Capacity >= temp1);

                if (!roomExit || !capacity)
                {
                    list.Add(Splittedwords[i]);
                }

            }

            string[] result = list.ToArray();



            return Json(result);

            
        }
        //assign room allocations for a particular room 
        [HttpPost]
        public ActionResult UpdateAllocations(int id1, string id2)
        {
            //array with assigned rooms 
            string[] Splittedwords = id2.Split(new string[] { "?" }, System.StringSplitOptions.None);
            // find RoomRequestID 
            var t = (from d in db.AllocatedRooms
                     where (d.RequestID == id1)
                     select d.AllocatedRoomID).ToList();

            var numberOfRooms = 0;//how many rooms are already allocated
            foreach (var item in t)
            {
                numberOfRooms++;
            }

            Request isModified = db.Requests.Find(id1);





            // If AllocatedRoomID  does not exists => new allocation
            if (!t.Any())
            {

                // int newRoomRequestID = 0;
                for (var y = 0; y < Splittedwords.Length; y++)
                {


                    //we must re-instantiate the roomRequest for each iteration to stop errors with the auto-primary-key function
                    AllocatedRoom roomRequest = new AllocatedRoom();
                    string room = Splittedwords[y];
                    roomRequest.AllocatedRoomID = 0;
                    roomRequest.RequestID = id1;
                    roomRequest.GroupSize = Int16.Parse(Splittedwords[y + 1]);
                    roomRequest.Comments = "";
                    roomRequest.RoomName = room;

                    db.AllocatedRooms.Add(roomRequest);
                    db.SaveChanges();
                    y++;


                    //find clashes.is room free? if not then change the status of the request (with that room) to pending
                    //systems assumes there can be only one clash at particular time make sure there are no more than one clashes..
                    var findClashes = (from clash in db.Requests
                                       join aloc in db.AllocatedRooms on clash.RequestID equals aloc.RequestID
                                       where clash.DayID == isModified.DayID && clash.PeriodID == isModified.PeriodID && clash.WeekID == isModified.WeekID &&
                                           aloc.RoomName == room && (clash.Status == "3" || clash.Status == "1")

                                       select clash.RequestID).FirstOrDefault();



                    if (findClashes != 0)
                    {


                        var obj = db.Requests.Where(c => c.RequestID == findClashes).First();
                        obj.Status = "0";
                        db.SaveChanges();
                        //break;



                    }




                }
            }

            else if (numberOfRooms == (Splittedwords.Length) / 2)// if number of allocated rooms is equal to these that are going to be allocated
            {//change/update room alocations 
                int i = 0;
                foreach (var item in t)
                {
                    var temp = Splittedwords[i];

                    var findClashes = (from clash in db.Requests
                                       join aloc in db.AllocatedRooms on clash.RequestID equals aloc.RequestID
                                       where clash.DayID == isModified.DayID && clash.PeriodID == isModified.PeriodID && clash.WeekID == isModified.WeekID &&
                                           aloc.RoomName == temp && (clash.Status == "3" || clash.Status == "1")

                                       select clash.RequestID).FirstOrDefault();




                    if (findClashes != 0)
                    {


                        var obj = db.Requests.Where(c => c.RequestID == findClashes).First();
                        obj.Status = "0";
                        db.SaveChanges();
                        // break;



                    }

                    var roomRequest = new AllocatedRoom() { AllocatedRoomID = item, RoomName = Splittedwords[i], GroupSize = Int16.Parse(Splittedwords[i + 1]) };
                    db.AllocatedRooms.Attach(roomRequest);
                    db.Entry(roomRequest).Property(x => x.RoomName).IsModified = true;
                    db.Entry(roomRequest).Property(x => x.GroupSize).IsModified = true;
                    db.SaveChanges();



                    i = i + 2;

                }
                //change request status to modified


            }
            else
            {
                if ((numberOfRooms > (Splittedwords.Length) / 2))
                { //the number allocated rooms > than these that are going to be allocated



                    int check = 0;
                    int i = 0;
                    int deleteRequest = 0;
                    foreach (var item in t)
                    {
                        var temp = Splittedwords[i];

                        var findClashes = (from clash in db.Requests
                                           join aloc in db.AllocatedRooms on clash.RequestID equals aloc.RequestID
                                           where clash.DayID == isModified.DayID && clash.PeriodID == isModified.PeriodID && clash.WeekID == isModified.WeekID &&
                                               aloc.RoomName == temp && (clash.Status == "3" || clash.Status == "1")

                                           select clash.RequestID).FirstOrDefault();




                        if (findClashes != 0)
                        {


                            var obj = db.Requests.Where(c => c.RequestID == findClashes).First();
                            obj.Status = "0";
                            db.SaveChanges();
                            // break;



                        }


                        //update changes 
                        var roomRequest = new AllocatedRoom() { AllocatedRoomID = item, RoomName = Splittedwords[i], GroupSize = Int16.Parse(Splittedwords[i + 1]) };
                        db.AllocatedRooms.Attach(roomRequest);
                        db.Entry(roomRequest).Property(x => x.RoomName).IsModified = true;
                        db.Entry(roomRequest).Property(x => x.GroupSize).IsModified = true;
                        db.SaveChanges();

                        i = i + 2;
                        check++;
                        if (check == (Splittedwords.Length) / 2)
                            deleteRequest = item;//assign AllocatedRoomID to deleteRequest this is the last updated Room we need to delete the  AllocatedRoomID
                        break;



                    }



                    //remove outstanding requests from AllocateRoom table with same RequestID
                    var query = db.AllocatedRooms.Where(a => a.RequestID == id1 && a.AllocatedRoomID > deleteRequest).ToList();

                    for (var s = 0; s < query.Count; s++)
                    {
                        //find id of the row with the given requestID
                        var myId = query[s].AllocatedRoomID;
                        AllocatedRoom myRoom = db.AllocatedRooms.Find(myId);
                        //delete the row
                        db.AllocatedRooms.Remove(myRoom);
                        db.SaveChanges();
                    }




                }

                else
                { //if number of rooms that are being allocated is bigger than the number of allocated rooms in AllocatedRooms table

                    int i = 0;//update the rooms in the table if needed
                    int indexToRemove = 0;
                    foreach (var item in t)
                    {

                        var temp = Splittedwords[i];

                        var findClashes = (from clash in db.Requests
                                           join aloc in db.AllocatedRooms on clash.RequestID equals aloc.RequestID
                                           where clash.DayID == isModified.DayID && clash.PeriodID == isModified.PeriodID && clash.WeekID == isModified.WeekID &&
                                               aloc.RoomName == temp && (clash.Status == "3" || clash.Status == "1")

                                           select clash.RequestID).FirstOrDefault();




                        if (findClashes != 0)
                        {


                            var obj = db.Requests.Where(c => c.RequestID == findClashes).First();
                            obj.Status = "0";
                            db.SaveChanges();
                            // break;



                        }

                        var roomRequest = new AllocatedRoom() { AllocatedRoomID = item, RoomName = Splittedwords[i], GroupSize = Int16.Parse(Splittedwords[i + 1]) };
                        db.AllocatedRooms.Attach(roomRequest);
                        db.Entry(roomRequest).Property(x => x.RoomName).IsModified = true;
                        db.Entry(roomRequest).Property(x => x.GroupSize).IsModified = true;
                        db.SaveChanges();

                        i = i + 2;

                        Splittedwords = Splittedwords.Where((source, index) => index != indexToRemove).ToArray();//take out the room from array that has been already updated
                        //indexToRemove++;
                        Splittedwords = Splittedwords.Where((source, index) => index != indexToRemove).ToArray();//take out the groupSize from array that has been already updated
                        // indexToRemove = 0;
                    }

                    for (var y = 0; y < Splittedwords.Length; y++)//add new rooms AllocatedRoom table
                    {


                        AllocatedRoom roomRequest = new AllocatedRoom();
                        string room = Splittedwords[y];
                        roomRequest.AllocatedRoomID = 0;
                        roomRequest.RequestID = id1;
                        roomRequest.GroupSize = Int16.Parse(Splittedwords[y + 1]);
                        roomRequest.Comments = "";
                        roomRequest.RoomName = room;

                        db.AllocatedRooms.Add(roomRequest);
                        db.SaveChanges();
                        y++;

                    }
                }



            }
            int RoomsAreSame = 0; //chceck if rooms allocated are the same as requested
            var roomPreference = (from a in db.RequestToRooms where a.RequestID == id1 select a.RoomRequestID).ToList();
            if (!roomPreference.Any())
            {//igf there are no rooms requested request status is accepted

                Request req = db.Requests.First(p => p.RequestID == id1);
                req.Status = "1";
                db.SaveChanges();


            }





            else
            {//checking for room matches if they are not the same as requested 
                for (var z = 0; z < Splittedwords.Length; z++)
                {


                    var temp1 = Splittedwords[z];

                    var compareRooms = (from a in db.RequestToRooms.Include("RoomRequests") where a.RequestID == id1 && a.RoomRequest.RoomName == temp1 select a.RoomRequestID).ToList();
                    z++;
                    if (!compareRooms.Any())
                    {//if there are not room matches change status to 3 **what if same roms are added but in different order



                        Request req = db.Requests.First(p => p.RequestID == id1);
                        req.Status = "3";
                        db.SaveChanges();
                    }
                    else { RoomsAreSame++; }//check how many rooms are the same 
                }
            }




            //check if status oF request is 3-modified but accepted 
            //if the status is not modified or rooms the same as requested tehn status  is accpeted
            // Request isModified = db.Requests.Find(id1);
            if (isModified.Status != "3" || RoomsAreSame == (Splittedwords.Length) / 2)
            {


                Request req = db.Requests.First(p => p.RequestID == id1);
                req.Status = "1";
                db.SaveChanges();




            }




         

            return Json(Url.Action("GetRequest", "Admin", new { id = "__id__" }));



        }




        //delete facility from a room
        [HttpPost]
        public ActionResult DeleteRoomFac(string id1, string id2)
        {  //assigning RoomFacilityID to int t
            int t = (from d in db.RoomFacilities.Include("Facilities")
                     where (d.RoomName == id2 &&
                     d.Facility.FacilityName == id1)
                     select d.RoomFacilityID).SingleOrDefault();



            RoomFacility roomFacility = db.RoomFacilities.Find(t);
            if (roomFacility == null)
            {
                return HttpNotFound();
            }

            else
            {

                db.RoomFacilities.Remove(roomFacility);
                db.SaveChanges();
            }
            return Json(Url.Action("ShowRoomFacility", "Admin"));
        }




        //add new facility 
        [HttpPost]
        public ActionResult AddNewFacility(string id1, string id2)
        {
            //array with facilities 
            string[] Splittedwords = id2.Split(new string[] { "?" }, System.StringSplitOptions.None);


            RoomFacility roomFacility = new RoomFacility();
            for (int i = 0; i < Splittedwords.Length; i++)
            {
                var facility = Splittedwords[i];

                int facId = (from d in db.Facilities
                             where (d.FacilityName == facility)
                             select d.FacilityID).SingleOrDefault();


                roomFacility.FacilityID = facId;
                roomFacility.RoomName = id1;
                db.RoomFacilities.Add(roomFacility); //add the roomFacility to the table
                db.SaveChanges();

            }


            return Json(Url.Action("ShowRoomFacility", "Admin"));

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
                TempData["Message"] = "Facility" + " " + facility.FacilityName + " " + "edited.";
                db.SaveChanges();
                return RedirectToAction("ShowFacility");
            }
           
            return View(facility);
        }

        //show facility
        public ActionResult DeleteFacility(int id = 0)
        {
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();

            }
            return View(facility);
        }

        //delete facility form the table
        [HttpPost, ActionName("DeleteFacility")]
        public ActionResult DeleteConfirmed1(int id)
        {


            var fcltDelete = db.RoomFacilities.Where(a => a.FacilityID == id).ToList();
            var facRequest = db.FacilityRequests.Where(a => a.FacilityID == id).ToList();

      
            for (var i = 0; i < fcltDelete.Count; i++)
            {
                //find id of the row with the given requestID
                var fID = fcltDelete[i].RoomFacilityID;
                RoomFacility fac = db.RoomFacilities.Find(fID);
                //delete the row
                db.RoomFacilities.Remove(fac);
                db.SaveChanges();
            }
            for (var i = 0; i < facRequest.Count; i++)
            {
                //find id of the row with the given requestID
                var fID = facRequest[i].FacilityRequestID;
                FacilityRequest fac = db.FacilityRequests.Find(fID);
                //delete the row
                db.FacilityRequests.Remove(fac);
                db.SaveChanges();
            }




            Facility facility = db.Facilities.Find(id);
            db.Facilities.Remove(facility);
            TempData["Message"] = "Facility" + " " + facility.FacilityName + " " + "deleted.";
            db.SaveChanges();
         
  
            return RedirectToAction("ShowFacility");
        }

        // GET: /Admin/Details/5

        //create new facility
        public ActionResult CreateFacility()
        {
            return View();
        }

        //add new facility to facility table
        [HttpPost]
        public ActionResult CreateFacility(Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
                TempData["Message"] = "New facility" + " " + facility.FacilityName + " " + "created.";
                return RedirectToAction("ShowFacility");
            }

            return View(facility);
        }



        //create new room
        public ActionResult Create()
        {
            ViewBag.BuildingCode = new SelectList(db.Buildings, "BuildingCode", "BuildingName");
            ViewBag.DeptCode = new SelectList(db.Depts, "DeptCode", "DeptName");

            return View();
        }

        //add new room into room table
        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                room.URL = "http://co-project.lboro.ac.uk/team11/Prakash/img/noImg.jpg";
                db.Rooms.Add(room);
                db.SaveChanges();
                TempData["Message"] = "New room" + " " + room.RoomName + " " + "created.";
                return RedirectToAction("EditPool");
            }

            ViewBag.BuildingCode = new SelectList(db.Buildings, "BuildingCode", "BuildingName");
            return View(room);
        }

        //get request deatails 
        public ActionResult GetRequest(int id = 0)
        {

            Request r = db.Requests.Find(id); //input id from chosen request

            if (r == null)
                return RedirectToAction("Index"); //back to home page if request does not exist




            //if (r.Status == "0" || r.Status == "2")//If request is pending or rejected (therefore not allocated get info form tables bellow)
            // {
            var v = (db.FacilityRequests.Where(a => a.RequestID.Equals(r.RequestID)));
            var res = (db.RequestToRooms.Where(a => a.RequestID.Equals(r.RequestID)));
            var alo = (db.AllocatedRooms.Where(a => a.RequestID == r.RequestID));
            //   var alo = (from q in db.AllocatedRooms
            //  where q.AllocatedRoomID == r.RequestID
            //  select  q.RoomName).ToList();

            var wk = (from d in db.Weeks
                      where d.WeekID == r.WeekID
                      select d).FirstOrDefault();//added
            if (v != null)
            {
                var facReq = v.Include(b => b.Facility); //add foreign key for facilityID
                var roomReq = res.Include(c => c.RoomRequest);
                // var alo1 = alo.Include(c => c.Room);
                var t = (from d in db.Requests.Include("Modules")
                         where (d.RequestID == id)
                         select d.Module.Students).FirstOrDefault(); ;

                ViewBag.GroupSize = t;

                return View(new RequestInfo() { Request = r, FacilityRequests = facReq, RequestToRooms = roomReq, Week = wk, AllocatedRooms = alo }); //return view with the data filled model


            }




            return View();
        }



        //change request status 

        public ActionResult AllocateRooms(int id = 0)
        {

            Request r = db.Requests.Find(id); //input id from chosen request

            if (r == null)
                return RedirectToAction("Index"); //back to home page if request does not exist




            //if (r.Status == "0" || r.Status == "2")//If request is pending or rejected (therefore not allocated get info form tables bellow)
            // {
            var v = (db.FacilityRequests.Where(a => a.RequestID.Equals(r.RequestID)));
            var res = (db.RequestToRooms.Where(a => a.RequestID.Equals(r.RequestID)));
            var alo = (db.AllocatedRooms.Where(a => a.RequestID == r.RequestID));
            var wk = (from d in db.Weeks
                      where d.WeekID == r.WeekID
                      select d).FirstOrDefault();//added
            if (v != null)
            {
                var facReq = v.Include(b => b.Facility); //add foreign key for facilityID
                var roomReq = res.Include(c => c.RoomRequest);

                var t = (from d in db.Requests.Include("Modules")
                         where (d.RequestID == id)
                         select d.Module.Students).FirstOrDefault(); ;

                ViewBag.GroupSize = t;

                return View(new RequestInfo() { Request = r, FacilityRequests = facReq, RequestToRooms = roomReq, Week = wk, AllocatedRooms = alo }); //return view with the data filled model


            }

    

            return View();
        }

        //change request status view
        public ActionResult Edit(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }

            //return View(request);
            return View(request);
        }


        //save request status
        [HttpPost]
        public ActionResult Edit(Request request)
        {
            if (request.Status == null) {

                TempData["Message"] = "Please select appropriate status.";
                


                return View(request);
            }




            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetRequest/" + request.RequestID);
            }

            return View(request);
        }


        //change room ..view
        public ActionResult EditRoom(string id1)
        {


            string selected = (from sub in db.Rooms
                               where sub.RoomName == id1
                               select sub.BuildingCode).First();

            string selected1 = (from sub in db.Rooms
                                where sub.RoomName == id1
                                select sub.DeptCode).First();


            Room room = db.Rooms.Find(id1);
            if (room == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index");
            }
          
            ViewBag.BuildingCode = new SelectList(db.Buildings, "BuildingCode", "BuildingName", selected);
            ViewBag.DeptCode = new SelectList(db.Depts, "DeptCode", "DeptName", selected1);
            return View(room);
        }


        //Delete request
        public ActionResult DeleteReq(int id = 0)
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

        [HttpPost, ActionName("DeleteReq")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Delete any associated room requests
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

            //Delete rows from AllocatedRooms table
            var AR = from d in db.AllocatedRooms
                     where d.RequestID == id
                     select d;
            foreach (AllocatedRoom ar in AR)
            {
                db.AllocatedRooms.Remove(ar);
              
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
            TempData["Message"] = "Request" + " " + request.RequestID + " " + "deleted.";
            return RedirectToAction("Index");
        }


        //update changes into room table
        [HttpPost]
        public ActionResult EditRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Room" + " " + room.RoomName + " " + "edited.";
                return RedirectToAction("EditPool");
            }

            return View(room);
        }

        public ActionResult ChangeRoundDates()
        {
            var r = db.RoundAndSemesters.ToList();


            return View(r);
        }


        public ActionResult EditRound(int id = 0)
        {
            RoundAndSemester RandS = db.RoundAndSemesters.Find(id);
            return View(RandS);
        }

        [HttpPost]
        public ActionResult EditRound(RoundAndSemester RandS, string startDate, string endDate)
        {
            if (ModelState.IsValid)
            {
                //save current row
                RandS.StartDate = Convert.ToDateTime(startDate);
                RandS.EndDate = Convert.ToDateTime(endDate);
                db.Entry(RandS).State = EntityState.Modified;
                db.SaveChanges();


                //if this updated row is the new current round, then make all others false
                if (RandS.CurrentRound == true)
                {
                    var allRounds = (from d in db.RoundAndSemesters
                                     where d.RoundAndSemesterID != RandS.RoundAndSemesterID
                                     select d).ToList();
                    foreach (RoundAndSemester r in allRounds)
                    {
                        r.CurrentRound = false;
                    }
                    db.SaveChanges();
                }
             
                return RedirectToAction("ChangeRoundDates");
            }


            return View(RandS);
        }





        //delete room view

        public ActionResult Delete(string id1)
        {
            Room room = db.Rooms.Find(id1);
            if (room == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index");
            }
            return View(room);
        }


        //delete room from the table 
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id1)
        {

            var RoomRequest = (from d in db.RoomRequests
                               where d.RoomName == id1
                               select d).ToList();


            for (var i = 0; i < RoomRequest.Count; i++)
            {
                //take each roomRequestID
                var rID = RoomRequest[i].RoomRequestID;
                //find the row in the RequestToRoom table and delete it
                RequestToRoom row = db.RequestToRooms.Where(a => a.RoomRequestID.Equals(rID)).FirstOrDefault();
                db.RequestToRooms.Remove(row);
                db.SaveChanges();
                //find the row in the RooomRequest table and delete it
                RoomRequest RoomRow = db.RoomRequests.Where(a => a.RoomRequestID.Equals(rID)).FirstOrDefault();
                db.RoomRequests.Remove(RoomRow);
                db.SaveChanges();
               // 
            }

            var RoomFacility = (from d in db.RoomFacilities
                                where d.RoomName == id1
                                select d).ToList();
            for (var i = 0; i < RoomFacility.Count; i++)
            {
                //take each roomRequestID
                var rID = RoomFacility[i].RoomFacilityID;
                //find the row in the RequestToRoom table and delete it
                RoomFacility RoomRow = db.RoomFacilities.Where(a => a.RoomFacilityID.Equals(rID)).FirstOrDefault();
                db.RoomFacilities.Remove(RoomRow);
                db.SaveChanges();

            }

            var AlocRoom = (from d in db.AllocatedRooms
                            where d.RoomName == id1
                            select d).ToList();

            for (var i = 0; i < AlocRoom.Count; i++)
            {
                var rID = AlocRoom[i].RequestID;
                var aID = AlocRoom[i].AllocatedRoomID;
                AllocatedRoom alocRow = db.AllocatedRooms.Where(a => a.AllocatedRoomID==aID).FirstOrDefault();
               
                
                //if
                db.AllocatedRooms.Remove(alocRow);
                db.SaveChanges();
                        var obj = db.Requests.Where(c => c.RequestID == rID).First();
                        obj.Status = "0";
                        db.SaveChanges();
            }



            Room room = db.Rooms.Find(id1);
            db.Rooms.Remove(room);
            db.SaveChanges();
            TempData["Message"] = "Room" + " " + room.RoomName + " " + "deleted.";
            return RedirectToAction("EditPool");
        }

        private string getCurrentUser()
        {
            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);
            return (row.FullDept);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}