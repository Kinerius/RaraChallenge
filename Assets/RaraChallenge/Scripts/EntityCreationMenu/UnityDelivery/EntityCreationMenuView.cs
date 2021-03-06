using System;
using System.Collections.Generic;
using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Application.UnityDelivery;
using RaraChallenge.Scripts.Behaviours.Core;
using RaraChallenge.Scripts.EntityCreationMenu.Core;
using UnityEngine;
using UnityEngine.UI;
using Behaviour = RaraChallenge.Scripts.EntityCreationMenu.Core.Behaviour;

namespace RaraChallenge.Scripts.EntityCreationMenu.UnityDelivery
{
    public class EntityCreationMenuView : ApplicationUIBase
    {
        [SerializeField] private Core.Entity[] _entities;
        [SerializeField] private Behaviour[] _behaviours;

        [SerializeField] private GameObject entitiesContainer;
        [SerializeField] private GameObject behaviourContainer;

        [SerializeField] private Button cancelButton;
        [SerializeField] private Button saveButton;

        public event Action<EntityToCreate> OnEntitySaved = _ => { };
        public event Action OnCancel = () => { };
        
        private EntityToCreate _currentSelection;

        public override void Init(IApplication application)
        {
            SetupButtons();
        }

        private void OnBehaviourClicked(BehaviourType behaviourType)
        {
            if (behaviourType == BehaviourType.None)
            {
                _currentSelection.BehaviourTypes.Clear();
                return;
            }
            
            if (!_currentSelection.BehaviourTypes.Contains(behaviourType))
                _currentSelection.BehaviourTypes.Add(behaviourType);
        }

        private void OnEntityClicked(Core.Entity selectedEntity)
        {
            _currentSelection.Prefab = selectedEntity.prefab;
            _currentSelection.Icon = selectedEntity.icon;
            ShowBehaviourContainer();
        }

        public override void Show()
        {
            gameObject.SetActive(true);

            _currentSelection = new EntityToCreate {BehaviourTypes = new HashSet<BehaviourType>()};
            ShowEntitiesContainer();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        private void ShowEntitiesContainer()
        {
            entitiesContainer.gameObject.SetActive(true);
            behaviourContainer.gameObject.SetActive(false);
        }

        private void ShowBehaviourContainer()
        {
            entitiesContainer.gameObject.SetActive(false);
            behaviourContainer.gameObject.SetActive(true);
        }

        private void SetupButtons()
        {
            foreach (var entity in _entities)
            {
                entity.button.onClick.AddListener(() => OnEntityClicked(entity));
            }

            foreach (var behaviour in _behaviours)
            {
                behaviour.button.onClick.AddListener(() => OnBehaviourClicked(behaviour.type));
            }
            
            cancelButton.onClick.AddListener(OnCancelButtonPressed);
            saveButton.onClick.AddListener(OnSave);
        }

        private void OnCancelButtonPressed()
        {
            OnCancel();
        }

        private void OnSave()
        {
            OnEntitySaved(_currentSelection);
        }
    }
}
