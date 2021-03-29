using IntroToEF.Data.Entities;
using System.Collections.Generic;

namespace IntroToEF.Data.Repositories
{
    public interface IBattleRepo
    {
        Battle AddBattle(Battle battle);
        Battle GetBattle(string name);
        List<Battle> SearchBattlesByName(string name);
    }
}