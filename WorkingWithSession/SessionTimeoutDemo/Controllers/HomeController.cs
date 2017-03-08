namespace SessionTimeoutDemo.Controllers
{
    using Filters;
    using System.Web.Mvc;

    [SessionTimeout]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult GetData()
        {
            return Json(new { message = "Hello, World!" }, JsonRequestBehavior.AllowGet);
        }
    }
}