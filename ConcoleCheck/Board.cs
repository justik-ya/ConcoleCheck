using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleCheck
{
    class Board
    {
        protected const int boardSize = 8;
        protected static char[,] checkersBoard = new char[boardSize, boardSize];

        public void InitializeBoard()
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    checkersBoard[row, col] = (row + col) % 2 == 0 ? '#' : ' ';
                }
            }
        }

        public void DisplayBoard()
        {
            Rules rules = new Rules();
            char symb = 'A';
            Console.WriteLine("   1  2  3  4  5  6  7  8");
            Console.WriteLine("  +-----------------------+  ");
            for (int row = 0; row < boardSize; row++)
            {
                Console.Write(Convert.ToChar(symb + row) + " |");
                for (int col = 0; col < boardSize; col++)
                {
                    if (checkersBoard[row, col] == '@')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(checkersBoard[row, col]);
                        Console.ResetColor();
                        Console.Write(" |");
                    }
                    else if (checkersBoard[row, col] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(checkersBoard[row, col]);
                        Console.ResetColor();
                        Console.Write(" |");
                    }
                    else
                    {
                        Console.Write(checkersBoard[row, col] + " |");
                    }
                }
                Console.Write(" " + Convert.ToChar(symb + row));
                Console.WriteLine();
                Console.WriteLine("  +-----------------------+");
            }

            Console.WriteLine("   1  2  3  4  5  6  7  8");
        }
    }
}
