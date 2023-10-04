namespace TextGameRPG
{
    class Game : IGame
    {
        public Dictionary<Guid, IGameObject> Objects { get; private set; }
        public Player Player { get; set; }


        public Game()
        {
            Objects = new Dictionary<Guid, IGameObject>();
        }
        public void AddGameObject(IGameObject gameObject)
        {
            Objects.Add(gameObject.Id, gameObject);
        }

        public IGameObject GetGameObject(Guid id)
        {
            return Objects[id];
        }
    }
}
