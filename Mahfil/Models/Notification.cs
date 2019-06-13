using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mahfil.Models
{
    public class Notification
    {
        protected Notification()
        {

        }
        private Notification(NotificationType type,Congregration congregration)
        {
            if (congregration == null)
            {
                throw new ArgumentNullException("congregration");
            }
            Type = type;
            Congregration = congregration;
            DateTime = DateTime.Now;
            Id = Guid.NewGuid().ToString();
            
        }
        public string Id { get; private set; }
        public DateTime DateTime { get;private set; }
        public NotificationType Type { get;private set; }
        public DateTime? OriginalDateTime { get;private set; }
        public string  OriginalVenue { get;private set; }
        [Required]
        public Congregration Congregration { get;private set; }


        public static Notification MahfilCreated(Congregration congregration)
        {
            return new Notification(NotificationType.MahfilCreated, congregration);
        }

        public static Notification MahfilUpdated(Congregration newCongregration,DateTime originalDateTime,string originalVenue)
        {
            var notification= new Notification(NotificationType.MahfilUpdated, newCongregration);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;
            return notification;
        }

        public static Notification MahfilCanceled(Congregration congregration)
        {
            return new Notification(NotificationType.MahfilCanceled, congregration);
        }
    }
}