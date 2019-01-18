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

        public List<Samurai> GetAllSamurais_OrderedByIdDescending()
        {
            return _context.Samurais.OrderByDescending(s => s.Id).ToList();
        }

        public List<Quote> GetAllQuotesOfType(QuoteType quoteType)
        {
            return _context.Quotes.Where(q => q.Type.Name == quoteType.Name).ToList();
        }

        public List<Quote> GetAllQuotesOfType_WithSamurai(QuoteType quoteType)
        {
            return _context.Quotes.Where(q => q.Type.Name == quoteType.Name).Include(s => s.Samurai).ToList();
        }
    }
}
