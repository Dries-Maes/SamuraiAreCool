using System;
using IntroToEF.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Business
{
    public class QuoteLogic
    {
        public Quote CreateQuote(string text)
        {
            Quote newQuote = new Quote(text);
            return newQuote;
        }
    }
}