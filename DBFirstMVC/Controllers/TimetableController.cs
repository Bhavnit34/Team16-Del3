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

        //function to return an array of weeks given the weekID
        public ActionResult getWeeks(int WeekID)
        {
            var week = db.Weeks.Find(WeekID);
            List<string> weekList = new List<string>();

            //go through each week and check if its 1. Long-winded but the only way
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



            return Json(weekList);
        }

        public ActionResult FindTimetable(string Name, bool Lecturer)
        {
            if (Lecturer) //If the inputted name was a lecturer name
            {
                int spaceIndex = Name.IndexOf(" ");
                string FirstName = Name.Substring(0, spaceIndex);
                int len = Name.Length - (FirstName.Length + 1);
                string LastName = Name.Substring(spaceIndex + 1, len);

                //Find lecturerID
                var L = db.Lecturers.Where(a => a.LastName.Equals(LastName)).FirstOrDefault();
                var LID = L.LecturerID;

                //Get modules that have the lecturerID
                var modules = db.ModuleLecturers.Where(a => a.Lecturer.LecturerID.Equals(LID)).ToList();
                //populate the list of modcodes that the lecturer teaches
                List<string> modCodes = new List<string>();
                foreach (ModuleLecturer ml in modules)
                {
                    if (modCodes.IndexOf(ml.ModCode) == -1)
                        modCodes.Add(ml.ModCode);
                }


                //get current semester
                RoundAndSemester RandS = (from d in db.RoundAndSemesters
                                          where d.CurrentRound == true
                                          select d).FirstOrDefault();



                //get requests that contain any of the modcodes in the array
                var FinalRequests = from d in db.Requests
                                    where (modCodes.Contains(d.ModCode) && d.Status == "1" && d.Semester == RandS.Semester)
                                    select new { id = d.RequestID, DayID = d.DayID, PeriodID = d.PeriodID, Length = d.SessionLength, ModCode = d.ModCode, weekID = d.WeekID };

                return Json(FinalRequests);
            }
            else //if user selected a course
            {
                int dashIndex = Name.IndexOf('-');
                string DegreeName = Name.Substring(0, dashIndex - 1);
                int len = Name.Length - (dashIndex + 2);
                string Part = Name.Substring(dashIndex + 2, len);

                //find DegreeID
                var D = db.Degrees.Where(a => a.DegreeName.Equals(DegreeName) && a.Part.Equals(Part)).FirstOrDefault();
                var DID = D.DegreeID;

                //find modules that have the degreeID
                var modules = db.ModuleDegrees.Where(a => a.DegreeID.Equals(DID));

                //populate list of modcodes that the degree contains
                List<string> modCodes = new List<string>();
                foreach (ModuleDegree md in modules)
                {
                    if (modCodes.IndexOf(md.ModCode) == -1)
                        modCodes.Add(md.ModCode);
                }

                //get current semester
                RoundAndSemester RandS = (from d in db.RoundAndSemesters
                                          where d.CurrentRound == true
                                          select d).FirstOrDefault();

                //get requests that contain any of the modcodes in the array
                var FinalRequests = from d in db.Requests
                                    where (modCodes.Contains(d.ModCode) && d.Status == "1" && d.Semester == RandS.Semester)
                                    select new { id = d.RequestID, DayID = d.DayID, PeriodID = d.PeriodID, Length = d.SessionLength, ModCode = d.ModCode, weekID = d.WeekID };

                return Json(FinalRequests);
            }

        }


        

    }
}
