namespace SessionTimeoutDemo.Filters
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class SessionTimeout : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string name = Convert.ToString(HttpContext.Current.Session["Name"]);
            if (string.IsNullOrWhiteSpace(name))
            {
                // http://stackoverflow.com/questions/5238854/handling-session-timeout-in-ajax-calls
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                    filterContext.Result = new JsonResult() { Data = "SessionTimedout" };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "SessionTimeout" }));
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}