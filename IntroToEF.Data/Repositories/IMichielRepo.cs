using IntroToEF.Data.Entities;
using System.Collections.Generic;

namespace IntroToEF.Data.Repositories
{
    public interface IMichielRepo
    {
        void AddDifferentObjectsToContext();

        void AddSamurai(Samurai samurai);

        void AddSamurai(string name);

        void AddSamurais(List<Samurai> samurais);

        void DeleteSamurai(int id);

        List<Samurai> GetResultFromStoredProcedure(string text);

        Samurai GetSamurai(int id, bool fetchAllRelatedData = false);

        Samurai GetSamuraiByName(string name);

        List<Samurai> GetSamurais();

        List<Samurai> GetSamuraisByName(string name);

        Samurai GetSamuraiWithIncludedData(int id);

        void GetSamuraiWithSql();

        void UpdateSamurai(Samurai samurai);

        void UpdateSamurais();
    }
}