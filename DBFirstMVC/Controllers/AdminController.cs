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
    public class AdminController : BaseController
    {
        private team16Entities db = new team16Entities();

        //
        // GET: /Admin/
        //show all the requests
        public ActionResult Index1()
        {

            //get current round and semester
            //RoundAndSemester RandS = db.RoundAndSemesters.Find(1);
            // ViewBag.CurrentRound = RandS.CurrentRoundID;

            // ViewBag.CurrentSemester = RandS.CurrentSemester;
            var requests = db.Requests.Include(r => r.Module);
            var list = requests.OrderBy(z => z.Status).ToList();
            return View(list);
        }
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

            var requests= from r in db.Requests
                          // where r.UserID == userSession.UserID
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


            var list = requests.OrderBy(z => z.Status).ToList();
            return View(list);
        }

        
        //show the list of all rooms oreder in alpabetical order Building Name 
        public ActionResult EditPool()
        {
            //get current round and semester
            // RoundAndSemester RandS = db.RoundAndSemesters.Find(1);
            //  ViewBag.CurrentRound = RandS.CurrentRoundID;
            //ViewBag.CurrentSemester = RandS.CurrentSemester;

            var rooms = db.Rooms.Include(r => r.Building);
            var list = rooms.OrderBy(z => z.Building.BuildingName).ToList();

            return View(list);
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
                bool roomExit = db.Rooms.Any(o => o.RoomName == temp);

                if (!roomExit)
                {
                    list.Add(Splittedwords[i]);
                }

            }

            string[] result = list.ToArray();



            return Json(result);

            //this is where u finished 
        }
        //assign room allocations for a particular room 
        [HttpPost]
        public ActionResult UpdateAllocations(int id1, string id2)
        {
            //array with assigned rooms 
            string[] Splittedwords = id2.Split(new string[] { "?" }, System.StringSplitOptions.None);
            // find RoomRequestID 
            var t = (from d in db.RequestToRooms
                     where (d.RequestID == id1)
                     select d.RoomRequestID).ToList();


            // If RoomRequestID  does not exists => new allocation
            if (!t.Any())
            {
                RequestToRoom requestToRoom = new RequestToRoom();
                int newRoomRequestID = 0;
                for (var y = 0; y < Splittedwords.Length; y++)
                {


                    //we must re-instantiate the roomRequest for each iteration to stop errors with the auto-primary-key function
                    RoomRequest roomRequest = new RoomRequest();
                    string room = Splittedwords[y];
                    roomRequest.RoomRequestID = 0;
                    roomRequest.GroupSize = Int16.Parse(Splittedwords[y + 1]);
                    roomRequest.PriorityRoom = 0;
                    roomRequest.RoomName = room;

                    db.RoomRequests.Add(roomRequest);
                    db.SaveChanges();
                    y++;

                    newRoomRequestID = roomRequest.RoomRequestID; //take the newly created ID
                    requestToRoom.RequestID = id1;
                    requestToRoom.RoomRequestID = newRoomRequestID; //this is the newly created ID from above

                    db.RequestToRooms.Add(requestToRoom); //add the roomFacility to the table
                    db.SaveChanges();



                }
            }

            else
            {//change/update room alocations 
                int i = 0;
                foreach (var item in t)
                {

                    var roomRequest = new RoomRequest() { RoomRequestID = item, RoomName = Splittedwords[i], GroupSize = Int16.Parse(Splittedwords[i + 1]) };
                    db.RoomRequests.Attach(roomRequest);
                    db.Entry(roomRequest).Property(x => x.RoomName).IsModified = true;
                    db.SaveChanges();

                    i = i + 2;


                }


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
            Facility facility = db.Facilities.Find(id);
            db.Facilities.Remove(facility);

            var fcltDelete = db.RoomFacilities.Where(a => a.FacilityID == id).ToList();
            foreach (var vp in fcltDelete)
                db.RoomFacilities.Remove(vp);
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
                db.Rooms.Add(room);
                db.SaveChanges();
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
                return RedirectToAction("Index"); //back to home page if request doesnt exist

            var v = (db.FacilityRequests.Where(a => a.RequestID.Equals(r.RequestID)));
            var res = (db.RequestToRooms.Where(a => a.RequestID.Equals(r.RequestID)));
            var wk = (from d in db.Weeks
                      where d.WeekID == r.WeekID
                      select d).FirstOrDefault();//added
            if (v != null)
            {
                var facReq = v.Include(b => b.Facility); //add foreign key for facilityID
                var roomReq = res.Include(c => c.RoomRequest);
                return View(new RequestInfo() { Request = r, FacilityRequests = facReq, RequestToRooms = roomReq,Week = wk }); //return view with the data filled model
            }
            return View();
        }
        
       

        //change request status 

        public ActionResult AllocateRooms(int id = 0)
        {

            Request r = db.Requests.Find(id); //input id from chosen request
            if (r == null)
                return RedirectToAction("Index"); //back to home page if request does not exist

            var v = (db.FacilityRequests.Where(a => a.RequestID.Equals(r.RequestID)));
            var res = (db.RequestToRooms.Where(a => a.RequestID.Equals(r.RequestID)));
            if (v != null)
            {
                var facReq = v.Include(b => b.Facility); //add foreign key for facilityID
                var roomReq = res.Include(c => c.RoomRequest);

                var t = (from d in db.Requests.Include("Modules")
                         where (d.RequestID == id)
                         select d.Module.Students).FirstOrDefault(); ;

                ViewBag.GroupSize = t;

                return View(new RequestInfo() { Request = r, FacilityRequests = facReq, RequestToRooms = roomReq }); //return view with the data filled model


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

            return View(request);
        }


        //save request status
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

        //update changes into room table
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
            Room room = db.Rooms.Find(id1);
            db.Rooms.Remove(room);
            db.SaveChanges();
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