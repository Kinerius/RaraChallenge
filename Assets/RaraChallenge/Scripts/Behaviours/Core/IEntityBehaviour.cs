using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Entity.UnityDelivery;

namespace RaraChallenge.Scripts.Behaviours.Core
{
    public interface IEntityBehaviour
    {
        void Trigger(IGameState gameState, IEntity entity);
    }
}