using RaraChallenge.Scripts.Application.Core;

namespace RaraChallenge.Scripts.Entity.UnityDelivery
{
    public interface IEntity
    {
        void StartPlayMode(IGameState gameState);
        void StopPlayMode();
        void Explode();
    }
}