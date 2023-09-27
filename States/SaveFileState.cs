using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TextGameRPG.Commands;

namespace TextGameRPG.States
{
    internal class SaveFileState : IState
    {
        private IState _lastState;
        private StateManager _stateManager;
        public SaveFileState(IState lastState, StateManager stateManager) { 
            _lastState = lastState;
            _stateManager = stateManager;
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
            return new SaveFileCommand(input, _stateManager);

        }

        public void Render()
        {
            Console.WriteLine("[file name] - a file you want your game to be saved in");
            Console.WriteLine("[back] - go back");
        }
    }
}

