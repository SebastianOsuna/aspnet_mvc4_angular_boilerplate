using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net;
using WebMatrix.WebData;
using aspnet_mvc4_angular_boilerplate.Models;

namespace aspnet_mvc4_angular_boilerplate.Filters
{

    public class HandleAuthentication : System.Web.Http.Filters.ActionFilterAttribute
    {

        

        public override void OnActionExecuting(HttpActionContext filterContext)
        //void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            ApplicationContext db = new ApplicationContext();
            IEnumerable<string> list = new List<string>();
            
            if (this.IsPublic(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName))
            {
                // Do nothing
            }
            else if (!filterContext.Request.Headers.TryGetValues("Authentication", out list))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            else
            {
                string accessToken = list.First();
                IEnumerable<Session> session = db.Sessions.Where(s => s.AccessToken == accessToken).AsEnumerable();
                if (session.Count() > 0)
                {
                    Session s = session.First();
                    if (s.ExpirationDate.CompareTo(DateTime.Now) < 0)
                    {
                        throw new HttpResponseException(HttpStatusCode.Unauthorized);
                    }
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.Unauthorized);
                }
                
            }
        }

        private bool IsPublic(string controller, string action)
        {
            return controller.Equals( "StaticPages" ) ||
                (controller == "Sessions" && action == "login");
        }

        
    }   
}
