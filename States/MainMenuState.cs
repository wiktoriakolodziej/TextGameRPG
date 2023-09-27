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

        public MainMenuState(StateManager manager)
        {
            _manager = manager;
        }

        public void Render()
        {
            Console.WriteLine("[help] - show help");
            Console.WriteLine("[load game] - load game");
            Console.WriteLine("[exit] - exit game");
            Console.WriteLine("[save] - save the game");
            Console.WriteLine("[load file] - load saved game from given file");
            Console.WriteLine("[new game] - start a new game");
        }

        public ICommand GetCommand()
        {
            var command = Console.ReadLine();
            if (command == "load game")
            {
                return new SwitchStatetCommand(_manager, new LoadingState(this, _manager));
            }
            if (command == "help")
            {
                return new HelpCommand();
            }
            if (command == "exit")
            {
                return new ExitCommand(_manager);
            }
            if(command == "save")
            {
                return new SwitchStatetCommand(_manager, new LoadingState(new SaveFileState(this, _manager), _manager));
            }
            if(command == "load file")
            {
                return new SwitchStatetCommand(_manager, new LoadingState(new LoadFileState(_manager), _manager));
            }
            if (command == "new game")
            {
                return new NewGameCommand();
            }
            return new InvalidCommand();
        }   
    }
}
