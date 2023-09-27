using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    class HelpCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("HELP!");
            Console.ReadKey();
        }
    }
}

