using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahfil.Repository
{
    public class FollowingRepository
    {
        private ApplicationDbContext _context;
        public FollowingRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Following GetFollowing(string userId,string speakerId)
        {
            return _context.Followings.SingleOrDefault(x => x.FolloweeId ==speakerId && x.FollowerId == userId);
        }
    }
}