using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahfil.ViewModels
{
    public class CongregrationsViewModel
    {
        public IEnumerable<Congregration> UpcomingCongregrations { get; set; }
        public bool ShowActions { get; set; }

        public string Heading { get; set; }
        public string SearchTerm { get; set; }
        public ILookup<string,Attendance> Attendances { get; set; }
    }
}