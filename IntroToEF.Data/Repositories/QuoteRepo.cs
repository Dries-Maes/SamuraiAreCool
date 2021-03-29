using IntroToEF.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IntroToEF.Data.Repositories
{
    public class QuoteRepo : IQuoteRepo
    {
        private SamuraiAreCoolDBContext _context;

        public QuoteRepo()
        {
            _context = new SamuraiAreCoolDBContext();
        }

        public void AddQuote(string text)
        {
            //create an object to be INSERTED
            Quote quote = new Quote(text);

            _context.Quotes.Add(quote);
            _context.SaveChanges();
        }

        public Quote AddQuote(Quote quote)
        {
            throw new System.NotImplementedException();
        }

        public Quote GetQuote(string text)
        {
            throw new System.NotImplementedException();
        }

        public List<Quote> GetQuotes()
        {
            return _context.Quotes.Include(x => x.Samurai)
                .ToList();
        }
    }
}