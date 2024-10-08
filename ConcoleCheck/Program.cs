using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Board
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

class Game
{
    private Checker checker;

    public Game()
    {
        checker = new Checker();
        checker.InitializeBoard();
        checker.PlaceCheckers();
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            checker.DisplayBoard();

            Console.WriteLine("Введите начальную позицию (например, 'A1'): ");
            string startInput = Console.ReadLine();
            int startCol = Convert.ToInt32(startInput[1].ToString()) - 1;
            int startRow = startInput[0] - 'A';

            Console.WriteLine("Введите конечную позицию (например, 'B2'): ");
            string endInput = Console.ReadLine();
            int endCol = Convert.ToInt32(endInput[1].ToString()) - 1;
            int endRow = endInput[0] - 'A';

            if (!checker.MoveChecker(startRow, startCol, endRow, endCol))
            {
                Console.WriteLine("Некорректный ход. Попробуйте снова.");
                Console.ReadKey();
            }
        }
    }



class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}


