using IntroToEF.Data.Entities;

namespace IntroToEF.Data.Repositories
{
    public interface IBattleRepo
    {
        Battle AddBattle(Battle battle);
        Battle GetBattle(string name);
    }
}