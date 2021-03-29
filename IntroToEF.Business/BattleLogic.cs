using IntroToEF.Data.Entities;
using IntroToEF.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Business
{
    public class BattleLogic
    {
        private BattleRepo _battleRepo;

        public BattleLogic()
        {
            _battleRepo = new BattleRepo();
        }

        public Battle CreateBattle(Battle battle)
        {
            return _battleRepo.AddBattle(battle);
        }

        public Battle NewBattle(string name)
        {
            Battle newBattle = _battleRepo.GetBattle(name);
            if (newBattle == null)
            {
                newBattle = new Battle(name);
            }
            return newBattle;
        }

        public List<Battle> SearchBattlesByName(string name)
        {
            return _battleRepo.SearchBattlesByName(name);
        }

    }
}