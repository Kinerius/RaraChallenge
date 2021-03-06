using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Entity.UnityDelivery;

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