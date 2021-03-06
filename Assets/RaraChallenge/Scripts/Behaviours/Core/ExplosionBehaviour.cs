using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Entity.UnityDelivery;

namespace RaraChallenge.Scripts.Behaviours.Core
{
    public class ExplosionBehaviour : IEntityBehaviour
    {
        public void Trigger(IGameState gameState, IEntity entity)
        {
            entity.Explode();
        }
    }
}