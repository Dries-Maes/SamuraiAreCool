﻿using IntroToEF.Business;
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
            Console.WriteLine("What is your Samurai name?");
            var samurai = _samuraiLogic.NewSamurai(Console.ReadLine());
            if (samurai.Id > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Samurai exists! Leaving wizzard... ");
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
                    samurai.Quotes.Add(_quoteLogic.CreateQuote(Console.ReadLine()));
                    Console.WriteLine("Quote has been added.");
                }
            } while (result);

            return _samuraiLogic.CreateSamurai(samurai);
        }
    }
}