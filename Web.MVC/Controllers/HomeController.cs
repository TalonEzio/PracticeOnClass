using System.Web.Mvc;

namespace Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}