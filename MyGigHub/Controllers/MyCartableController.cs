using MyGigHub.Models;
using MyGigHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MyGigHub.Controllers
{
    public class MyCartableController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public MyCartableController()
        {
            db = new ApplicationDbContext();
        }
        // GET: MyCartable
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            var viewModel = new CartableFormViewModel
            {
                applicationUsers = db.Users.ToList()
            };
            return View(viewModel);
        }
    }
}