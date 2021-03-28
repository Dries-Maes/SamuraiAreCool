using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToEF.Business
{
    public class Nav
    {
        public int MenuOptions(int menuAantal)
        {
            int menuAantalIntern = menuAantal;
            List<int> keuzelijst = new List<int>();
            do
            {
                keuzelijst.Add(menuAantalIntern);
                menuAantalIntern--;
            } while (menuAantalIntern != 0);
            keuzelijst.Add(0);
            int input;
            int output = 0;
            do
            {
                input = (int)(Console.ReadKey().Key);
                if (keuzelijst.Contains(input - 96))
                {
                    output = input - 96;
                    input = 0;
                }
                else if (keuzelijst.Contains(input - 111))
                {
                    output = input - 111;
                    input = 0;
                }
                else if (keuzelijst.Contains(input - 48))
                {
                    output = input - 48;
                    input = 0;
                }
                Console.CursorLeft = 0;
                Console.Write(" ");
                Console.CursorLeft = 0;
            } while (input != 0);
            return output;
        }

        public void MenuTopBanner(string in1 = null, string in2 = null, string in3 = null, string in4 = null, string in5 = null, string in6 = null, string in7 = null)
        {
            int noBack = 1;
            if (in1 == "0")
            {
                in1 = null;
                noBack = 0;
            }

            string[] menuItems = new string[7] { in1, in2, in3, in4, in5, in6, in7 };
            List<string> usedItems = new List<string>();
            foreach (var item in menuItems)
            {
                if (!String.IsNullOrEmpty(item)) usedItems.Add(item);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            string HorizontaleLijn = new String('─', Console.WindowWidth - 1);
            Console.WriteLine(HorizontaleLijn);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (noBack != 0)
            {
                Console.Write(" 0 = Terug ".PadRight(Console.WindowWidth / 3 - 1));
            }
            else
            {
                Console.Write(" Vul in  ".PadRight(Console.WindowWidth / 3 - 1));
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(PadLeftRight(" S A M U R A I  -  A R E  -  C O O L ".PadRight(30).ToUpper(), Console.WindowWidth / 3));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DateTime.Now} ".PadLeft(Console.WindowWidth / 3));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(HorizontaleLijn);
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (usedItems.Count != 0)
            {
                Console.Write(" ");
                for (int j = 0; j < usedItems.Count; j++)
                {
                    Console.Write(PadLeftRight($"{j + 1}.{usedItems[j]} ", Console.WindowWidth / usedItems.Count - 2));
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n" + HorizontaleLijn);
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public string PadLeftRight(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);
        }

        public void ShowKatana()
        {
            string katana =
@"                                          /\  S a m u r a i  A r e  C o o l ______,....------,
                            /VVVVVVVVVVVVVV|=======================""""""""""""""""""        ___,..--'
                            `^^^^^^^^^^^^^^|=========================-----------""""""""
                                          \/";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(katana);
            Console.ResetColor();
        }

        public static bool IsYes()
        {
            char key;
            do
            {
                key = Console.ReadKey().KeyChar;
                Console.CursorLeft = 0;
            } while (!"YyNn".Contains(key));

            return "yY".Contains(key);
        }

        public static void ResetTextColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}