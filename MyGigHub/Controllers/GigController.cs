using MyGigHub.Models;
using MyGigHub.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MyGigHub.Controllers
{
    public class GigController : Controller
    {
        private ApplicationDbContext _Context;
        public GigController()
        {
            _Context = new ApplicationDbContext();
        }
        // GET: Gig
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _Context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}