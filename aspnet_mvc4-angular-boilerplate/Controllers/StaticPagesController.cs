using System.Web.Mvc;

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