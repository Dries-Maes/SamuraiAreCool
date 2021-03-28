using IntroToEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Data.Repositories
{
    public class SamuraiRepo
    {
        private SamuraiAreCoolContext context;

        public SamuraiRepo()
        {
            // Open connection to database
            context = new SamuraiAreCoolContext();
        }

        public Samurai AddSamurai(Samurai samurai)
        {
            context.Samurais.Add(samurai);
            context.SaveChanges();
            return context.Samurais.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public Samurai GetSamurai(string name)
        {
            return context.Samurais.FirstOrDefault(x => x.Name == name);
        }
    }
}