using RaraChallenge.Scripts.Entity.Core;
using RaraChallenge.Scripts.Gameplay.Core;

namespace RaraChallenge.Scripts.Behaviours.Core
{
    public class ScoreBehaviour : IEntityBehaviour
    {
        public void Trigger(IGameState gameState, IEntity entity)
        {
            gameState.AddScore(10);
        }
    }
}