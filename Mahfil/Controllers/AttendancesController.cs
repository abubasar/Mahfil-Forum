using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Mahfil.Dtos;

namespace Mahfil.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            if (_context.Attendances.Any(a => a.CongregrationId == dto.CongregrationId))
            {
                return BadRequest("Already added to Calendar");
            }
            var attendance = new Attendance()
            {
                AttendanceId = Guid.NewGuid().ToString(),
                CongregrationId = dto.CongregrationId,
                AttendeeId = User.Identity.GetUserId()

            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        } 
        [HttpDelete]
        public IHttpActionResult DeleteAttendance(string id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _context.Attendances.SingleOrDefault(x => x.AttendeeId == userId && x.Congregration.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            return Ok(id);

        }
    }
}
