using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Media;

namespace Game
{
    class Program
    {
        public static List<Option> options;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.Title = "Wojna w Wietnamie";
            Console.CursorVisible = false;

            Music music = new Music();
            music.Playmusic();
            


            options = new List<Option> //https://stackoverflow.com/questions/58760184/how-to-implement-a-console-menu-having-submenus-in-c-sharp
            {
                new Option("Wietnam Północny (wspierany przez ZSRR)", () => NorthVietnam()),
                new Option("Wietnam Południowy (wspierany przez Stany Zjednoczone)", () =>  SouthVietnam()),
                new Option("WYJDŹ Z GRY", () => Environment.Exit(0)),
            };

            // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            WriteMenu(options, options[index]);

            // Store key info in here
            ConsoleKeyInfo keyinfo;
            do
            {
                
                keyinfo = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }

                // Handle different action for the option
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
                


            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();

        }
        static void NorthVietnam()
        {
            Game currentGame = new Game();
            currentGame.Start();
            WriteMenu(options, options.First());
        }
        static void SouthVietnam()
        {
            Game2 currentGame2 = new Game2();
            currentGame2.Start();
            WriteMenu(options, options.First());
        }
        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(500);
            WriteMenu(options, options.First());
        }


        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Printing printing = new Printing();
            printing.Print();
            Console.WriteLine("\nWitaj żołnierzu! Wybierz stronę, po której walczysz: \n");
            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
            }
        }
    }
}


