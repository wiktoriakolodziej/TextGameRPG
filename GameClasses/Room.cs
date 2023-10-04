using System;
using System.Collections.Generic;
using System.IO;

namespace TextGameRPG
{
    class Room : IGameObject
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public GameObjectType ObjectType { get { return GameObjectType.Room; } }

        public Guid Id { get; private set; }

        public Room(Guid id)
        {
            Id = id;
        }
        public Room(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public void Load(IGame game, BinaryReader binaryReader)
        {
            Name = binaryReader.ReadString();
            Description = binaryReader.ReadString();
        }
        public void Save(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(Name);
            binaryWriter.Write(Description);
        }

    }
}
