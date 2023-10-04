namespace TextGameRPG
{
    class Player : IGameObject
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Room CurrentRoom { get; set; }

        public Guid Id { get; private set; }
        public Player(Guid id)
        {
            Id = id;
        }
        public GameObjectType ObjectType { get { return GameObjectType.Player; } }
        public void Load(IGame game, BinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            Health = binaryReader.ReadInt32();
            var currentRoomId = new Guid(binaryReader.ReadBytes(16));
            CurrentRoom = (Room)game.GetGameObject(currentRoomId);
        }
        public void Save(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(Name);
            binaryWriter.Write(Health);
            binaryWriter.Write(CurrentRoom.Id.ToByteArray());
        }
    }
}
