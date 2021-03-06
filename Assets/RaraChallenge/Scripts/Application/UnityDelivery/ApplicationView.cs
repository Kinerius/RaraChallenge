using System.Collections.Generic;
using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.EditorUI.UnityDelivery;
using RaraChallenge.Scripts.Entity.Core;
using RaraChallenge.Scripts.Gameplay.Core;
using RaraChallenge.Scripts.GameplayUI.UnityDelivery;
using UnityEngine;

namespace RaraChallenge.Scripts.Application.UnityDelivery
{
    public class ApplicationView : MonoBehaviour, IApplication
    {
        [SerializeField] private UIController uiController;
        [SerializeField] private GameObject levelRoot;
        [SerializeField] private Camera mainCamera;

        private readonly List<IEntity> _entities = new List<IEntity>();
        private GameState _gameState;

        public void Start()
        {
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            InitializeUI();
            EditMode();
        }

        private void InitializeUI()
        {
            uiController.Init(this);
        }

        public void RegisterEntity(IEntity instance)
        {
            _entities.Add(instance);
        }

        public void EditMode()
        {
            _gameState?.Stop();

            uiController.Hide<GameplayUIView>();
            uiController.Show<EditorUIView>();
        }

        public void PlayMode()
        {
            uiController.Hide<EditorUIView>();
            var gameplayUIView = uiController.Show<GameplayUIView>();
            gameplayUIView.ResetState();
            
            _gameState = new GameState(_entities);
            _gameState.Start(this);
            _gameState.OnScoreUpdated += gameplayUIView.OnScoreUpdated;
        }

        public IUIController UIController() => uiController;

        public GameObject GetLevelRoot() => levelRoot;

        public Camera GetCamera() => mainCamera;
    }
}
