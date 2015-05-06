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
    public class TimetableController : BaseController    {
        private team16Entities db = new team16Entities();
        //
        // GET: /Timetable/

        public ActionResult Index()
        {
            var l = db.Lecturers.ToList();
            var d = db.Degrees.ToList();

            ViewBag.Lecturers = db.Lecturers.ToList();
            ViewBag.Degrees = db.Degrees.ToList();
            return View(new TimetableModel() {Degree = d, Lecturer = l });
        }


        public ActionResult FindTimetable(string Name, bool Lecturer)
        {
            if (Lecturer) //If the inputted name was a lecturer name
            {
                int spaceIndex = Name.IndexOf(" ");
                string FirstName = Name.Substring(0, spaceIndex);
                int len = Name.Length - (FirstName.Length+1);
                string LastName = Name.Substring(spaceIndex+1,len);
               
                //Find lecturerID
                var L = db.Lecturers.Where(a => a.LastName.Equals(LastName)).FirstOrDefault();
                var LID = L.LecturerID;
                
                //Get modules that have the lecturerID
                var modules = db.ModuleLecturers.Where(a => a.Lecturer.LecturerID.Equals(LID)).ToList();
                //populate the list of modcodes that the lecturer teaches
                List<string> modCodes = new List<string>();
                foreach(ModuleLecturer ml in modules)
                {
                    if(modCodes.IndexOf(ml.ModCode) == -1)
                        modCodes.Add(ml.ModCode);
                }


                //get current semester
                RoundAndSemester RandS = (from d in db.RoundAndSemesters
                                          where d.CurrentRound == true
                                          select d).FirstOrDefault();



                //get requests that contain any of the modcodes in the array
                var FinalRequests = from d in db.Requests
                                    where (modCodes.Contains(d.ModCode) && d.Status == "1" && d.Semester == RandS.Semester)
                                    select new { id = d.RequestID, DayID = d.DayID, PeriodID = d.PeriodID, Length = d.SessionLength, ModCode = d.ModCode};

                return Json(FinalRequests);
            }


            return View();
        }



    }
}
