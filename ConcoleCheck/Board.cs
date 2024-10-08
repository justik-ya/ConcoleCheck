using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleCheck
{
    internal class Board
    {
        protected const int boardSize = 8;
        protected char[,] checkersBoard = new char[boardSize, boardSize]; 

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
            char symb = 'A';
            Console.WriteLine("   1  2  3  4  5  6  7  8");
            Console.WriteLine("  +-----------------------+");
            for (int row = 0; row < boardSize; row++)
            {
                Console.Write(Convert.ToChar(symb + row) + " |");
                for (int col = 0; col < boardSize; col++)
                {
                    Console.Write(checkersBoard[row, col] + " |");
                }
                Console.WriteLine();
                Console.WriteLine("  +-----------------------+");
            }
        }
    }
}
