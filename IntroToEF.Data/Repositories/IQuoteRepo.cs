using IntroToEF.Data.Entities;
using System.Collections.Generic;

namespace IntroToEF.Data.Repositories
{
    internal interface IQuoteRepo
    {
        void AddQuote(string text);
        List<Quote> GetQuotes();
    }
}