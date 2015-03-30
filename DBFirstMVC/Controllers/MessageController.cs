using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBFirstMVC.Controllers
{
    //This controller is executed to show a small message at the top of the page, whenever the TempData["Message"] is used before showing a view
    public class MessageController : Controller
    {
        //
        // GET: /Message/
        [ChildActionOnly]
        public ActionResult TempMessage()
        {
            return PartialView();
        }

    }
}
