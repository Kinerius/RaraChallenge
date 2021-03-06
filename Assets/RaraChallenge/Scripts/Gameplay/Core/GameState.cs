using System;
using System.Collections.Generic;
using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Entity.Core;
using RaraChallenge.Scripts.Entity.UnityDelivery;
using UnityEngine;

namespace RaraChallenge.Scripts.Gameplay.Core
{
    public class GameState : IGameState
    {
        public event Action<int> OnScoreUpdated = _ => { };
        
        private readonly List<IEntity> _entities;
        private int _score;

        public GameState(List<IEntity> entities)
        {
            _entities = new List<IEntity>(entities);
            _score = 0;
        }

        public void Start(IApplication application)
        {
            foreach (var entity in _entities)
            {
                entity.StartPlayMode(this);
            }
        }

        public void AddScore(int score)
        {
            _score += score;
            Debug.Log($"Score is {_score}");
            
            OnScoreUpdated.Invoke(_score);
        }

        public void Stop()
        {
            foreach (IEntity entity in _entities)
            {
                entity.StopPlayMode();
            }
        }
    }
}