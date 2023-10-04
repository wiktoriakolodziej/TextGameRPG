using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG.Commands
{
    internal class SaveGameCommand : ICommand
    {
        private string _fileName;
        private StateManager _manager;
        private Engine _engine;
        public SaveGameCommand(string fileName, StateManager manager, Engine engine)
        {
            _fileName = fileName;
            _manager = manager;
            _engine = engine;
        }

        public void Execute()
        {
            //if (!_fileName.Contains(".txt"))
            //{
            //     _fileName += ".txt";
            //}
            //var currentDirectory = Directory.GetCurrentDirectory();
            //currentDirectory += "\\";
            //currentDirectory += _fileName;
            //var file = File.Create(currentDirectory);

            //file.Close();
            var filePersistence = new GameFilePersistence();
            filePersistence.SaveGame(_fileName, _engine.CurrentGame);
            
            Console.WriteLine("game saved in file {0}", _fileName);
            Thread.Sleep(2000);
            var switchState = new SwitchStatetCommand(_manager, new LoadingState(new RoomState(_engine.CurrentGame.Player.CurrentRoom, _manager, _manager.Engine), _manager));
            switchState.Execute();
        }
    }
}

