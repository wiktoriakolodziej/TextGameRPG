using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    internal class StartNewGameState : IState
    {
        private StateManager _manager;
        private Engine _engine;

        public StartNewGameState(StateManager manager, Engine engine)
        {
            _manager = manager;
            _engine = engine;
        }

        public ICommand GetCommand()
        {
            var name = Console.ReadLine();
            return new StartNewGameComamnd(name, _manager, _engine);

        }

        public void Render()
        {
            Console.WriteLine("enter your name: ");
        }
    }
}
