using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeddingsWebsite.Models;

namespace WeddingsWebsite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DBWeddingDataContext db = new DBWeddingDataContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            if(f["username"].ToString().Equals("admin") && f["password"].ToString().Equals("admin"))
                return RedirectToAction("Index", "Dashboard");
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}