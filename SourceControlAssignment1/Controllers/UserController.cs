using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment1.Models;

namespace SourceControlAssignment1.Controllers
{
    public class UserController : Controller
    {
        //Get : Form
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        // Post: Form
        [HttpPost]
        public ActionResult Form(User user)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Name = user.Name;
                ViewBag.Intro = user.Intro;
                ViewBag.ConfirmEmail = user.ConfirmEmail;
                ViewBag.Password = user.Password;
                ViewBag.Experience = user.Experience;
                ViewBag.Phone = user.Phone;
                return View();
            }
            else
            {
                ViewBag.Name = "No data available";
                ViewBag.Intro = "No data available";
                ViewBag.ConfirmEmail = "No data available";
                ViewBag.Password = "No data available";
                ViewBag.Experience = "No data available";
                ViewBag.Phone = "No data available";
                return View();
            }
           
        }
    }
}