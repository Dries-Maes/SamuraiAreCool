using System;
using IntroToEF.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToEF.Data.Repositories;

namespace IntroToEF.Business
{
    public class QuoteLogic
    {
     

        private IQuoteRepo _quoteRepo;

        public QuoteLogic()
        {
            _quoteRepo = new QuoteRepo();
        }

        public Quote CreateQuote(Quote quote)
        {
            return _quoteRepo.AddQuote(quote);
        }

        public Quote NewQuote(string text)
        {
            Quote newQuote = _quoteRepo.GetQuote(text);
            if (newQuote == null)
            {
                newQuote = new Quote(text);
            }
            return newQuote;
        }
    }


}