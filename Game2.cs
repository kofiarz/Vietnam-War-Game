namespace Game
{
    class Game2
    {
        public void Start()
        {
            DisplayIntro();
            var s1 = (DateTime.UtcNow - DateTime.MinValue).TotalMilliseconds;
            while (true)
            {
                Console.Clear();
                Random rand = new Random();
                List<string> characters = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        int random1 = rand.Next(1,4);
                        for (int j = 0; j < random1; j++)
                        {
                            Console.Write("1");
                        }
                        int random2 = rand.Next(1,4);
                        for (int j = 0; j < random2; j++)
                        {
                            characters.Add("I");
                            Console.Write("I");
                        }
                    }
                    Console.WriteLine();
                }
                
                while (true)
                {
                    Console.Write("\nPodaj, ilu Wietnamczyków zliczyłeś: ");
                    string result = Console.ReadLine();
                    try
                    {
                        int x = Convert.ToInt32(result);
                    }
                    catch (System.FormatException)
                    {
                        DisplayOutro("Przedstawiłeś dziwne dane - nie mogą stanowić rzetelnego raportu. Wpadliście w tarapaty!");
                        break;
                    }
                    if (Convert.ToInt32(result) == characters.Count)
                    {
                        var s2 = (DateTime.UtcNow - DateTime.MinValue).TotalMilliseconds;
                        if ((s2 - s1) > 30000)
                        {
                            DisplayOutro("Niestety! Nie zdążyłeś zdać raportu, przez co twoja kompania wpadła w tarapaty!");
                            break;
                        }
                        DisplayOutro("Świetnie! Przedstawiłeś raport, dzięki czemu kompania oddaliła się bezpieczenie!");
                        break;
                    }
                    else
                    {
                        DisplayOutro("Niestety! Zdałeś błędny raport, przez co twoja kompania wpadła w tarapaty!");
                        break;
                    }

                }
                break;
            }
        }
        private void DisplayIntro()
        {
            Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine("Twoim zadaniem jest zdać raport z obserwacji dżungli!" +
                "\nW gąszczu drzew ledwo odróżniasz kształty, więc zadanie nie jest proste." +
                "\nPodaj dokładną liczbę chowających się Wietnamczyków zaznaczonych poprzez I - masz na to tylko 30 sekund!" +
                "\n\nNaciśnij dowolny klawisz, aby rozpocząć...");
            Console.ReadKey(true);
        }
        private void DisplayOutro(string message)
        {
            Console.ForegroundColor = ConsoleColor.Black; // https://www.youtube.com/watch?v=bBDmL0U-4U8
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey(true);
        }
    }
}
