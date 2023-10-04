using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    class StateManager
    {
        private IState _state;
        private bool _run;
        public Engine Engine { get; private set; }

        public StateManager(Engine engine)
        {
            Engine = engine;
        }
        public void SwitchState(IState state)
        {
            _state = state;
        }
        public void Run(IState InitialState)
        {
            _state = InitialState;
            _run = true;
            while (_run)
            {
                _state.Render();
                var command = _state.GetCommand();
                command.Execute();
                Console.Clear();
            }
            Console.WriteLine("END");
        }
        public void Exit()
        {
            _run = false;
        }
    }
}

