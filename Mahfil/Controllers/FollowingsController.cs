using Mahfil.Dtos;
using Mahfil.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mahfil.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(x => x.FolloweeId == dto.FolloweeId && x.FollowerId==userId))
            {
                return BadRequest("Follower Already Exist");
            }
            var following = new Following()
            {
                FollowingId = Guid.NewGuid().ToString(),
                FollowerId = User.Identity.GetUserId(),
                FolloweeId=dto.FolloweeId
            
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Unfollow(string id)
        {
            var userId = User.Identity.GetUserId();
            var following = _context.Followings.SingleOrDefault(x => x.FollowerId == userId && x.FolloweeId == id);
            if (following == null) NotFound();
            _context.Followings.Remove(following);
            _context.SaveChanges();
            return Ok(id);
        }
    }
}
