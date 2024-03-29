﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mahfil.Models
{
    public class UserNotification
    {
        protected UserNotification()
        {

        }

        public UserNotification(ApplicationUser user,Notification notification)
        {
            if (user == null)
                throw new ArgumentNullException("user");
            if (notification == null)
                throw new ArgumentNullException("notification");
            User = user;
            Notification = notification;

        }
        [Key]
        [Column(Order =1)]
        public string UserId { get; private set; }
        [Key]
        [Column(Order =2)]
        public string NotificationId { get; private set; }
        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }
        public bool IsRead { get; set; }


        public void Read()
        {
            IsRead = true;
        }
    }
}