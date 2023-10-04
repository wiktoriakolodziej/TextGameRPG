using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    internal class LoadGameCommand : ICommand
    {
        private string _fileName;
        private StateManager _manager;
        private Engine _engine;
        public LoadGameCommand(string fileName, StateManager manager, Engine engine)
        {
            _fileName = fileName;
            _manager = manager;
            _engine = engine;   
        }
        public void Execute()
        {
            Console.WriteLine("loading game files from file {0}", _fileName);
            var filePersistence = new GameFilePersistence();
            _manager.Engine.CurrentGame = filePersistence.LoadGame(_fileName);
            var switchState = new SwitchStatetCommand(_manager, new LoadingState(new RoomState(_engine.CurrentGame.Player.CurrentRoom,_manager, _manager.Engine), _manager));
            switchState.Execute();

        }
    }
}
