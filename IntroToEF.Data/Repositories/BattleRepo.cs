using IntroToEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Data.Repositories
{
    public class BattleRepo : IBattleRepo
    {
        private SamuraiAreCoolDBContext context;

        public BattleRepo()
        {
            // Open connection to database
            context = new SamuraiAreCoolDBContext();
        }

        public Battle AddBattle(Battle battle)
        {
            context.Battles.Add(battle);
            context.SaveChanges();
            return context.Battles.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public Battle GetBattle(string name)
        {
            return context.Battles.FirstOrDefault(x => x.Name == name);
        }
    }
}