namespace TextGameRPG
{
    class GameFilePersistence
    {
        public void SaveGame(string filename, IGame game)
        {
            using (var bw = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate)))
            {
                bw.Write(game.Objects.Count);
                foreach (var gameObject in game.Objects)
                {
                    bw.Write(gameObject.Key.ToByteArray());
                    bw.Write((int)gameObject.Value.ObjectType);

                }
                foreach (var gameObject in game.Objects.Values)
                {
                    gameObject.Save(bw);
                }
            }

        }
        public IGame LoadGame(string filename)
        {
            var game = new Game();
            using (var br = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                var gameObjects = new List<IGameObject>();
                var gameObjectCount = br.ReadInt32();
                for (var i = 0; i < gameObjectCount; i++)
                {
                    var id = new Guid(br.ReadBytes(16));
                    var type = (GameObjectType)br.ReadInt32();

                    IGameObject gameObject = null;
                    switch (type)
                    {
                        case GameObjectType.Player:
                            game.Player = new Player(id);
                            gameObject = game.Player;
                            break;
                        case GameObjectType.Room:
                            gameObject = new Room(id);
                            break;
                        case GameObjectType.Enemy:
                            gameObject = new Enemy(id);
                            break;
                    }
                    gameObjects.Add(gameObject);
                    game.AddGameObject(gameObject);
                }
                foreach (var gameObject in gameObjects)
                {
                    gameObject.Load(game, br);
                }
            }
            return game;
        }
    }
}
