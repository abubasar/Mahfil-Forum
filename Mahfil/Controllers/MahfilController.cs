using Mahfil.Models;
using Mahfil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Collections;
using Mahfil.Repository;

namespace Mahfil.Controllers
{
    public class MahfilController : Controller
    {
        private ApplicationDbContext _context;
        private MahfilRepository _mahfilMepository;
        private AttendanceRepository _attendanceRepository;
        private GenreRepository _genreRepository;
        private FollowingRepository _followingRepository;
        private UnitOfWork _unitOfWork;
        public MahfilController()
        {
            _context = new ApplicationDbContext();
            _mahfilMepository = new MahfilRepository();
            _attendanceRepository = new AttendanceRepository();
            _genreRepository = new GenreRepository();
            _followingRepository = new FollowingRepository();
            _unitOfWork = new UnitOfWork();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new MahfilFormViewModel()
            {
                Id = "",
                Genres = _context.Genres.ToList(),
                Heading="Add new Congregration"
            };

            return View("CongregrationForm", viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(string id)
        { 
            var congregration = _mahfilMepository.GetMahfil(id);
            if (congregration == null)
                return HttpNotFound();
            if (congregration.SpeakerId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();
            var viewModel = new MahfilFormViewModel()
            {
                Id=congregration.Id,
                Heading = "Edit Congregration",
                Genres = _context.Genres.ToList(),
                Date = congregration.DateTime.ToString("MM/dd/yyyy"),
                Time = congregration.DateTime.ToString("HH:mm"),
                Genre = congregration.GenreId,
                Venue=congregration.Venue

            };

            return View("CongregrationForm",viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MahfilFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _context.Genres.ToList();
                return View("CongregrationForm", model);
            }
            
            var congregration = _mahfilMepository.GetMahfilWithAttendees(model.Id);

            if (congregration == null)
            {
                return HttpNotFound();
            }

            if (congregration.SpeakerId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();
            congregration.Venue = model.Venue;
            congregration.DateTime = model.GetDateTime();
            congregration.GenreId = model.Genre;
            _context.SaveChanges();
            return RedirectToAction("Mine", "Mahfil");
            
        }


        public ActionResult Create(MahfilFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _genreRepository.GetGenres();
                return View("CongregrationForm", model);
            }
            var speakerId = User.Identity.GetUserId();
            //var speaker = _context.Users.Single(x => x.Id == speakerId);
            //var genre = _context.Genres.Single(x => x.Id == model.Genre);
            var mahfil = new Congregration()
            {
                Id = Guid.NewGuid().ToString(),
                SpeakerId = speakerId,
                //Speaker = speaker,
                DateTime = model.GetDateTime(),
                //Genre = genre,
                GenreId = model.Genre,
                Venue = model.Venue
            };
            _mahfilMepository.Add(mahfil);
            _unitOfWork.Complete();
            return RedirectToAction("Mine", "Mahfil");

        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new CongregrationsViewModel()
            {
              UpcomingCongregrations= _mahfilMepository.GetMahfilsUserAttending(userId),
              ShowActions =User.Identity.IsAuthenticated,
              Heading="Congregrations I am going",
              Attendances= _attendanceRepository.GetFutureAttendances(userId).ToLookup(x => x.CongregrationId)
            };

            return View("Congregrations",viewModel);
        }

        [Authorize]
        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var followings = _context.Followings.Include(x=>x.Follower).Where(x => x.FollowerId == userId)
                .ToList();
            return View(followings);
        }

        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var congregrations = _mahfilMepository.GetUpcomingMahfilsBySpeaker(userId);
            return View(congregrations);
        }

      [HttpPost]
        public ActionResult search(CongregrationsViewModel model)
        {
            return RedirectToAction("Index", "Home", new { query = model.SearchTerm });
        }

        public ActionResult Details(string id)
        {
            var mahfil = _mahfilMepository.GetMahfil(id);
            if (mahfil == null)
                return HttpNotFound();
            var viewModel = new MahfilDetailsViewModel()
            {
                Congregration=mahfil
            };

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                viewModel.IsAttending = _attendanceRepository.GetAttendance(mahfil.Id, userId) != null;
                viewModel.IsFollowing = _followingRepository.GetFollowing(userId, mahfil.SpeakerId)!=null;

            }

            return View("Details", viewModel);

        }

    }
}