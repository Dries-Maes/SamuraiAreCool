using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToEF.Data.Entities;

namespace IntroToEF.Business
{
    public class HorseLogic
    {
        public Horse CreateHorse(string name)
        {
            Horse newHorse = new Horse(name);
            return newHorse;
        }
    }
}