using System;
using System.Drawing;
using Figgle;
using Console = Colorful.Console;

namespace Activity
{
    class Home
    {
        public static void MainHome()
        {
            while (true) 
            {
                Console.Clear(); 
                int consoleWidth = Console.WindowWidth;
                

                string title = @"       
                            ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌
                            ▐                                                                      ▌
                            ▐                                                                      ▌
                            ▐                                                                      ▌
                            ▐                                                                      ▌
                            ▐      █     █░▓█████  ██▓     ▄████▄   ▒█████   ███▄ ▄███▓▓█████      ▌
                            ▐     ▓█░ █ ░█░▓█   ▀ ▓██▒    ▒██▀ ▀█  ▒██▒  ██▒▓██▒▀█▀ ██▒▓█   ▀      ▌
                            ▐     ▒█░ █ ░█ ▒███   ▒██░    ▒▓█    ▄ ▒██░  ██▒▓██    ▓██░▒███        ▌
                            ▐     ░█░ █ ░█ ▒▓█  ▄ ▒██░    ▒▓▓▄ ▄██▒▒██   ██░▒██    ▒██ ▒▓█  ▄      ▌
                            ▐     ░░██▒██▓ ░▒████▒░██████▒▒ ▓███▀ ░░ ████▓▒░▒██▒   ░██▒░▒████▒     ▌
                            ▐     ░ ▓░▒ ▒  ░░ ▒░ ░░ ▒░▓  ░░ ░▒ ▒  ░░ ▒░▒░▒░ ░ ▒░   ░  ░░░ ▒░ ░     ▌
                            ▐       ▒ ░ ░   ░ ░  ░░ ░ ▒  ░  ░  ▒     ░ ▒ ▒░ ░  ░      ░ ░ ░  ░     ▌
                            ▐       ░   ░     ░     ░ ░   ░        ░ ░ ░ ▒  ░      ░      ░        ▌
                            ▐         ░       ░  ░    ░  ░░ ░          ░ ░         ░      ░  ░     ▌
                            ▐                             ░                                        ▌
                            ▐                                                                      ▌
                            ▐           Use arrow keys to navigate, press Enter to select.         ▌
                            ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌";

                Console.WriteLine(title, Color.Blue);

                string[] options = { "Register", "Login", "Products", "Delete Products", "Logout", "Exit"};
                int selectedIndex = 0;

                
                int menuStartY = 20; 
                int menuStartX = (consoleWidth / 2) - 5; 

                while (true)
                {
                   
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.SetCursorPosition(menuStartX - 3, menuStartY + i);
                        Console.Write(new string(' ', consoleWidth)); 
                    }

                    
                    for (int i = 0; i < options.Length; i++)
                    {
                        Console.SetCursorPosition(menuStartX, menuStartY + i);

                        if (i == selectedIndex)
                        {
                            Console.Write(">> ", Color.Green);
                            Console.WriteLine(options[i], Color.LimeGreen);
                        }
                        else
                        {
                            Console.Write("   ");
                            Console.WriteLine(options[i], Color.White);
                        }
                    }

                   
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedIndex = (selectedIndex + 1) % options.Length;
                            break;
                        case ConsoleKey.Enter:
                            ExecuteOption(selectedIndex);
                            return;
                    }
                }
            }
        }

        public static void ExecuteOption(int index)
        {
            Console.Clear();
            switch (index)
            {
                case 0:
                    Activity.Login_register.Register();
                    break;
                case 1:
                    Activity.Login_register.Login();
                    break;
                case 2:
                    Activity.Product.ProductMenu();
                    break;
                case 3:
                    Activity.DeleteProduct.Delete();
                    break;
                case 4:
                    Activity.Login_register.Logout();
                    break;
                case 5:
                    Console.WriteLine("Exiting...", Color.Red);
                    Environment.Exit(0);
                    break;


            }

            Console.WriteLine("\nPress any key to return to the menu...", Color.Red);
            Console.ReadKey();
            MainHome();
        }
    }
}
