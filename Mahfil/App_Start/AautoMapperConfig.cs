using AutoMapper;
using Mahfil.Dtos;
using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahfil.App_Start
{
    public class AautoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<Congregration, CongregrationDto>();
                cfg.CreateMap<Notification, NotificationDto>();

            });
        }
    }

}