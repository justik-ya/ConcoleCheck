using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rules rules = new Rules();
            Checker checker = new Checker();
            checker.InitializeBoard();
            checker.PlaceCheckers();
            bool isGameTrue = true;

            while (isGameTrue)
            {
                Console.Clear();
                Console.WriteLine("Как играть:\n O - белые шашки\n @ - черные шашки\n Введите -1 если хотите закончить игру \n");
                checker.DisplayBoard();
                rules.DisplayCapturedCount();
                Console.WriteLine($"Ход: {rules.GetCurrentPlayer()}");

                Console.WriteLine("Введите координаты шашки для перемещения (например: A3 B4): ");
                string input = Console.ReadLine();
                int intInput = int.Parse( input );

                if (intInput == -1)
                {
                    isGameTrue = false;
                }

                if (string.IsNullOrWhiteSpace(input))
                    break;

                var parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Неверный формат ввода. Попробуйте снова.");
                    continue;
                }

                var start = parts[0];
                var end = parts[1];

                int startCol = int.Parse(start[1].ToString()) - 1;
                int startRow = start[0] - 'A';
                int endCol = int.Parse(end[1].ToString()) - 1;
                int endRow = end[0] - 'A';

                if (!rules.MoveChecker(startRow, startCol, endRow, endCol))
                {
                    Console.WriteLine("Некорректный ход. Попробуйте снова.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Игра окончена");
        }
    }

}


