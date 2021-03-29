using IntroToEF.Business;
using IntroToEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntroToEF
{
    public class EntityFactory
    {
        private SamuraiLogic _samuraiLogic;
        private QuoteLogic _quoteLogic;
        private HorseLogic _horseLogic;
        private BattleLogic _battleLogic;

        public EntityFactory()
        {
            _samuraiLogic = new SamuraiLogic();
            _battleLogic = new BattleLogic();
            _horseLogic = new HorseLogic();
            _quoteLogic = new QuoteLogic();
        }

        public Samurai SamuraiFactory()
        {
            Console.WriteLine("What is your Samurai name?(*Required)");
            var samurai = _samuraiLogic.NewSamurai(Console.ReadLine()); // not checking for valid input yet... empty user input can occur
            if (samurai.Id > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Samurai already exists! \nLeaving wizzard... ");
                Nav.ResetTextColor();
                Thread.Sleep(2000);
                return null;
            }

            Console.WriteLine("What is his Dynasty? (press enter to skip)");
            samurai.Dynasty = Console.ReadLine();
            bool result = false;
            do
            {
                Console.WriteLine($"Do you want to add a {(result ? "another " : "")}horse? (y/n)");
                result = Nav.IsYes();
                if (result)
                {
                    Console.WriteLine("Enter the name of the horse:");
                    samurai.Horses.Add(_horseLogic.CreateHorse(Console.ReadLine()));
                    Console.WriteLine("Horse has been added.");
                }
            } while (result);
            do
            {
                Console.WriteLine($"Do you want to add a {(result ? "another " : "")}quote? (y/n)");
                result = Nav.IsYes();
                if (result)
                {
                    Console.WriteLine("Enter the quote:");
                    samurai.Quotes.Add(_quoteLogic.NewQuote(Console.ReadLine()));
                    Console.WriteLine("Quote has been added.");
                }
            } while (result);

            return _samuraiLogic.CreateSamurai(samurai);
        }

        internal Battle BattleFactory()
        {
            Console.WriteLine("what is the name of the battle?");
            var battle = _battleLogic.NewBattle(Console.ReadLine());
            if (battle.Id > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Battle exists! Leaving wizzard... ");
                Nav.ResetTextColor();
                Thread.Sleep(2000);
                return null;
            }

            Console.WriteLine("What is the year of this Battle?(*Required: enter a valid year)");
            battle.Year = InputYear();
            return _battleLogic.CreateBattle(battle);
        }

        private int InputYear()
        {
            int year = 0, x = 0, y = Console.CursorTop;
            do
            {
                Console.SetCursorPosition(x, y);
                year = Convert.ToInt32(Console.ReadLine());
            } while (year < 1500);
            return year;
        }

        public List<Samurai> GetAllSamurai()
        {
            return _samuraiLogic.GetAllSamurais();
        }

        public void ListSamurai(List<Samurai> samurais)
        {
            int count = 0;
            foreach (Samurai samurai in samurais)
            {
                count++;
                Console.WriteLine($"({count}) Name: {samurai.Name} from Dynasty: {samurai.Dynasty}");
                foreach (Quote samuraiQuote in samurai.Quotes)
                {
                    Console.WriteLine($"Quote: {samurai.Name} once said: '{samuraiQuote.Text}'.");
                }
                int HorseCount = 1;
                foreach (Horse samuraiHorse in samurai.Horses)
                {
                    Console.WriteLine($"    Horse({HorseCount}): name {samuraiHorse.Name} " +
                        $"is{(samuraiHorse.IsWarHorse ? " Not " : " ")}a warhorse.");
                }
            }
        }
    }
}