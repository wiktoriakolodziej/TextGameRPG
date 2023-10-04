namespace TextGameRPG
{
    interface IGameObject
    {
        Guid Id { get; }
        GameObjectType ObjectType { get; }
        void Load(IGame game, BinaryReader binaryReader);
        void Save(BinaryWriter binaryWriter);
    }
}
