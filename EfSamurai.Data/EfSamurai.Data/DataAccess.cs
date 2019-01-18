using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EfSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfSamurai.Data
{
    public class DataAccess
    {
        private readonly SamuraiContext _context;

        public DataAccess()
        {
            _context = new SamuraiContext();
        }

        public List<Samurai> GetAllSamurais()
        {
            return _context.Samurais.ToList();
        }

        public List<Samurai> GetAllSamurais_OrderedByName()
        {
            return _context.Samurais.OrderBy(s => s.Name).ToList();

        }
    }
}
