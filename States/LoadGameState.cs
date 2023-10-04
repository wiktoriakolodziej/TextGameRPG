using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGameRPG.Commands;

namespace TextGameRPG.States
{
    internal class LoadGameState : IState
    {
        private StateManager _manager;
        private Engine _engine;
        public LoadGameState(StateManager manager, Engine engine)
        {
            _manager = manager;
            _engine = engine;

        }

        public ICommand GetCommand()
        {
            var file = Console.ReadLine();
            if(file == "back")
            {
                return new SwitchStatetCommand(_manager, new LoadingState(new MainMenuState(_manager), _manager));
            }
            if(file != null && File.Exists(file))
            {
                return new LoadGameCommand(file, _manager, _engine);
            }
            return new InvalidCommand();

        }

        public void Render()
        {
            var directoryInfo = new DirectoryInfo("C:\\Users\\dgdaw\\source\\repos\\TextGameRPG");
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.ToString().Contains(".txt"))
                    Console.WriteLine(file.Name);
            }
            Console.WriteLine("choose from witch file you want to load your game");
            Console.WriteLine("[back] - return to menu");

        }
    }
}

