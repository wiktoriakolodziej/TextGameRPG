using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    class InvalidCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Invalid command");
            Console.ReadKey();
        }
    }
}
