using IntroToEF.Data.Entities;

namespace IntroToEF.Data.Repositories
{
    public interface IHorseRepo
    {
        void AddHorse(string name);
        void AddHorses(string name);
        Horse GetHorse(string name);
    }
}