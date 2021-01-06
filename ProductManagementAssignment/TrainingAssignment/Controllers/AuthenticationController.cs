using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TrainingAssignment.Controllers
{
    /*
     * This controller is used for Login for existing user and Registration for new users.
     */
    public class AuthenticationController : Controller
    {
        public readonly Logger log = NLog.LogManager.GetCurrentClassLogger();

        /*Get method of Login*/
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }

        /*Post method of Login*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (ProductManagementAssignmentEntities db = new ProductManagementAssignmentEntities())
                    {
                        var mdPass = GetMD5(password); //Generate MD5 string of users password.
                        var data = db.Users.FirstOrDefault(m => m.Email.Equals(email) && m.Password.Equals(mdPass));
                        if (data != null)
                        {
                            Session["Email"] = email;
                            Session["Id"] = data.Id;
                            log.Info("User log-in successful.");
                            return RedirectToAction("Home", "Display");
                        }

                        else
                        {
                            TempData["message"] = "Invalid Email or password.";
                            return View();
                        }

                    } //End of using block.

                }//End of try block.

                catch (Exception ex)
                {
                    log.Error(ex, "Error occure during user log-in");
                    TempData["message"] = "Error - " + ex.Message;
                    return View();
                }

            } //End of if statement.

            return View();
        }

        /*Get method of Register*/
        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }

        /*Post method of Register*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Users users)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (ProductManagementAssignmentEntities db = new ProductManagementAssignmentEntities())
                    {
                        var data = db.Users.FirstOrDefault(m => m.Email == users.Email);
                        if (data == null)
                        {
                            try
                            {
                                users.Password = GetMD5(users.Password); //Generate MD5 string for user password
                                db.Users.Add(users);
                                db.SaveChanges(); //All details saved into database.
                                log.Info("User registration completed.");
                                return RedirectToAction("Login", "Authentication");
                            }

                            catch (Exception ex)
                            {
                                log.Error(ex, "Error during new user registration.");
                                TempData["message"] = "Error - " + ex.Message;
                                return View();
                            }
                        } //End of inner if statement.

                        else
                        {

                            TempData["message"] = "already registered with this email-id.";
                            return View();
                        }

                    } // End of using statement.

                } //End of try block.

                catch (Exception ex)
                {
                    log.Error(ex, "Error occured in database.");
                    TempData["message"] = "Error - " + ex.Message;
                    return View();
                }

            } //End of outer if statement

            return View();
        }

        /*This method is used for generate MD5 string for user password*/
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}