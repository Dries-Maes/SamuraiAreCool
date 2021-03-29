using IntroToEF.Data.Entities;
using IntroToEF.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Business
{
    public class SamuraiLogic
    {
        private SamuraiRepo _samuraiRepo;

        public SamuraiLogic()
        {
            _samuraiRepo = new SamuraiRepo();
        }

        public Samurai CreateSamurai(Samurai samurai)
        {
            return _samuraiRepo.AddSamurai(samurai);
        }

        public Samurai NewSamurai(string name)
        {
            Samurai newSamurai = _samuraiRepo.GetSamurai(name);
            if (newSamurai == null)
            {
                newSamurai = new Samurai(name);
            }
            return newSamurai;
        }

        public List<Samurai> GetAllSamurais()
        {
            List<Samurai> samurais = _samuraiRepo.GetSamurais();
            return samurais;
        }

        public List<Samurai> GetSamuraiContaining(string name)
        {
            return _samuraiRepo.SearchSamuraiByName(name);
        }
    }
}