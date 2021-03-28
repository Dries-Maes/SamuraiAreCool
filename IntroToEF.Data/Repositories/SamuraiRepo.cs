using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Data.Repositories
{
    class SamuraiRepo
    {
        private SamuraiAreCoolContext context;

        public SamuraiRepo()
        {
            // Open connection to database
            context = new SamuraiAreCoolContext();
        }
    }
}