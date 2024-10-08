using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleCheck
{
    class Checker : Board
    {
        public void PlaceCheckers()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (checkersBoard[row, col] == '#')
                    {
                        checkersBoard[row, col] = '@';
                    }
                }
            }

            for (int row = 5; row < 8; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (checkersBoard[row, col] == '#')
                    {
                        checkersBoard[row, col] = 'O';
                    }
                }
            }
        }

        public bool MoveChecker(int startRow, int startCol, int endRow, int endCol)
        {
            if (checkersBoard[startRow, startCol] == '@')
            {
                Console.WriteLine("Первыми ходят белые.");
                return false;
            }
            // Проверка на корректность хода
            if (IsValidMove(startRow, startCol, endRow, endCol))
            {
                // Перемещение шашки
                checkersBoard[endRow, endCol] = checkersBoard[startRow, startCol];
                checkersBoard[startRow, startCol] = '#'; // Убираем шашку с начальной позиции
                return true;
            }
            return false;
        }

        private bool IsValidMove(int startRow, int startCol, int endRow, int endCol)
        {

            // Проверка на границы доски
            if (endRow < 0 || endRow >= boardSize || endCol < 0 || endCol >= boardSize)
                return false;

            // Проверка на возможность перемещения
            if (checkersBoard[endRow, endCol] != '#')
                return false;

            // Проверка на правильность направления и расстояния
            int direction = checkersBoard[startRow, startCol] == '@' ? 1 : -1;
            if ((endRow - startRow == direction) && Math.Abs(endCol - startCol) == 1)
                return true;

            return false;
        }
    }
}
