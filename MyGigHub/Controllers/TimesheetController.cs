using Microsoft.AspNet.Identity;
using MyGigHub.Models;
using MyGigHub.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyGigHub.Controllers
{
    public class TimesheetController : Controller
    {
        private ApplicationDbContext _context;
        public TimesheetController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Timesheet
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var myTimesheet = _context.Timesheets
                .Include(g => g.ApplicationUser)
                .Where(g => g.UserId == userId);

            if (myTimesheet.Count()==0)
            {
                ViewBag.Myhours = "0";
            }
            else
            {
                   ViewBag.Myhours = myTimesheet.Sum(b => b.EndDay.Hour) - myTimesheet.Sum(b => b.StartDay.Hour);
            }

            return View(myTimesheet);
        }

        // GET: Timesheet
        [Authorize(Roles = "Admin")]
        public ActionResult IndexAdmin()
        {

            var userId = User.Identity.GetUserId();
            var myTimesheet = _context.Timesheets
                .Include(g => g.ApplicationUser);

            return View(myTimesheet);
        }
        // GET: Gig
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new TimesheetFormViewModel();
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TimesheetFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("Create", viewModel);

            var timesheet = new Timesheet
            {
                Name = User.Identity.Name,
                IP = viewModel.IP,
                UserId = User.Identity.GetUserId(),
                StartDay = viewModel.GetDateTimeStart(),
                EndDay = viewModel.GetDateTimeEnd()
            };
            _context.Timesheets.Add(timesheet);
            _context.SaveChanges();

            return RedirectToAction("Index", "Timesheet");
        }
        [Authorize]
        public ActionResult EditView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = _context.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            TimesheetFormViewModel viewModel = new TimesheetFormViewModel
            {
                Date = string.Format("{0} {1} {2}", timesheet.StartDay.Day, timesheet.StartDay.Month, timesheet.StartDay.Year),
                Id = timesheet.Id,
                IP = timesheet.IP,
                TimeStart = string.Format("{0}:{1}",timesheet.StartDay.Hour,timesheet.StartDay.Minute)
            };
            ViewBag.StartDay = viewModel.TimeStart;

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditView([Bind(Include = /*"Id,StartDay,EndDay,UserId,Name"*/ "Id,Name,IP,StartDay,EndDay,GetDifferenceTimes()")] TimesheetFormViewModel viewModel)
        {
            var timesheet = new Timesheet
            {

                //UserId = User.Identity.GetUserId(),


                Name = User.Identity.Name,
                IP = viewModel.IP,
                UserId = User.Identity.GetUserId(),
                StartDay = viewModel.GetDateTimeStart(),
                EndDay = viewModel.GetDateTimeEnd()
            };
            if (ModelState.IsValid)
            {
                _context.Entry(timesheet).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timesheet);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = _context.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditAdmin(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = _context.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDay,EndDay,UserId,Name")] Timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(timesheet).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timesheet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditAdmin([Bind(Include = "Id,StartDay,EndDay,UserId,Name")] Timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(timesheet).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("IndexAdmin");
            }
            return View(timesheet);
        }

        // GET: TimesheetsController2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = _context.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }

        // POST: TimesheetsController2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Timesheet timesheet = _context.Timesheets.Find(id);
            _context.Timesheets.Remove(timesheet);
            _context.SaveChanges();
            return RedirectToAction("IndexAdmin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: TimesheetsController2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Timesheet timesheet = _context.Timesheets.Find(id);
            if (timesheet == null)
            {
                return HttpNotFound();
            }
            return View(timesheet);
        }
        // GET: Timesheets2/Create
        public ActionResult Create2()
        {
            return View();
        }

        // POST: Timesheets2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "Id,Name,IP,StartDay,EndDay,UserId")] Timesheet timesheet)
        {
            if (ModelState.IsValid)
            {
                _context.Timesheets.Add(timesheet);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timesheet);
        }
    }
}