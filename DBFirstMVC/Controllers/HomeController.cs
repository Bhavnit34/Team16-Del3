using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstMVC.Controllers
{
    public class HomeController : Controller
    {
        private team16Entities db = new team16Entities();
        public ActionResult Index()
        {
            //get current round and semester
            RoundAndSemester RandS = (from d in db.RoundAndSemesters
                                      where d.CurrentRound == true
                                      select d).FirstOrDefault();
            if (RandS.RoundID > 5)
            {
                ViewBag.CurrentRound = RandS.RoundID + " (adhoc)";
            }
            else
            {
                ViewBag.CurrentRound = RandS.RoundID;
            }

            ViewBag.CurrentSemester = RandS.Semester;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
