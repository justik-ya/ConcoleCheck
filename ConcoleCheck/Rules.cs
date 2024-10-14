using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcoleCheck
{
    class Rules : Board
    {
        private bool isWhiteTurn = true;
        private bool firstMoveMade = false;
        private int blackCapturedCount = 0;
        private int whiteCapturedCount = 0;
        char currentPlayerChecker;
        public string GetCurrentPlayer()
        {
            return isWhiteTurn ? "белые" : "черные";
        }

        public bool MoveChecker(int startRow, int startCol, int endRow, int endCol)
        {
            currentPlayerChecker = isWhiteTurn ? 'O' : '@';

            if (!firstMoveMade && !isWhiteTurn)
            {
                Console.WriteLine("Черные шашки не могут делать первый ход.");
                return false;
            }

            if (checkersBoard[startRow, startCol] != currentPlayerChecker)
            {
                Console.WriteLine($"Это не ваша шашка. Ходят {GetCurrentPlayer()}.");
                return false;
            }

            if (IsValidMove(startRow, startCol, endRow, endCol))
            {
                checkersBoard[endRow, endCol] = checkersBoard[startRow, startCol];
                checkersBoard[startRow, startCol] = '#';

                if (Math.Abs(endRow - startRow) == 2 && Math.Abs(endCol - startCol) == 2)
                {
                    int capturedRow = (startRow + endRow) / 2;
                    int capturedCol = (startCol + endCol) / 2;
                    char capturedChecker = checkersBoard[capturedRow, capturedCol];

                    checkersBoard[capturedRow, capturedCol] = '#';
                    \
                    if (capturedChecker == 'O')
                    {
                        blackCapturedCount++;
                    }
                    else if (capturedChecker == '@')
                    {
                        whiteCapturedCount++;
                    }
                }

                isWhiteTurn = !isWhiteTurn;
                firstMoveMade = true;
                return true;
            }
            return false;
        }

        private bool IsValidMove(int startRow, int startCol, int endRow, int endCol)
        {
            if (endRow < 0 || endRow >= boardSize || endCol < 0 || endCol >= boardSize)
                return false;

            if (checkersBoard[endRow, endCol] != '#')
                return false;

            int direction = checkersBoard[startRow, startCol] == '@' ? 1 : -1;
            if ((endRow - startRow == direction) && Math.Abs(endCol - startCol) == 1)
                return true;

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
