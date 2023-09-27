using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    class ExitCommand : ICommand
    {
        private StateManager _manager;
        public ExitCommand(StateManager manager)
        {
            _manager = manager;
        }
        public void Execute()
        {
            _manager.Exit();
        }
    }

}
