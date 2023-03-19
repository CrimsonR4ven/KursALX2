using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwnThings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int boardSize = 10;
            int[,] board = new int[boardSize, boardSize];
            int numShips = 5;
            int numSunk = 0;

            Random random = new Random();

            // Place ships randomly on the board
            for (int i = 0; i < numShips; i++)
            {
                int row = random.Next(boardSize);
                int col = random.Next(boardSize);
                board[row, col] = 1;
            }

            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("There are " + numShips + " ships on the board.");
            Console.WriteLine();

            while (numSunk < numShips)
            {
                // Get user input
                Console.Write("Enter row (0-" + (boardSize - 1) + "): ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter column (0-" + (boardSize - 1) + "): ");
                int col = int.Parse(Console.ReadLine());

                // Check if there's a ship at the user's guess
                if (board[row, col] == 1)
                {
                    Console.WriteLine("Hit!");
                    board[row, col] = 2;
                    numSunk++;

                    // Check if all ships have been sunk
                    if (numSunk == numShips)
                    {
                        Console.WriteLine("You win!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Miss!");
                }
            }
        }
        
    }
}
