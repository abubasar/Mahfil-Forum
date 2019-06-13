using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahfil.Repository
{
    public class AttendanceRepository
    {
        private ApplicationDbContext _context;
        public AttendanceRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Attendance> GetFutureAttendances(string userId)
        {
            
          return  _context.Attendances.Where(x => x.AttendeeId == userId && x.Congregration.DateTime > DateTime.Now)
                .ToList();
        }

        public Attendance GetAttendance(string congregrationId,string userId) 
        {
            return _context.Attendances.SingleOrDefault(x => x.CongregrationId == congregrationId && x.AttendeeId == userId);
        }
    }
}