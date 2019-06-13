using System.ComponentModel.DataAnnotations;

namespace Mahfil.Models
{
    public class Genre
    {
        public string Id { get; set; }
        
        [Required]
        [StringLength(55)]
        public string Name { get; set; }
    }
}