using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Michèle.Controllers
{
    public class BaseController : Controller
    {

        public static string HostName = string.Empty;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.Url != null)
            {
                HostName = requestContext.HttpContext.Request.Url.Authority;
            }
            base.Initialize(requestContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}