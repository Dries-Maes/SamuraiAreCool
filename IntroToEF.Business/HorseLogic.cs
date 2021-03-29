using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToEF.Data.Entities;
using IntroToEF.Data.Repositories;

namespace IntroToEF.Business
{
    public class HorseLogic
    {

        private IHorseRepo _horseRepo;

        public HorseLogic()
        {
            _horseRepo = new HorseRepo();
        }

        public Horse CreateHorse(string name)
        {
            Horse newHorse = new Horse(name);
            return newHorse;
        }

        public Horse NewHorse(string name)
        {
            Horse newHorse = _horseRepo.GetHorse(name);
            if (newHorse == null)
            {
                newHorse = new Horse(name);
            }
            return newHorse;
        }
    }
}