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
            var engine = new Engine();
            var stateManager = new StateManager(engine);

            stateManager.Run(new MainMenuState(stateManager));

            Console.ReadKey();
        }
    }
    
}


