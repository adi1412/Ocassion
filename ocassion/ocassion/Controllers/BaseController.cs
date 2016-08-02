using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ocassion.DAL;
using log4net;

namespace ocassion.Controllers
{
    public class BaseController : Controller
    {

     internal static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Overriden Methods

        protected override void OnException(ExceptionContext filterContext)
        {
            log4net.Config.XmlConfigurator.Configure();
            //log.StartMethod();

            if (filterContext != null && filterContext.Exception != null)
            {

                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                string loggerName = string.Format("{0}Controller.{1}", controller, action);

                log.Error(string.Empty, filterContext.Exception);

                // Output a nice error page
                if (filterContext.HttpContext.IsCustomErrorEnabled)
                {
                    filterContext.ExceptionHandled = true;
                    HandleErrorInfo errorInfo = new HandleErrorInfo(filterContext.Exception, controller, action);
                    this.View("GenericError", errorInfo).ExecuteResult(this.ControllerContext);
                }
            }

            //log.EndMethod();
        }
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
        #endregion
    }
}