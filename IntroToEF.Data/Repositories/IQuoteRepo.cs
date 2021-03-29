using IntroToEF.Data.Entities;
using System.Collections.Generic;

namespace IntroToEF.Data.Repositories
{
    public interface IQuoteRepo
    {
        Quote AddQuote(Quote quote);
        List<Quote> GetQuotes();
        Quote GetQuote(string text);
    }
}