using DBFirstMVC.Models;
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

        public ActionResult Index(string sortOrder)
        {
            User userSession = (User)HttpContext.Session["User"]; //This is needed to find the current user

            //These alternate sort parameter for switch statement
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.UserSortParm = sortOrder == "user" ? "user_desc" : "user";
            ViewBag.LengthSortParm = sortOrder == "length" ? "length_desc" : "length";
            ViewBag.DaySortParm = sortOrder == "day" ? "day_desc" : "day";
            ViewBag.SemesterSortParm = sortOrder == "semester" ? "semester_desc" : "semester";
            ViewBag.StatusSortParm = sortOrder == "status" ? "status_desc" : "status";
            ViewBag.RoundSortParm = sortOrder == "round" ? "round_desc" : "round";
            ViewBag.TypeSortParm = sortOrder == "type" ? "type_desc" : "type";
            ViewBag.PrioritySortParm = sortOrder == "priority" ? "priority_desc" : "priority";
            ViewBag.AdhocSortParm = sortOrder == "adhoc" ? "adhoc_desc" : "adhoc";

            var requests = from r in db.Requests
                           where r.UserID == userSession.UserID
                           select r;

            //requests = db.Requests.Include(r => r.Module);

            //handles which sort method to use
            switch (sortOrder)
            {
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
                case "status":
                    requests = requests.OrderBy(r => r.Status);
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
                default:
                    requests = requests.OrderBy(r => r.Module.Title);
                    break;
            }
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

        public ActionResult DisplayRoomInfo(string id = "0", string caller = "")
        {

            ViewBag.Caller = caller;
            Room room = db.Rooms.Find(id);
            var q = db.RoomFacilities.Where(a => a.RoomName.Equals(id));

            return View(new RoomInfo() { Room = room, RoomFacility = q });
        }

        public void ShowRoomInfo(string room)
        {
            DisplayRoomInfo(room, "GetRequest");
        }

        public ActionResult GetRequest(int id = 0)
        {
            Request r = db.Requests.Find(id); //input id from chosen request
            if (r == null)
            {
                TempData["Message"] = "Request " + id.ToString() + " doesn't exist";
                return RedirectToAction("Index"); //back to home page if request doesnt exist
            }
            User userSession = (User)HttpContext.Session["User"];
            if (r.UserID != userSession.UserID)
            {
                TempData["Message"] = "Request " + id.ToString() + " isn't for your department";
                return RedirectToAction("Index"); //back to home page if request doesnt exist
            }
            


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


        public ActionResult CreateNew()
        {
            string s = "";
            if (Request.UrlReferrer != null)
            {
                s = Request.UrlReferrer.ToString();
            }
            if (s.Contains("Edit"))
                Session.Remove("State");

            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);

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
                string wk = "";
                for (var i = 0; i < state.Weeks.Count; i++) {
                    wk += "," + state.Weeks[i]; 
                }
                wk = wk.Substring(1, wk.Length-1); //remove leading comma
                ViewBag.SelectedWeeks = wk;
                ViewBag.Length = r.SessionLength; //add this to force display the length using javascript
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

            //set user of the request
            User user = (User)Session["User"];
            myRequest.Request.UserID = user.UserID;

            //This needs to be calculated when we do ad hoc requests
            myRequest.Request.AdhocRequest = 0;


            myRequest.Request.Status = "0";
               
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

            //save round and semester info
            RoundAndSemester RandS = (from d in db.RoundAndSemesters
                                      where d.CurrentRound == true
                                      select d).FirstOrDefault();

            myRequest.Request.RoundID = RandS.RoundID;
            myRequest.Request.Semester = RandS.Semester;


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
                if (myRequest.Request.UserID == 0)
                {

                    return RedirectToAction("Index", "Admin");

                }


               
               Session.Remove("State"); //remove current saved request
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
            User userSession = (User)HttpContext.Session["User"];
            string user = userSession.Username;

            var rm = from d in db.Rooms
                    where ((d.Building.BuildingName == chosenBuilding) && ((d.DeptCode == null) || (d.DeptCode == user)))
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
            string s = Request.UrlReferrer.ToString();
            string caller = "CreateNew";
            if (s.Contains("Edit"))
                caller = "Edit";

            RequestState state = new RequestState();
            state.Request = r;
            state.Facilities = Fac.Split(',').ToList<string>();
            state.Weeks = selectedWeeks.Split(',').ToList<string>();
            state.Rooms = Rooms.Split(',').ToList<string>();
            state.Sizes = Sizes.Split(',').ToList<string>();
            state.PriorityRoomName = PriorityRoomName;
            Session["State"] = state; //save session
            DisplayRoomInfo(SelectedRoom, caller);
        }

        public ActionResult CheckAvailability(string rooms, string selectedWeeks, string day, string period, string length)
        {
            //turn inputted string arrays into lists
            List<string> roomList = rooms.Split(',').ToList<string>();
            List<string> chosenWeeks = selectedWeeks.Split(',').ToList<string>();
            List<string> availRooms = new List<string>(); //array of free rooms to return




              

            return Json(availRooms);
        }




       //Function to increment the round and simulate results of requests randomly
        public ActionResult NextRound()
        {
            //Find the current round from the table
            //var CurrentRound = (from d in db.RoundAndSemesters
                                //select d.CurrentRoundID).FirstOrDefault();


            var CurrentRound = (from d in db.RoundAndSemesters
                                where d.CurrentRound == true
                                select d).FirstOrDefault();

            // get requests that are on the current round
            var reqs = from d in db.Requests 
                       where d.RoundID == CurrentRound.RoundID
                       select d;


            //loop through each request and give it a status
            Random x = new Random(); //randomizer
            object syncLock = new object(); //a synclock will help produce a different random number
            foreach (Request r in reqs)
            {
                int status = 0;
                if (Convert.ToInt16(r.Status) < 1)
                {
                    lock (syncLock) //This stops the same random number from being generated
                    {
                        status = x.Next(1,3); //random no between 1 and 2
                        r.Status = status.ToString();
                    }
                    
                }

            }
            
            db.SaveChanges(); //save the rows

            //change the currentRound to false for old round
            RoundAndSemester RandSOld = (from d in db.RoundAndSemesters
                                      where d.RoundID == CurrentRound.RoundID && d.Semester == CurrentRound.Semester
                                      select d).FirstOrDefault();
            RandSOld.CurrentRound = false;
            db.SaveChanges();

            //increment the roundID and save to the table
            byte? newRoundID = Convert.ToByte(CurrentRound.RoundID + 1);
            byte? newSemester = CurrentRound.Semester;
            if (newRoundID > 5)
            {
                //reset the round to 1 and change the semester
                newRoundID = 1;
                if (newSemester == 1) { newSemester = 2; } else { newSemester = 1; };
            }
            RoundAndSemester RandSNew = (from d in db.RoundAndSemesters
                                     where d.RoundID == newRoundID && d.Semester == newSemester
                                     select d).FirstOrDefault();
            RandSNew.CurrentRound = true;
            db.SaveChanges();
            TempData["Message"] = "The round has been incremented, please check your requests below";
            return RedirectToAction("Index");
        }


        //Edit Module view 
        public ActionResult Module()
        {

            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);


            ViewBag.Modules = db.Modules.Where(a => a.DeptCode.Equals(userSession.Username));



            return View();


        }

        public ActionResult CreateNewModule()

        {
           User userSession = (User)HttpContext.Session["User"];
           ViewBag.Dept = userSession.Username;
           ViewBag.DeptCode = new SelectList(db.Depts, "DeptCode", "DeptName", userSession.Username);
            return View();


        }



        //create new Module 
        [HttpPost]
        public ActionResult CreateNewModule(Module module)
        {
            if (ModelState.IsValid)
            {
                db.Modules.Add(module);
                db.SaveChanges();
                return RedirectToAction("Module");
            }
            User userSession = (User)HttpContext.Session["User"];
            ViewBag.Dept = userSession.Username;
            ViewBag.DeptCode = new SelectList(db.Depts, "DeptCode", "DeptName", userSession.Username);
            return View(module);
        }

       //[HttpPost]
     
        public ActionResult GetModuleInfo(string id)
        {

            Module r = db.Modules.Find(id);
           
          if (r == null)
           {
               return HttpNotFound();
               
           }

            var l=(db.ModuleLecturers.Where(a=>a.ModCode.Equals(r.ModCode)));
            var d = (db.ModuleDegrees.Where(a => a.ModCode.Equals(r.ModCode)));
          
            if (l != null) {

                var t = l.Include(b => b.Lecturer);

                var degName = d.Include(x => x.Degree);
                return View(new ModuleInfo() { Module = r, ModuleLecturers = t , ModuleDegrees=degName});
            
            }
            return View();
            
        }

        public ActionResult EditModule(string id)
        {


            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();
                // return RedirectToAction("Index");
            }
            User userSession = (User)HttpContext.Session["User"];
            ViewBag.Dept = userSession.Username;
            ViewBag.DeptCode = new SelectList(db.Depts, "DeptCode", "DeptName", userSession.Username);
            return View(module);
        }
        [HttpPost]
        public ActionResult EditModule(Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetModuleInfo/"+module.ModCode);
            }
            User userSession = (User)HttpContext.Session["User"];
            ViewBag.Dept = userSession.Username;
            ViewBag.DeptCode = new SelectList(db.Depts, "DeptCode", "DeptName", userSession.Username);
            return View(module);
        }



        public ActionResult DeleteModule(string id)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return HttpNotFound();

            }
            return View(module);
        }


        [HttpPost, ActionName("DeleteModule")]
        public ActionResult DeleteConfirmed1(string id)
        {
            var modDegree = (from d in db.ModuleDegrees
                              where d.ModCode == id
                              select d).ToList();
            var modLecturer = (from d in db.ModuleLecturers
                             where d.ModCode == id
                             select d).ToList();


            for (var i = 0; i < modDegree.Count; i++)
            {

                var rID = modDegree[i].ModuleDegreeID;
                ModuleDegree row = db.ModuleDegrees.Where(a => a.ModuleDegreeID.Equals(rID)).FirstOrDefault();
                db.ModuleDegrees.Remove(row);
                db.SaveChanges();



            }
            for (var i = 0; i < modLecturer.Count; i++)
            {

                var lID = modLecturer[i].ModuleLecturerID;
                ModuleLecturer row = db.ModuleLecturers.Where(a => a.ModuleLecturerID.Equals(lID)).FirstOrDefault();
                db.ModuleLecturers.Remove(row);
                db.SaveChanges();

            }
           
            Module module = db.Modules.Find(id);
            db.Modules.Remove(module);
            db.SaveChanges();






            return RedirectToAction("Module");
        }

        //
        // GET: /Request/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Request request = db.Requests.Find(id);
            if(Convert.ToInt64(request.Status)> 0){
                TempData["Message"] = "You cannot edit this request, it already has been processed";
                return RedirectToAction("GetRequest", new { id = request.RequestID });
            }
                
            RequestState state = new RequestState(); //This will be the model for the session
            if (request == null)
            {
                return HttpNotFound();
            }

            //Begin saving state. Save rooms and sizes
            var requestToRooms = db.RequestToRooms.Where(a => a.RequestID.Equals(id)).ToList();
            List<string> roomList = new List<string>();
            List<string> sizeList = new List<string>();
            foreach(RequestToRoom r in requestToRooms)
            {
                RoomRequest RoomRequest = db.RoomRequests.Where(a => a.RoomRequestID.Equals(r.RoomRequestID)).FirstOrDefault();
                string roomName = RoomRequest.RoomName;
                string size = RoomRequest.GroupSize.ToString();
                roomList.Add(roomName);
                sizeList.Add(size);
                if (RoomRequest.PriorityRoom == 1) //restore the priority room
                    state.PriorityRoomName = roomName;
            }
            state.Rooms = roomList;
            state.Sizes = sizeList;
            state.Request = request; //save request
            
            //save weeks
            List<string> weekList = new List<string>();
            Week week = db.Weeks.Find(request.WeekID);
            if (week.Week1 == 1)
                weekList.Add("1");
            if (week.Week2 == 1)
                weekList.Add("2");
            if (week.Week3 == 1)
                weekList.Add("3");
            if (week.Week4 == 1)
                weekList.Add("4");
            if (week.Week5 == 1)
                weekList.Add("5");
            if (week.Week6 == 1)
                weekList.Add("6");
            if (week.Week7 == 1)
                weekList.Add("7");
            if (week.Week8 == 1)
                weekList.Add("8");
            if (week.Week9 == 1)
                weekList.Add("9");
            if (week.Week10 == 1)
                weekList.Add("10");
            if (week.Week11 == 1)
                weekList.Add("11");
            if (week.Week12 == 1)
                weekList.Add("12");
            if (week.Week13 == 1)
                weekList.Add("13");
            if (week.Week14 == 1)
                weekList.Add("14");
            if (week.Week15 == 1)
                weekList.Add("15");
            state.Weeks = weekList; //add the weekList array to the model
            
            //Add facilities
            List<string> facList = new List<string>();
            var facilities = db.FacilityRequests.Where(a => a.RequestID.Equals(id));
            foreach (FacilityRequest f in facilities)
            {
                facList.Add(f.Facility.FacilityName);
            }
            state.Facilities = facList;

            Session["State"] = state; //save state

            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);

            if (row.DeptCode == "CA")
                ViewBag.Modules = db.Modules; //this will be used as the list of modules
            else
                ViewBag.Modules = db.Modules.Where(a => a.DeptCode.Equals(userSession.Username)); //this will be used as the list of modules


            List<SelectListItem> Period = new List<SelectListItem>();
            Period.Add(new SelectListItem { Text = "p1 - 9:00", Value = "1" });
            Period.Add(new SelectListItem { Text = "p2 - 10:00", Value = "2" });
            Period.Add(new SelectListItem { Text = "p3 - 11:00", Value = "3" });
            Period.Add(new SelectListItem { Text = "p4 - 12:00", Value = "4" });
            Period.Add(new SelectListItem { Text = "p5 - 13:00", Value = "5" });
            Period.Add(new SelectListItem { Text = "p6 - 14:00", Value = "6" });
            Period.Add(new SelectListItem { Text = "p7 - 15:00", Value = "7" });
            Period.Add(new SelectListItem { Text = "p8 - 16:00", Value = "8" });
            Period.Add(new SelectListItem { Text = "p9 - 17:00", Value = "9" });

            ViewBag.Periods = Period; //This will be passed into the view for the dropdownlist

            var allRooms = from room in db.Rooms select room;  //same as SELECT * from Room

            var allFacilities = from fac in db.Facilities select fac; //same as SELECT * from Facility
            ViewBag.Facility = new SelectList(db.Facilities, "FacilityName", "FacilityName");
            ViewBag.Park = new SelectList(db.Parks, "ParkName", "ParkName");

                string x = string.Join(",", state.Facilities.ToArray()); //add in facilities
                ViewBag.facList = x;
                string y = string.Join(",", state.Rooms.ToArray()); //add in rooms
                ViewBag.roomList = y;
                string z = string.Join(",", state.Sizes.ToArray()); //add in sizes
                ViewBag.sizeList = z;

                ViewBag.PriorityRoomName = state.PriorityRoomName; //add the priority room choice
                string wk = "";
                for (var i = 0; i < state.Weeks.Count; i++)
                {
                    wk += "," + state.Weeks[i];
                }
                wk = wk.Substring(1, wk.Length - 1); //remove leading comma
                ViewBag.SelectedWeeks = wk;
                ViewBag.Length = request.SessionLength; //add this to force display the length using javascript
                ViewBag.ID = id; //to display and use for completing an edit



                return View(new CreateNewRequest() { Rooms = allRooms, Facilities = allFacilities, Request = request });
        }
        

        
        //
        // POST: /Request/Edit/5


        public ActionResult AddLecturer(string id)
        {
            ViewBag.id = id;
            User userSession = (User)HttpContext.Session["User"];
            ViewBag.Dept = userSession.Username;
            ViewBag.LecturerID= new SelectList(db.Lecturers, "LecturerID", "FullName", userSession.Username);

            return View();

        }

        [HttpPost]
        public ActionResult AddLecturer(ModuleLecturer moduleLecturer)
        {
            if (ModelState.IsValid)
            {

                var check = (from f in db.ModuleLecturers where f.ModCode==moduleLecturer.ModCode &&
                             f.LecturerID==moduleLecturer.LecturerID select f.ModCode).Count();


                if (check == 0)
                {
                    db.ModuleLecturers.Add(moduleLecturer);
                    db.SaveChanges();
                    return RedirectToAction("GetModuleInfo/" + moduleLecturer.ModCode);
                }
                else {
                    TempData["error"] = "Lecturer is already assigned for this module";
                    ViewData["error"] = TempData["error"];
                    ViewBag.id = moduleLecturer.ModCode;
                    User userSess = (User)HttpContext.Session["User"];
                    ViewBag.Dept = userSess.Username;
                    ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", userSess.Username);
                    return View();
                
                }
            }
            ViewBag.id = moduleLecturer.ModCode;
            User userSession = (User)HttpContext.Session["User"];
            ViewBag.Dept = userSession.Username;
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", userSession.Username);
            return View();
        }
        public ActionResult RemoveLecturer(string id)
        {

            ViewBag.id = id;

            var r = (db.ModuleLecturers.Where(a => a.ModCode.Equals(id)));
                    
            
            if (r == null)
            {
                return HttpNotFound();

           }
       
                var t = r.Include(b => b.Lecturer);
                return View(new ModuleInfo() {  ModuleLecturers = t });

          

        }
        [HttpPost]
        public ActionResult DeleteLecturer1(string id)
        {
            //array with parameters
            string[] Splittedwords = id.Split(new string[] { "?" }, System.StringSplitOptions.None);

            int lecID = Convert.ToInt32(Splittedwords[0]);
            var modc = Splittedwords[1];

            int did = (from x in db.ModuleLecturers
                       where x.LecturerID == lecID && x.ModCode == modc
                       select x.ModuleLecturerID).SingleOrDefault();

            ModuleLecturer row = db.ModuleLecturers.Find(did);
            db.ModuleLecturers.Remove(row);
            db.SaveChanges();



            return Json(Url.Action("GetModuleInfo", "Request", new { id = "__id__" }));
   

        }

        public ActionResult AddDegree(string id)
        {
            ViewBag.id = id;
            User userSession = (User)HttpContext.Session["User"];
            ViewBag.Dept = userSession.Username;
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "FullName", userSession.Username);

            return View();

        }
        [HttpPost]
        public ActionResult AddDegree(ModuleDegree moduleDegree)
        {
            if (ModelState.IsValid)
            {

                var check = (from f in db.ModuleDegrees
                             where f.ModCode == moduleDegree.ModCode &&
                                 f.DegreeID == moduleDegree.DegreeID
                             select f.ModCode).Count();


                if (check == 0)
                {
                    db.ModuleDegrees.Add(moduleDegree);
                    db.SaveChanges();
                    return RedirectToAction("GetModuleInfo/" + moduleDegree.ModCode);

                }

                else {


                    TempData["error"] = "Degree is already assigned for this module";
                    ViewData["error"] = TempData["error"];
                    ViewBag.id = moduleDegree.ModCode;
                    User userSess = (User)HttpContext.Session["User"];
                    ViewBag.Dept = userSess.Username;
                    ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "FullName", userSess.Username);
                    return View();
                
                
                }

            }
            ViewBag.id = moduleDegree.ModCode;
            User userSession = (User)HttpContext.Session["User"];
            ViewBag.Dept = userSession.Username;
            ViewBag.DegreeID = new SelectList(db.Degrees, "DegreeID", "FullName", userSession.Username);
            return View();
        }

        public ActionResult RemoveDegree(string id)
        {
            ViewBag.id = id;

            var r = (db.ModuleDegrees.Where(a => a.ModCode.Equals(id)));


            if (r == null)
            {
                return HttpNotFound();

            }

            var t = r.Include(b => b.Degree);
           
            
            return View(new ModuleInfo() { ModuleDegrees = t });


        }
         [HttpPost]
        public ActionResult DeleteDegree1(string id)
        {
            string[] Splittedwords = id.Split(new string[] { "?" }, System.StringSplitOptions.None);

            int deqID =  Convert.ToInt32(Splittedwords[0]);
            var modc = Splittedwords[1];

            int did = (from x in db.ModuleDegrees
                      where x.DegreeID == deqID && x.ModCode == modc
                      select x.ModuleDegreeID).SingleOrDefault();

            ModuleDegree row = db.ModuleDegrees.Find(did);
            db.ModuleDegrees.Remove(row);
            db.SaveChanges();
            
            
            
            return Json(Url.Action("GetModuleInfo", "Request", new { id = "__id__" }));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateNewRequest myRequest, string requestID, string Command, string[] facList, string[] chosenRooms, string[] groupSizes, bool[] pRooms, string selectedWeeks, bool cbPriorityRequest = false, string Park = "")
        {
            Request request = db.Requests.Find(Convert.ToInt16(requestID));
            myRequest.Request = request;

            bool validFacilities = true;
            bool validRooms = true;
            if (cbPriorityRequest) //take boolean of checkbox and turn into 1 or 0
                myRequest.Request.PriorityRequest = 1;
            else
                myRequest.Request.PriorityRequest = 0;

            myRequest.Request.RequestID = Convert.ToInt32(requestID);
            //set user of the request
            User user = (User)Session["User"];
            myRequest.Request.UserID = user.UserID;

            //This needs to be calculated when we do ad hoc requests
            myRequest.Request.AdhocRequest = 0;


            myRequest.Request.Status = "0";

            //take in the string array of weeks and add it to the week table (if it doesnt already exist)
            List<string> weeks = new List<string>();
            if (selectedWeeks.Contains(','))
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
            if (facList == null)
                validFacilities = false;

            //check any rooms have been chosen
            if (chosenRooms == null)
                validRooms = false;

            //save the modified request row
            request = myRequest.Request;
            db.SaveChanges();
            int newRequestID = myRequest.Request.RequestID; //get the newly created key made for the new request

            //Edit facility requests
            if (validFacilities)
            {
                
                    FacilityRequest facilityRequest = new FacilityRequest(); //create a list of facilityRequest rows to add to the table
                    for (int i = 0; i < facList.Length; i++) //loop through list of chosen facilities
                    {
                        string fac = facList[i]; //put facility into string so it can be used in LINQ
                        int facId = (from d in db.Facilities
                                  where (d.FacilityName == fac)
                                  select d.FacilityID).SingleOrDefault();
                        
                        //check if the facilityRequest already exists (if they didnt change that facility)
                        var res = (from d in db.FacilityRequests
                                   where (d.Facility.FacilityName == fac) && (d.RequestID == newRequestID)
                                   select d).FirstOrDefault();
                        if (res == null) //i.e. it doesnt exist
                        {
                            //assign the values to the object
                            facilityRequest.FacilityID = facId;
                            facilityRequest.RequestID = newRequestID;
                            db.FacilityRequests.Add(facilityRequest); //add the facilityRequest to the table
                            db.SaveChanges();
                            continue;
                        }

                    } //end for

                    //Find all faciltyRequests and remove ones that are not needed anymore
                    var fr = db.FacilityRequests.Where(f => f.RequestID.Equals(newRequestID)).ToList();

                    for(var i=0;i< fr.Count;i++)
                    {
                        if(fr[i].Facility != null) //ignore facilities just added, otherwise will cause 'no reference' error
                        {
                            if (Array.IndexOf(facList,fr[i].Facility.FacilityName) == -1) //if the facility isnt in the new array of chosen facilities
                            {
                                db.FacilityRequests.Remove(fr[i]); //delete this facilityRequest
                            }
                        }

                    }

                
            } //end validFacilities

            //Edit room requests
            int newRoomRequestID = 0;
            if (validRooms)
            {
                RequestToRoom requestToRoom = new RequestToRoom();

                //pRooms array will be false if unchecked, and true + false if checked, so we must try to take out only the correct bool values
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
                //here pRoomsNew is now the correct array of bool values for priority room

                //delete old room requests
                var ReqToRooms = (from d in db.RequestToRooms
                                  where d.RequestID == newRequestID
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


                //add new room requests
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

            Session.Remove("State"); //remove current saved request
            return RedirectToAction("GetRequest", new { id = myRequest.Request.RequestID }); //redirect to the updated request info page
            
            //----------old code------------------
            /*if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModCode = new SelectList(db.Modules, "ModCode", "Title", request.ModCode);
            return View(request);
             */
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}