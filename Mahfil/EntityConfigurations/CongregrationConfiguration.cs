using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Mahfil.EntityConfigurations
{
    public class CongregrationConfiguration:EntityTypeConfiguration<Congregration>
    {
        public CongregrationConfiguration()
        {
          Property(c => c.SpeakerId).IsRequired();
           Property(c => c.Venue).IsRequired().HasMaxLength(255);
          Property(c => c.GenreId).IsRequired();
        }
    }
}