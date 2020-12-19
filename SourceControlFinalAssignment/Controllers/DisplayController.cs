using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlFinalAssignment.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult DisplayData()
        {
            return View();
        }
    }
}