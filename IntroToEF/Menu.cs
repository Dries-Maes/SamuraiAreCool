using System;
using IntroToEF.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroToEF.Data.Entities;

namespace IntroToEF
{
    public class Menu
    {
        private EntityFactory _entityFactory;

        private Nav _nav;

        private SearchEntities _searchEntities;

        private BattleLogic _battleLogic;

        public Menu()
        {
            _entityFactory = new EntityFactory();
            _nav = new Nav();
            _searchEntities = new SearchEntities();
            _battleLogic = new BattleLogic();
        }

        public void MainMenu()
        {
            _nav.MenuTopBanner("Add data", "Select Samurai", "Search Data", "Credits", "Exit");

            switch (_nav.MenuOptions(5))
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

                case 4:
                    Console.Clear();
                    _nav.ShowKatana();
                    Console.ReadKey();
                    Console.Clear();
                    MainMenu();
                    break;

                case 5:
                    Console.Clear();
                    Environment.Exit(0);
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }

        public void AddData()
        {
            _nav.MenuTopBanner("Add Samurai", "Add Battle", "Add Dynasty");

            switch (_nav.MenuOptions(3))
            {
                case 1:
                    Console.Clear();
                    _nav.MenuTopBanner("0");
                    Samurai createdSamurai = _entityFactory.SamuraiFactory();
                    Console.Clear();
                    if (createdSamurai != null)
                    {
                        UpdateSamurai(createdSamurai.Id);
                    }
                    AddData();
                    break;

                case 2:
                    Console.Clear();
                    Battle createdBattle = _entityFactory.BattleFactory();
                    Console.Clear();
                    if (createdBattle != null)
                    {
                        ToBeImplemented("Update Battles");
                        // UpdateBattle(createdBattle.Id);
                        AddData();
                    }
                    ToBeImplemented("Add Battle");
                    AddData();
                    break;

                case 3:
                    Console.Clear();
                    ToBeImplemented("Add Dynasty");
                    AddData();
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }

        public void SelectSamurai(List<Samurai> samurais = null)
        {
            _nav.MenuTopBanner("Update Samurai", "Delete Samurai");
            Waiting4DB();
            
            _entityFactory.ListSamurai(samurais == null? _entityFactory.GetAllSamurai():samurais);
            switch (_nav.MenuOptions(2))
            {
                case 1:
                    Console.WriteLine("Enter Samurai ID:");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    UpdateSamurai(ID);
                    break;

                case 2:
                    Console.Clear();
                    ToBeImplemented("Delete Samurai");
                    SelectSamurai();
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }

        private static void Waiting4DB()
        {
            Console.Write("Waiting for Database...");
            Console.CursorLeft = 0;
        }

        public void UpdateSamurai(int ID = 0)
        {
            _nav.MenuTopBanner("Update Name", "Update Dynasty", "Update Battles", "Update Horses", "Update Quotes");
            Console.WriteLine($"Displaying Samurai with ID {ID}: (to be added)");
            switch (_nav.MenuOptions(5))
            {
                case 1:
                    Console.Clear();
                    ToBeImplemented("Update Name");
                    UpdateSamurai();
                    break;

                case 2:
                    Console.Clear();
                    ToBeImplemented("Update Dynasty");
                    UpdateSamurai();
                    break;

                case 3:
                    Console.Clear();
                    ToBeImplemented("Update Battles");
                    UpdateSamurai();
                    break;

                case 4:
                    Console.Clear();
                    ToBeImplemented("Update Horses");
                    UpdateSamurai();
                    break;

                case 5:
                    Console.Clear();
                    ToBeImplemented("Update Quotes");
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
            _nav.MenuTopBanner("Search All", "Search Samurai", "Search Dynasty", "Search Horses", "Search Battles", "Search Quotes");

            switch (_nav.MenuOptions(6))
            {
                case 1:
                    Console.Clear();
                    ToBeImplemented("Search All");
                    SearchData();
                    break;

                case 2:
                    Console.Clear();
                    _nav.MenuTopBanner("0");
                    string input;
                    List<Samurai> result;

                    do
                    {
                    Console.WriteLine("Search our database for Samurai:");
                    input = Console.ReadLine();
                    Waiting4DB();
                    result = _searchEntities.PrintSamuraiContaining(input);
                        if (result.Count == 0)
                        {
                            Nav.PrintColor(ConsoleColor.Red, "-- ej, diene samurai, we én die ni gevonden eja --", true);
                        }
                    } while (result.Count == 0);

                    Console.Clear();
                    SelectSamurai(result);

                    SearchData();
                    break;

                case 3:
                    Console.Clear();
                    ToBeImplemented("Search Dynasty");
                    SearchData();
                    break;

                case 4:
                    Console.Clear();
                    ToBeImplemented("Search Horses");
                    SearchData();
                    break;

                case 5:
                    Console.Clear();
                    _nav.MenuTopBanner("0");
                    Console.WriteLine("Search our database for Battles:") ;
                    _entityFactory.ListBattles(_battleLogic.SearchBattlesByName(Console.ReadLine()));
                    Console.ReadLine();
                    SearchData();
                    break;

                case 6:
                    Console.Clear();
                    ToBeImplemented("Search Quotes");
                    SearchData();
                    break;

                case 0:
                    Console.Clear();
                    MainMenu();
                    break;
            };
        }

        public void ToBeImplemented(string what)

        {
            Console.WriteLine($"{what} is yet to be implemented! \nPress any key to go back");
            Console.ReadKey();
            Console.Clear();
        }
    }
}