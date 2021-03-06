using RaraChallenge.Scripts.Gameplay.Core;

namespace RaraChallenge.Scripts.Entity.Core
{
    public interface IEntity
    {
        void StartPlayMode(IGameState gameState);
        void StopPlayMode();
        void Explode();
    }
}