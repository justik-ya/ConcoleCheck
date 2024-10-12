using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleCheck
{
    class Rules : Board
    {
        private bool isWhiteTurn = true; // Переменная для определения, чей ход
        private bool firstMoveMade = false; // Флаг первого хода
        private int blackCapturedCount = 0; // Счетчик срубленных черных шашек
        private int whiteCapturedCount = 0; // Счетчик срубленных белых шашек
        char currentPlayerChecker;
        public string GetCurrentPlayer()
        {
            return isWhiteTurn ? "белые" : "черные";
        }

        public bool MoveChecker(int startRow, int startCol, int endRow, int endCol)
        {
            currentPlayerChecker = isWhiteTurn ? 'O' : '@'; // Определяем шашку текущего игрока

            // Запрет первым ходом двигать черные шашки
            if (!firstMoveMade && !isWhiteTurn)
            {
                Console.WriteLine("Черные шашки не могут делать первый ход.");
                return false;
            }

            // Проверка на то, что шашка, которая ходит, принадлежит текущему игроку
            if (checkersBoard[startRow, startCol] != currentPlayerChecker)
            {
                Console.WriteLine($"Это не ваша шашка. Ходят {GetCurrentPlayer()}.");
                return false;
            }

            // Проверка на корректность хода
            if (IsValidMove(startRow, startCol, endRow, endCol))
            {
                // Перемещение шашки
                checkersBoard[endRow, endCol] = checkersBoard[startRow, startCol];
                checkersBoard[startRow, startCol] = '#'; // Убираем шашку с начальной позиции

                // Проверка на рубку шашек
                if (Math.Abs(endRow - startRow) == 2 && Math.Abs(endCol - startCol) == 2)
                {
                    int capturedRow = (startRow + endRow) / 2;
                    int capturedCol = (startCol + endCol) / 2;
                    char capturedChecker = checkersBoard[capturedRow, capturedCol];

                    checkersBoard[capturedRow, capturedCol] = '#'; // Удаляем срубленную шашку

                    // Увеличиваем счетчик срубленных шашек
                    if (capturedChecker == 'O')
                    {
                        blackCapturedCount++;
                    }
                    else if (capturedChecker == '@')
                    {
                        whiteCapturedCount++;
                    }
                }

                isWhiteTurn = !isWhiteTurn; // Меняем ход
                firstMoveMade = true; // Отмечаем, что первый ход сделан
                return true;
            }
            return false;
        }

        private bool IsValidMove(int startRow, int startCol, int endRow, int endCol)
        {
            // Проверка на границы доски
            if (endRow < 0 || endRow >= boardSize || endCol < 0 || endCol >= boardSize)
                return false;

            if (checkersBoard[endRow, endCol] != '#')
                return false;

            // Проверка на правильность направления и расстояния
            int direction = checkersBoard[startRow, startCol] == '@' ? 1 : -1;
            if ((endRow - startRow == direction) && Math.Abs(endCol - startCol) == 1)
                return true;

            // Проверка на рубку
            if ((endRow - startRow == 2 * direction) && Math.Abs(endCol - startCol) == 2)
            {
                int capturedRow = (startRow + endRow) / 2;
                int capturedCol = (startCol + endCol) / 2;
                return checkersBoard[capturedRow, capturedCol] != '#' && checkersBoard[capturedRow, capturedCol] != currentPlayerChecker;
            }

            return false;
        }

        public void DisplayCapturedCount()
        {
            Console.WriteLine($"Черные срубили: {blackCapturedCount}");
            Console.WriteLine($"Белые срубили: {whiteCapturedCount} ");
        }
    }
}
