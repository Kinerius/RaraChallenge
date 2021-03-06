using System;
using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Application.UnityDelivery;
using RaraChallenge.Scripts.Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EditorUI.UnityDelivery
{
    public class EntityCreationMenuView : ApplicationUIBase
    {
        [SerializeField] private Entity[] _entities;
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
            _currentSelection.BehaviourType = behaviourType;
        }

        private void OnEntityClicked(GameObject selectedPrefab)
        {
            _currentSelection.Prefab = selectedPrefab;
            ShowBehaviourContainer();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            
            _currentSelection = new EntityToCreate();
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
                entity.button.onClick.AddListener(() => OnEntityClicked(entity.prefab));
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

    [Serializable]
    public struct Entity
    {
        public Button button;
        public GameObject prefab;
    }

    [Serializable]
    public struct Behaviour
    {
        public Button button;
        public BehaviourType type;
    }

    public struct EntityToCreate
    {
        public GameObject Prefab;
        public BehaviourType BehaviourType;
    }
}
