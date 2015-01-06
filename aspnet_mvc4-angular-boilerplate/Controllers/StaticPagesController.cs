using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using aspnet_mvc4_angular_boilerplate.Filters;
using aspnet_mvc4_angular_boilerplate.Models;

namespace aspnet_mvc4_angular_boilerplate.Controllers {
    
    public class StaticPagesController : Controller {

        // Serves the Front-End app root file
        // GET: /
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index() {
            return View();
        }

    }
}