using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.Controllers
{
    public class AuthenticationController : Controller
    {
        /*Create object of Context class for database.*/
        Context db = new Context();
        /*use LogManager class to create Logger instance.*/
        public readonly Logger log = NLog.LogManager.GetCurrentClassLogger();
        // GET: Authentication

        /*Get method of Login*/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /*Post method of Login*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee employee)
        {
            log.Info("Inside login method check user's credentials.");
            /*Check user's credentials*/
            var data = db.employees.FirstOrDefault(m => m.Email == employee.Email && m.Password == employee.Password);

            if (data != null)
            {
                
                Session["Email"] = employee.Email;
                log.Info("login successfull");
                return RedirectToAction("DisplayData", "Display");
            }

            else
            {
                TempData["message"] = "Wrong email-id or password";
                log.Info("login failed");
                return RedirectToAction("Login", "Authentication");
            }


            return View();
        }

        /*Get method of SignUp*/
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        /*For generating random name and append with image name*/
        private static Random random = new Random();
        public static string RandomString(int length)
        {
          
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /*Post method of SignUp*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(HttpPostedFileBase image, Employee employee)
        {
           
            /*Check state is valid or not.*/
            if (ModelState.IsValid)
            {
                
                /*check user is already register or not.*/
                var data = db.employees.FirstOrDefault(mbox => mbox.Email.Equals(employee.Email));

                
                if (data == null)
                {
                    /*check image is null or not.*/
                    if (image != null && image.ContentLength > 0)
                    {
                        try
                        {
                            string filename = "_" + RandomString(10) + Path.GetFileName(image.FileName);
                            string path = Path.Combine(Server.MapPath("~/Images"), filename);
                            image.SaveAs(path);
                            employee.ImagePath = "/Images/" + filename;
                        }

                        /*Generate exception if image is not valid*/
                        catch (Exception ex)
                        {
                            log.Error("error" + ex);
                            TempData["message"] = "error occured during saving image" + ex;
                        }

                    }

                    else
                    {
                        log.Error("image is not available or image is null.");
                        TempData["message"] = "Choose correct image";
                    }

                    /*All details added into database*/
                    db.employees.Add(employee);
                    db.SaveChanges();
                    log.Info("user's data saved into database.");
                    Session["Email"] = employee.Email;
                    //TempData["message"] = "User added successfully";
                    return RedirectToAction("DisplayData", "Display");
                }
                /*Gives message to the user is already registered with that email-id.*/
                else
                {
                   
                    TempData["message"] = "Email id already exist ";
                    log.Info("User's email-id already exist.");
                    return RedirectToAction("SignUp", "Authentication");
                }
            }
            return View();
        }
    }
}