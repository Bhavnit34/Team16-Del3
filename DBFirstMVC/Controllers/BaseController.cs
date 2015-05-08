using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstMVC.Controllers
{
    /*The purpose of this controller is act as an overide on each action of the other controllers, so that each time
    it will check that a user has logged in succesfully. This is done by checking for a valid session.
     */
    public class BaseController : Controller
    {
        private team16Entities db = new team16Entities();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["User"] != null)
            {
                ViewBag.CurrentUser = getCurrentUser(); // get user logged in
                ViewBag.LogOut = true; //set button to logout, not login
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

                base.OnActionExecuting(filterContext); //Continue as normal
            }
            else
            {
                TempData["Message"] = "Please log in to use the timetabling system"; //This message will show once
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
        private string getCurrentUser()
        {
            User userSession = (User)HttpContext.Session["User"];
            var row = db.Depts.Find(userSession.Username);
            return (row.FullDept);
        }

    }
}
