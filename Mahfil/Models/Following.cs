using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mahfil.Models
{
    public class Following
    {
        public string FollowingId { get; set; }
        [ForeignKey("FollowerId")]
        public ApplicationUser Follower { get; set; }
        public string FollowerId { get; set; }
        [ForeignKey("FolloweeId")]
        public ApplicationUser Followee { get; set; }
        public string FolloweeId { get; set; }
    }
}