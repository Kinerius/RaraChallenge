using RaraChallenge.Scripts.Entity.Core;
using RaraChallenge.Scripts.Gameplay.Core;

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