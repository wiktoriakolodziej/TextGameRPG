using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    class SwitchStatetCommand : ICommand
    {
        private StateManager _manager;
        private IState _newState;
        public SwitchStatetCommand(StateManager manager, IState newState)
        {
            _manager = manager;
            _newState = newState;
        }
        public void Execute()
        {
            _manager.SwitchState(_newState);
        }
    }
}
