using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.TicTacToeFolder;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get player's names
            // And then start game
            MainMenu.StartWelcome();

            // Exit Game
            Console.ReadLine();
        }
    }
}
