using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    internal class LoadFileCommand : ICommand
    {
        private string _fileName;
        private StateManager _manager;
        public LoadFileCommand(string fileName, StateManager manager)
        {
            _fileName = fileName;
            _manager = manager;
        }
        public void Execute()
        {
            Console.WriteLine("loading game files from file {0}", _fileName);
            Thread.Sleep(1000);
            Console.WriteLine("You have succesfully loaded your files!");
            Thread.Sleep(2000);
            var switchState = new SwitchStatetCommand(_manager, new LoadingState(new MainMenuState(_manager), _manager));
            switchState.Execute();

        }
    }
}
