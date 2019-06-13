using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mahfil.Repository
{
    public class MahfilRepository
    {
        private ApplicationDbContext _context;
        public MahfilRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Congregration GetMahfil(string congregrationId)
        {
            return _context.Congregrations.Include(x => x.Speaker).Include(x => x.Genre).SingleOrDefault(x => x.Id == congregrationId);
        }

        public IEnumerable<Congregration> GetUpcomingMahfilsBySpeaker(string speakerId)
        {
            return _context.Congregrations.Include(x => x.Speaker).Include(x => x.Genre)
                .Where(x => x.SpeakerId == speakerId && x.DateTime > DateTime.Now && !x.IsCancelled).ToList();
        }
        public Congregration GetMahfilWithAttendees(string congregrationId)
        {
            return _context.Congregrations.Include(c => c.Attendances).Single(x => x.Id == congregrationId);
        }

        public IEnumerable<Congregration> GetMahfilsUserAttending(string userId)
        {
            return _context.Attendances.Where(a => a.AttendeeId == userId).Select(a => a.Congregration)
                .Include(x => x.Speaker).Include(x => x.Genre)
                .ToList();
        }

        public void Add(Congregration congregration)
        {
            _context.Congregrations.Add(congregration);
        }
    }
}