using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahfil.ViewModels
{
    public class MahfilDetailsViewModel
    {
        public Congregration Congregration { get; set; }
        public bool IsAttending { get; set; }   
        public bool IsFollowing { get; set; }

        public ILookup<string, Following> Followings { get; set; }
    }
}