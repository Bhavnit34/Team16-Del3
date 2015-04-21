﻿using System;
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
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["User"] != null)
                base.OnActionExecuting(filterContext); //Continue as normal
            else
            {
                TempData["Message"] = "Please log in to use the timetabling system"; //This message will show once
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }

    }
}