using IntroToEF.Data.Entities;
using IntroToEF.Data.Repositories;
using System;
using System.Collections.Generic;

namespace IntroToEF.Business
{
    public class Logic
    {
        // Composition
        private ISamuraiRepo _repo;

        public Logic()
        {
            _repo = new SamuraiRepo();
        }

        public void ToBeImplemented(string what)

        {
            Console.WriteLine($"{what} is yet to be implemented! \nPress any key to go back");
            Console.ReadKey();
            Console.Clear();
        }

        public void RunApp()
        {
            //RenameSamurai(9, "I was changed from the app");
            //RenameMultipleSamurais();
            //RemoveSamurai(10);

            //AddSamuraiWhoFoughtInBattles();
            //var sam = GetSamuraiWithBattles(12);
            //var SPResult = GetSamuraiWhoSaidAWord("thank");
        }

        public List<Samurai> GetSamuraiWhoSaidAWord(string word)
        {
            var result = _repo.GetResultFromStoredProcedure(word);
            return result;
        }

        public void RemoveSamurai(int id)
        {
            _repo.DeleteSamurai(id);
        }

        public void AddSamuraiWithHorses()
        {
            var samurai = new Samurai
            {
                Name = "Samurai With Horses",
                Dynasty = "Sengoku",
                Horses = new List<Horse>
                {
                    new Horse
                    {
                        IsWarHorse = true,
                        Name = "Roach"
                    },
                    new Horse
                    {
                        IsWarHorse = false,
                        Name = "Boeddika"
                    }
                }
            };

            _repo.AddSamurai(samurai);
        }

        public void AddSamuraiWhoFoughtInBattles()
        {
            Samurai veteran = new Samurai
            {
                Name = "A weary broken man",
                Battles = new List<Battle>
                {
                    new Battle
                    {
                        Name = "Okinagawa",
                        Year = 1557
                    },
                    new Battle
                    {
                        Name = "Fukushima",
                        Year = 2011
                    }
                }
            };

            _repo.AddSamurai(veteran);
        }

        public void ShowSamurai()
        {
            var samurais = _repo.GetSamurais();
        }

        public void GetAllSamurais()
        {
            var samurais = _repo.GetSamurais();
            foreach (Samurai samurai in samurais)
            {
                Console.WriteLine($"Name: {samurai.Name} from Dynasty: {samurai.Dynasty}");
                foreach (Quote samuraiQuote in samurai.Quotes)
                {
                    Console.WriteLine(samurai.Name + " once said:" + samuraiQuote);
                }
                int HorseCount = 1;
                foreach (Horse samuraiHorse in samurai.Horses)
                {
                    Console.WriteLine($"Horse {HorseCount} runs by name {samuraiHorse.Name} " +
                        $"is{(samuraiHorse.IsWarHorse ? " Not " : " ")}a warhorse");
                }
            }
        }

        public void RenameSamurai(int id, string name)
        {
            // Get element from DB
            Samurai samuraiToBeUpdated = _repo.GetSamurai(id);

            // Perform changes
            samuraiToBeUpdated.Name = name;

            // Save object back to db
            _repo.UpdateSamurai(samuraiToBeUpdated);
        }

        public void RenameMultipleSamurais()
        {
            // Bad practice -> Code in datalayer should go here.
            _repo.UpdateSamurais();
        }

        public Samurai GetSamuraiWithBattles(int id)
        {
            return _repo.GetSamurai(id, true);
        }

        public void AddSamurai()
        {
            string name = InputName();
            string dynasty = InputDynasty();
            List<Horse> horses = InputHorses();
            var samurai = new Samurai
            {
                Name = name,
                Dynasty = dynasty,
                Horses = horses
            };
        }

        public string InputName()
        {
            Console.Write("Name of the Samurai to add:");
            string name = Console.ReadLine();
            // to do add valid input checks
            return name;
        }

        public string InputDynasty()
        {
            Console.Write("Dynasty of the Samurai to add:");
            string dynasty = Console.ReadLine();
            // to do add valid input checks
            return dynasty;
        }

        public List<Horse> InputHorses()
        {
            List<Horse> horses = new List<Horse>();
            bool AddAnotherHorse = false;
            do
            {
                Console.Write("The name of this Horse:");
                string name = Console.ReadLine();
                // to do add valid input checks
                Console.Write("Do You want to add another horse?(Y/N)");

                string key = YesNo();
                if ("Yy".Contains(key)) AddAnotherHorse = true;
            } while (AddAnotherHorse);
            return horses;
        }

        private static string YesNo()
        {
            string key;
            do
            {
                key = Console.ReadKey().ToString();
            } while (!"YyNn".Contains(key));
            return key;
        }
    }
}