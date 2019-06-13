using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mahfil.Models
{
    public class Congregration
    {
        public string Id { get; set; }
        public bool IsCancelled { get; private set; }
    
        public string SpeakerId { get; set; }
        public ApplicationUser Speaker { get; set; }
    
        public string Venue { get; set; }
        public DateTime DateTime { get; set; }
        
        public string GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Attendance> Attendances { get;private set; }


        public Congregration()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            this.IsCancelled = true;

            var notification = Notification.MahfilCanceled(this);

            foreach (var attendee in this.Attendances.Select(a => a.Attendeee))
            {
                attendee.Notify(notification);

            }
            
        }

        public void Modify(DateTime dateTime,string venue,string genre)
        {
           
            var notification = Notification.MahfilUpdated(this,dateTime,venue);
           
            Venue = venue;
            DateTime = dateTime;
            GenreId = genre;

            foreach (var attendee in this.Attendances.Select(a => a.Attendeee))
            {
                attendee.Notify(notification);

            }

        }
    }
}