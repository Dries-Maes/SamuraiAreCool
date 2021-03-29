using IntroToEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Data.Repositories
{
    class HorseRepo : IHorseRepo
    {
        private SamuraiAreCoolDBContext _context;

        public HorseRepo()
        {
            _context = new SamuraiAreCoolDBContext();
        }

        public void AddHorse(string name)
        {
            //create an object to be INSERTED
            Horse horse = new Horse(name);

            _context.Horses.Add(horse);
            _context.SaveChanges();
        }

        public void AddHorses(string name)
        {
            //create an object to be INSERTED
            List<Horse> myList = new List<Horse>
            {
                new Horse("Horse1"),
                new Horse("Horse2"),
                new Horse("Horse3")

            };

            _context.Horses.AddRange(myList);
            _context.SaveChanges();
        }
    }
}
