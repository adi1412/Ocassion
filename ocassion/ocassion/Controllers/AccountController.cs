using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ocassion.Models;
using System.Web.Security;

namespace ocassion.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/

        //public ActionResult Index()
        //{
        //    return View();
        //}
   
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(loginProperty login)
        {

            if (ModelState.IsValid)
            {
                using (DAL.OSCEntities _context = new DAL.OSCEntities())
                {
                    var result = _context.Users.Where(e => e.UserName.Equals(login.Email) && e.PasswordHash.Equals(login.password)).ToList();
                    if (result.Count != 0)
                    {
                        FormsAuthentication.SetAuthCookie(login.Email, true);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, login.Email, DateTime.Now, DateTime.Now.AddMinutes(15), true, login.Email, FormsAuthentication.FormsCookiePath);
                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                        Response.Cookies.Add(cookie);
                       return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ViewBag.Msg = "Invalid Credentials.";
                        return View();
                    }
                }
            }
            else
            {
                return View();
            }
        }
       

    }
}
