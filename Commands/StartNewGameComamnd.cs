using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGameRPG
{
    internal class StartNewGameComamnd : ICommand
    {
        private string _name;
        private StateManager _manager;
        private Engine _engine;

        public StartNewGameComamnd(string name, StateManager manager, Engine engine)
        {
            _name = name;
            _manager = manager;
            _engine = engine;
        }

        public void Execute()
        {
            var game = new Game();
            var room1 = new Room(Guid.NewGuid(), "main room", "room where you start the game");
            game.AddGameObject(room1);
            var room2 = new Room(Guid.NewGuid(), "combat room", "room with enemies to encounter");
            game.AddGameObject(room2);
            var player = new Player(Guid.NewGuid());
            player.Name = "Dawid";
            player.Health = 100;
            game.Player = player;
            game.AddGameObject(player);
            var enemy1 = new Enemy(Guid.NewGuid());
            enemy1.Name = "wikaSika";
            enemy1.Health = 100;
            game.AddGameObject(enemy1);
            game.Player.CurrentRoom = room1;

            _engine.CurrentGame = game;          
            var switchState = new SwitchStatetCommand(_manager, new RoomState(_engine.CurrentGame.Player.CurrentRoom, _manager, _engine));
            switchState.Execute();

        }
    }
}
