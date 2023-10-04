namespace TextGameRPG
{
    class Enemy : IGameObject
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Guid Id { get; private set; }
        public Enemy(Guid id)
        {
            Id = id;
        }
        public GameObjectType ObjectType { get { return GameObjectType.Enemy; } }
        public void Load(IGame game, BinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            Health = binaryReader.ReadInt32();
        }
        public void Save(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(Name);
            binaryWriter.Write(Health);
        }
    }
}
