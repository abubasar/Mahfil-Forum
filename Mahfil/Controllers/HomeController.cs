using Mahfil.Models;
using Mahfil.Repository;
using Mahfil.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mahfil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private MahfilRepository _mahfilRepository;
        private AttendanceRepository _attendanceRepository;
        public HomeController()
        {
            _context = new ApplicationDbContext();
            _attendanceRepository = new AttendanceRepository();
            _mahfilRepository = new MahfilRepository();
        }
        public ActionResult Index(string query=null)
        {
            var upcomingCongregration = _context.Congregrations.Include(x => x.Speaker)
                .Include(x => x.Genre).Where(x => x.DateTime > DateTime.Now && !x.IsCancelled);

            if (!string.IsNullOrWhiteSpace(query))
            {
                upcomingCongregration = upcomingCongregration.Where(x => x.Speaker.Name.Contains(query) || x.Genre.Name.Contains(query) || x.Venue.Contains(query));
            }

            var userId = User.Identity.GetUserId();
            
            var viewModel = new CongregrationsViewModel()
            {
                UpcomingCongregrations = upcomingCongregration,
                ShowActions = User.Identity.IsAuthenticated,
                Heading="Upcoming Congregrations",
                SearchTerm=query,
                Attendances= _attendanceRepository.GetFutureAttendances(userId).ToLookup(x => x.CongregrationId)
            };
            return View("Congregrations",viewModel);
        }

       
    
    }
}