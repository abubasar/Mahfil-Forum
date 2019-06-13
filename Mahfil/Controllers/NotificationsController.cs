using AutoMapper;
using Mahfil.Dtos;
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
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
           
            var notifications = _context.UserNotifications.Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification).Include(n => n.Congregration.Speaker).ToList();
            //using Auto Mapper
            
           // return notifications.Select(Mapper.Map<Notification, NotificationDto>);

             //Manual Mapping
            return notifications.Select(n=>new NotificationDto() {
                DateTime=n.DateTime,
                Congregration=new CongregrationDto
                {
                    Speaker=new UserDto()
                    {
                        Id=n.Congregration.Speaker.Id,
                        Name=n.Congregration.Speaker.Name
                    },
                    DateTime=n.Congregration.DateTime,
                    Id=n.Congregration.Id,
                    IsCancelled=n.Congregration.IsCancelled,
                    Venue=n.Congregration.Venue

                },
                OriginalDateTime=n.OriginalDateTime,
                OriginalVenue=n.OriginalVenue,
                Type=n.Type

            });
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications.Where(x => x.UserId == userId && !x.IsRead).ToList();
            notifications.ForEach(x => x.Read());
            _context.SaveChanges();
            return Ok();
        }

    }
}
