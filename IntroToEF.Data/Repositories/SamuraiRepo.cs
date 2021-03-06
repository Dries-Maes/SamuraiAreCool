using IntroToEF.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Data.Repositories
{
    public class SamuraiRepo : ISamuraiRepo
    {
        private SamuraiAreCoolDBContext context;

        public SamuraiRepo()
        {
            // Open connection to database
            context = new SamuraiAreCoolDBContext();
        }

        public Samurai AddSamurai(Samurai samurai)
        {
            context.Samurais.Add(samurai);
            context.SaveChanges();
            return context.Samurais.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public Samurai GetSamurai(string name)
        {
            return context.Samurais.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public List<Samurai> SearchSamuraiByName(string name)
        {
            return context.Samurais.Where(x => x.Name.Contains(name)).ToList();
        }

        public List<Samurai> GetSamurais()
        {
            return context.Samurais
                .Include(x => x.Horses)
                .Include(x => x.Quotes)
                .ToList();
        }
    }
}