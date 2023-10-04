using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TextGameRPG.Commands;

namespace TextGameRPG.States
{
    internal class SaveGameState : IState
    {
        private IState _lastState;
        private StateManager _stateManager;
        private Engine _engine;
        public SaveGameState(IState lastState, StateManager stateManager, Engine engine) { 
            _lastState = lastState;
            _stateManager = stateManager;
            _engine = engine;
        }
        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
            if(input == "back")
            {
                return new SwitchStatetCommand(_stateManager, new LoadingState(_lastState, _stateManager));
            }
            if(input ==  null)
            {
                return new InvalidCommand();
            }
            return new SaveGameCommand(input, _stateManager, _engine);

        }

        public void Render()
        {
            Console.WriteLine("[file name] - a file you want your game to be saved in");
            Console.WriteLine("[back] - go back");
        }
    }
}

