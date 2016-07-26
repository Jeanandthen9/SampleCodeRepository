using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.TicTacToeFolder
{
    class MainMenu
    {
        public static void StartWelcome()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string welcome = "LET'S PLAY TIC-TAC-TOE!";
            Console.SetCursorPosition((Console.WindowWidth - welcome.Length)/2, Console.CursorTop);

            Console.WriteLine(welcome);

            Console.WriteLine("\nHey there! Welcome to my Tic Tac Toe Game!\n");
            Console.WriteLine("Player 1! Please enter your name!");
            Console.Write("\t");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Players player1 = new Players();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Player 2! Please enter your name!");
            Console.Write("\t");
            Console.ForegroundColor = ConsoleColor.Green;
            Players player2 = new Players();

            // we're telling the code
            // that we want the values we used
            // for player1 and player2's ReadLine inputs
            // and use them in the TicTacToeGame class
            TicTacToeGame game = new TicTacToeGame()
            {
                Player1 = player1,
                Player2 = player2,
            };

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine($"Great!");
            Console.WriteLine("Our players are:\n");

            Console.Write("Player 1: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{player1.Name}\n");
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("Player 2: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{player2.Name}\n\n");
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Ready? Hit ENTER to start the game!");
            Console.ReadLine();

            // Start Game
            game.PlayerInput();
        }
    }
}
