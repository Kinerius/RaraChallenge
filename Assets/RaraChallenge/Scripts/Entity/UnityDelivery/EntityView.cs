using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Behaviours.Core;
using UnityEngine;

namespace RaraChallenge.Scripts.Entity.UnityDelivery
{
    public class EntityView : MonoBehaviour, IEntity
    {
        [SerializeField] private ClickListener _clickListener;
        private IEntityBehaviour[] _behaviours;
        private IGameState _gameState;

        public void AddBehaviours(IEntityBehaviour[] behaviours)
        {
            _behaviours = behaviours;
        }

        public void StartPlayMode(IGameState gameState)
        {
            _gameState = gameState;
            _clickListener.OnClick += OnClick;
        }

        public void StopPlayMode()
        {
            gameObject.SetActive(true);
            _clickListener.OnClick -= OnClick;
        }

        public void Explode()
        {
            gameObject.SetActive(false);
        }

        private void OnClick()
        {
            foreach (var behaviour in _behaviours)
            {
                behaviour.Trigger(_gameState, this);
            }
        }
    }
}