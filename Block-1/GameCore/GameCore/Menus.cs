﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameCore.Constants;

namespace GameCore
{
    class Menus
    {
        public static string[] MenuStr = { "For Honour\n", "Главное меню", "Нажмите для просмотра особенностей класса героя:" };
        static void Header()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - MenuStr[0].Length / 2, 0);
            Console.WriteLine(MenuStr[0]);
        }
        static void Footer()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("ESC чтобы вернуться.");
        }
        public static void Menu()
        {
            Header();
            Console.SetCursorPosition(Console.WindowWidth / 2 - MenuStr[1].Length / 2, 2);
            Console.WriteLine(MenuStr[1]);
            Console.SetCursorPosition(Console.WindowWidth / 2 - MenuStr[2].Length / 2, 4);
            Console.WriteLine(MenuStr[2]);
            for (int i = 0; i < Constants.Classes.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 6, 5 + i);
                Console.WriteLine($"{i + 1}: {Constants.Classes[i]}.");
            }
            Footer();
        }

        public static ConsoleKey ClassesDescriptions()
        {
            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                        Header();
                        Vanguard.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.D2:
                        Header();
                        Assassin.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.D3:
                        Header();
                        Heavy.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.D4:
                        Header();
                        Hybrid.description();
                        Footer();
                        return cur_key;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Menu();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return cur_key;
        }

        public static int HeroesPick(ConsoleKey key)
        {
            ConsoleKey cur_key;
            do
            {
                cur_key = Console.ReadKey().Key;
                switch (cur_key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                        Header();
                        var hero_number = 4 * ((int)key - 49) +
                            (int)cur_key - 49;
                        Console.WriteLine($"Вы выбрали: {Constants.Names[hero_number]}.");
                        Footer();
                        return hero_number;
                    case ConsoleKey.Escape:
                        break;
                    default:
                        Menu();
                        break;
                }
            } while (cur_key != ConsoleKey.Escape);
            return -1;
        }
    }
}
