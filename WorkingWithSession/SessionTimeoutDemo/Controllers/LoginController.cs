namespace SessionTimeoutDemo.Controllers
{
    using System;
    using System.Web.Mvc;

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            HttpContext.Session["Name"] = "Bruce Wayne";
            ViewBag.Name = Convert.ToString(HttpContext.Session["Name"]);

            return View();
        }

        public ActionResult SessionTimeout()
        {
            return View();
        }
    }
}