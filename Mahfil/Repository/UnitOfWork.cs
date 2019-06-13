using Mahfil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mahfil.Repository
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}