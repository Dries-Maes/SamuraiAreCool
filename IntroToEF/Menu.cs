using System;
using IntroToEF.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF
{
    public class Menu
    {
        private Logic logic;

        private Nav nav;

        public Menu()
        {
            logic = new Logic();
            nav = new Nav();
        }

        public void MainMenu()
        {
            nav.MenuTopBanner("Add data", "Select Samurai", "Search Data");

            switch (nav.MenuOptions(3))
            {
                case 1:
                    Console.Clear();
                    AddData();
                    break;

                case 2:
                    Console.Clear();
                    SelectSamurai();
                    break;

                case 3:
                    Console.Clear();
                    SearchData();
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }

        public void AddData()
        {
            nav.MenuTopBanner("Add Samurai", "Add Battle", "Add Dynasty");

            switch (nav.MenuOptions(3))
            {
                case 1:
                    Console.Clear();
                    logic.ToBeImplemented("Add Samurai");
                    AddData();
                    break;

                case 2:
                    Console.Clear();
                    logic.ToBeImplemented("Add Battle");
                    AddData();
                    break;

                case 3:
                    Console.Clear();
                    logic.ToBeImplemented("Add Dynasty");
                    AddData();
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }

        public void SelectSamurai()
        {
            nav.MenuTopBanner("Update Samurai", "Delete Samurai");

            switch (nav.MenuOptions(2))
            {
                case 1:
                    Console.Clear();
                    UpdateSamurai();
                    break;

                case 2:
                    Console.Clear();
                    logic.ToBeImplemented("Delete Samurai");
                    SelectSamurai();
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }

        public void UpdateSamurai()
        {
            nav.MenuTopBanner("Update Name", "Update Dynasty", "Update Battles", "Update Horses", "Update Quotes");

            switch (nav.MenuOptions(5))
            {
                case 1:
                    Console.Clear();
                    logic.ToBeImplemented("Update Name");
                    UpdateSamurai();
                    break;

                case 2:
                    Console.Clear();
                    logic.ToBeImplemented("Update Dynasty");
                    UpdateSamurai();
                    break;

                case 3:
                    Console.Clear();
                    logic.ToBeImplemented("Update Battles");
                    UpdateSamurai();
                    break;

                case 4:
                    Console.Clear();
                    logic.ToBeImplemented("Update Horses");
                    UpdateSamurai();
                    break;

                case 5:
                    Console.Clear();
                    logic.ToBeImplemented("Update Quotes");
                    UpdateSamurai();
                    break;

                case 0:
                    Console.Clear();
                    SelectSamurai();
                    break;
            };
        }

        public void SearchData()
        {
            nav.MenuTopBanner("Search All", "Search Samurai", "Search Dynasty", "Search Horses", "Search Battles", "Search Quotes");

            switch (nav.MenuOptions(6))
            {
                case 1:
                    Console.Clear();
                    logic.ToBeImplemented("Search All");
                    SearchData();
                    break;

                case 2:
                    Console.Clear();
                    logic.ToBeImplemented("Search Samurai");
                    SearchData();
                    break;

                case 3:
                    Console.Clear();
                    logic.ToBeImplemented("Search Dynasty");
                    SearchData();
                    break;

                case 4:
                    Console.Clear();
                    logic.ToBeImplemented("Search Horses");
                    SearchData();
                    break;

                case 5:
                    Console.Clear();
                    logic.ToBeImplemented("Search Battles");
                    SearchData();
                    break;

                case 6:
                    Console.Clear();
                    logic.ToBeImplemented("Search Quotes");
                    SearchData();
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }
    }
}