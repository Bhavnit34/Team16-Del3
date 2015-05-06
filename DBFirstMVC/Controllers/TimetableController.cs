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

    }
}
