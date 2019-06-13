using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahfil.Repository
{
    public class GenreRepository
    {
        private ApplicationDbContext _context;
        public GenreRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}