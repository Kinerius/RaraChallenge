using RaraChallenge.Scripts.Entity.Core;
using RaraChallenge.Scripts.Gameplay.Core;

namespace RaraChallenge.Scripts.Behaviours.Core
{
    public interface IEntityBehaviour
    {
        void Trigger(IGameState gameState, IEntity entity);
    }
}