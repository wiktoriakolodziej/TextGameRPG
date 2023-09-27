using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    class LoadingState : IState
    {
        private IState _nextState;
        private StateManager _manager;
        public LoadingState(IState nextState, StateManager manager)
        {
            _nextState = nextState;
            _manager = manager;
        }
        public ICommand GetCommand()
        {
            for(int x = 0; x < 3; x++)
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }
          
            return new SwitchStatetCommand(_manager, _nextState);
        }

        public void Render()
        {
            Console.WriteLine("loading ...");
        }
    }
}
