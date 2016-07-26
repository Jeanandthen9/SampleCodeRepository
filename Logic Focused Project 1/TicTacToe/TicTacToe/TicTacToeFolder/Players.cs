using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.TicTacToeFolder
{
    public class Players
    {
        // get the Names entered in the MainMenu class
        // and privately set them to be used
        // so that each Console.ReadLine is read
        // as a different entry
        public string Name { get; private set; }

        public Players()
        {
            Name = Console.ReadLine();
        }



    }
}
