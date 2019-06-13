using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mahfil.Models
{
    public class Attendance
    {
        [Key]
        public string AttendanceId { get; set; }
        [ForeignKey("CongregrationId")]
        public Congregration Congregration { get; set; }
        [ForeignKey("AttendeeId")]
        public ApplicationUser Attendeee { get; set; }

        
        public string CongregrationId { get; set; }
      
        public string AttendeeId { get; set; }




    }
}