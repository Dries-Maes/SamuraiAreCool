using IntroToEF.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF
{
    class SearchEntities
    {
        private SamuraiLogic _samuraiLogic;
        private QuoteLogic _quoteLogic;
        private HorseLogic _horseLogic;
        private BattleLogic _battleLogic;

        public SearchEntities()
        {
            _samuraiLogic = new SamuraiLogic();
            _battleLogic = new BattleLogic();
            _horseLogic = new HorseLogic();
            _quoteLogic = new QuoteLogic();
        }




    }
}
