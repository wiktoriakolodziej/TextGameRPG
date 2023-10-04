using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGameRPG.States;

namespace TextGameRPG
{
    class MainMenuState : IState
    {
        private StateManager _manager;
        private Engine _engine;

        public MainMenuState(StateManager manager)
        {
            _manager = manager;
            _engine = _manager.Engine;
        }

        public void Render()
        {
            Console.WriteLine("[help] - show help");
            Console.WriteLine("[continue] - continue game (you must load game before)");
            Console.WriteLine("[exit] - exit game");
            //Console.WriteLine("[save] - save the game");
            Console.WriteLine("[load game] - load saved game from given file");
            Console.WriteLine("[new game] - start a new game");
        }

        public ICommand GetCommand()
        {
            var command = Console.ReadLine();
            if (command == "continue")
            {
                if(_engine.CurrentGame == null)
                {
                    return new InvalidCommand();
                }
                return new SwitchStatetCommand(_manager, new LoadingState(new RoomState(_engine.CurrentGame.Player.CurrentRoom, _manager, _engine), _manager));
            }
            if (command == "help")
            {
                return new HelpCommand();
            }
            if (command == "exit")
            {
                return new ExitCommand(_manager);
            }
            //if(command == "save")
            //{
            //    return new SwitchStatetCommand(_manager, new LoadingState(new SaveGameState(this, _manager), _manager));
            //}
            if(command == "load game")
            {
                _manager.Engine.FilePersistence = new GameFilePersistence();
                return new SwitchStatetCommand(_manager, new LoadingState(new LoadGameState(_manager, _engine), _manager));
            }
            if (command == "new game")
            {
                return new SwitchStatetCommand(_manager, new LoadingState(new StartNewGameState(_manager, _engine), _manager));
            }
            return new InvalidCommand();
        }   
    }
}

