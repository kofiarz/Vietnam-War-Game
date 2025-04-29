using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//https://www.youtube.com/watch?v=T0MpWTbwseg
namespace Game
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            string[,] grid =
            {
                { "█", "█", "█", "█", "█", "█", "█"},
                { "█", " ", "█", " ", " ", " ", "X"},
                { " ", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", " ", " ", "█", " ", "█"},
                { "█", "█", " ", "█", "█", "█", "█"},
                { "█", " ", " ", "█", "█", "█", "█"},
                { "█", " ", "█", " ", " ", " ", " "},
                { "█", " ", " ", " ", "█", "█", "█"},
                { "█", "█", "█", "█", "█", "█", "█"},

            };
            MyWorld = new World(grid);

            CurrentPlayer = new Player(0, 2);

            DisplayIntro();
            RunGameLoop();
            DisplayOutro();

        }
        private void DisplayIntro()
        {
            Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine("Twoim zadaniem jest przedrzeć się przez las, gdzie czekają już na Ciebie Twoi kompani!" +
                "\nJednak jest już ciemno, gęsta dżungla nie pozwala na dobrą orientację w terenie, a Ty nie wiesz, gdzie się znajdujesz..." +
                "\nMetodą prób i błędów znajdź wyjście, by uniknąć amerykańskiego napalmu!" +
                "\n\nNaciśnij dowolny klawisz, aby rozpocząć...");
            Console.ReadKey(true);
        }
        private void DisplayOutro()
        {
            Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine("Udało Ci się przedrzeć przez dżunglę!\n\nNaciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey(true);
        }
        private void DrawFrame()
        {
            Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                default:
                    break;
            }
        }
        private void RunGameLoop()
        {
            
            while (true)
            {
                //Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
                //Console.BackgroundColor = ConsoleColor.DarkGreen;
                
                DrawFrame();
                HandlePlayerInput();
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "X") break;
                Thread.Sleep(20);
            }
        }
    }

}
