using Mahfil.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mahfil.Controllers
{
    [Authorize]
    public class CongregrationsController : ApiController
    {
        private ApplicationDbContext _context;
        public CongregrationsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(string id)
        {
            var userId = User.Identity.GetUserId();

            var congregration = _context.Congregrations.Include(c=>c.Attendances.Select(a=>a.Attendeee)).Single(x => x.Id == id && x.SpeakerId == userId);
            if (congregration.IsCancelled)
                return NotFound();
            congregration.Cancel();
            _context.SaveChanges();

            return Ok();

        }
     
    }
}
