using System;

namespace Mahfil.Dtos
{
    public class CongregrationDto
    {
        public string Id { get; set; }
        public bool IsCancelled { get; set; }
        public UserDto Speaker { get; set; }
         public string Venue { get; set; }
        public DateTime DateTime { get; set; }
        public GenreDto Genre { get; set; }
    
    }
}