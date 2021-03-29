using IntroToEF.Data.Entities;

namespace IntroToEF.Data.Repositories
{
    public interface ISamuraiRepo
    {
        Samurai AddSamurai(Samurai samurai);
        Samurai GetSamurai(string name);
    }
}