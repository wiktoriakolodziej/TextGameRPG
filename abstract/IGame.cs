using TextGameRPG.GameClasses;

namespace TextGameRPG
{
    interface IGame
    {
        Dictionary<Guid, IGameObject> Objects { get; }
        Player Player { get; }
        IGameObject GetGameObject(Guid id);
    }
}
