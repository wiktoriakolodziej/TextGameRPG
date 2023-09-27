using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    internal class NewGameCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Starting a New Game!");
            Console.ReadKey();
        }
    }
}
