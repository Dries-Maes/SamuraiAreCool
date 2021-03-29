using IntroToEF.Data.Entities;
using System.Collections.Generic;

namespace IntroToEF.Data.Repositories
{
    public interface ISamuraiRepo
    {
        Samurai AddSamurai(Samurai samurai);
        Samurai GetSamurai(string name);
        List<Samurai> SearchSamuraiByName(string name);
    }
}