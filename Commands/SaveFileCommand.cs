using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG.Commands
{
    internal class SaveFileCommand : ICommand
    {
        private string _fileName;
        private StateManager _manager;
        public SaveFileCommand(string fileName, StateManager manager)
        {
            _fileName = fileName;
            _manager = manager;
        }

        public void Execute()
        {   
              if (!_fileName.Contains(".txt"))
              {
                   _fileName += ".txt";
              }
            var currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory += "\\";
            currentDirectory += _fileName;
              File.Create(currentDirectory).Close();
            
            Console.WriteLine("loaded game files from file {0}", _fileName);
            Thread.Sleep(2000);
            var switchState = new SwitchStatetCommand(_manager, new LoadingState(new MainMenuState(_manager), _manager));
            switchState.Execute();
        }
    }
}
