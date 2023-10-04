using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextGameRPG.Commands;

namespace TextGameRPG
{
    internal class RoomState : IState
    {
        public Room CurrentRoom { get; set; }
        private StateManager _manager;
        private Engine _engine;
        public RoomState(Room room, StateManager stateManager, Engine engine) 
        { 
            CurrentRoom = room;
            _manager = stateManager;
            _engine = engine;
        }

        public void Render()
        {
            Console.WriteLine(CurrentRoom.Description);
            Console.WriteLine("what do you want to do: ");
            Console.WriteLine("[save] - save game");
            Console.WriteLine("[back] - go back to the main menu");
        }

        public ICommand GetCommand()
        {
            var input = Console.ReadLine();
           if(input == "save")
           {
                Console.WriteLine("a file you want your game to be saved in: ");
                var file = Console.ReadLine();
                if(file != null)
                    return new SaveGameCommand(file, _manager, _engine);
                return new InvalidCommand();
           }
           if(input == "back")
           {
                return new SwitchStatetCommand(_manager, new MainMenuState(_manager));
           }
            return new InvalidCommand();

        }
    }
}
