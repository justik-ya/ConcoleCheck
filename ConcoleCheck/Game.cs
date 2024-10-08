using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleCheck
{
    class Game : Checker
    {
        private Checker checker;
        
        public Game()
        {
            checker = new Checker();
            checker.InitializeBoard();
            checker.PlaceCheckers();
        }
        public void EnteringMove()
        {

        }
        public void Start()
        {

            Rules rules = new Rules();
            bool isWiteTurn = true;

            

            while (true)
            {
                Console.Clear();
                rules.BeginningOfGame();
                checker.DisplayBoard();

                if (isWiteTurn)
                {
                    Console.WriteLine("Ход белых");
                    isWiteTurn=false;
                }
                else
                {
                    Console.WriteLine("Ход черных");
                    isWiteTurn = true;
                }

                Console.WriteLine("Введите координаты шашки для перемещения (например: A3 B4): ");
                string input = Console.ReadLine();

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

                

                    if (!checker.MoveChecker(startRow, startCol, endRow, endCol))
                {
                    Console.WriteLine("Некорректный ход. Попробуйте снова.");
                    Console.ReadKey();
                }
            }
        }

    }
}
