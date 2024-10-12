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
                        checkersBoard[row, col] = '@';// Чёрные шашки
                    }
                }
            }

            for (int row = 5; row < 8; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    if (checkersBoard[row, col] == '#')
                    {
                        checkersBoard[row, col] = 'O'; // Белые шашки
                    }
                }
            }
        }
    }
}
