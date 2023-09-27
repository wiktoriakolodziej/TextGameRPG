using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TextGameRPG
{

    internal class Program
    {
        static void Main(string[] args)
        {

            var stateManager = new StateManager();
            stateManager.Run(new MainMenuState(stateManager));

            Console.ReadKey();
        }
    }
    
}


