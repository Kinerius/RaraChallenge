using System;
using System.Linq;
using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Application.UnityDelivery;
using RaraChallenge.Scripts.Behaviours.Core;
using RaraChallenge.Scripts.EditorUI.Core;
using RaraChallenge.Scripts.Entity.UnityDelivery;
using RaraChallenge.Scripts.EntityCreationMenu.Core;
using RaraChallenge.Scripts.EntityCreationMenu.UnityDelivery;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EditorUI.UnityDelivery
{
    public class EditorUIView : ApplicationUIBase
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button createButton;
        [SerializeField] private Button screen;
        [SerializeField] private EntityCreationSelector entityCreationSelector;

        private IApplication _application;
        private EntityPack? _selectedEntity;

        public override void Init(IApplication application)
        {
            _application = application;

            createButton.onClick.AddListener(ShowEntityCreationView);

            var creationMenu = _application.UIController().Get<EntityCreationMenuView>();
            creationMenu.OnEntitySaved += OnEntitySaved;
            creationMenu.OnCancel += HideEntityCreationView;

            entityCreationSelector.OnStateChanged += OnEntitySelectionChanged;

            playButton.onClick.AddListener(EnterPlayMode);
            // we avoid Update method with this
            screen.onClick.AddListener(CheckAndCreateEntity);
        }

        private void EnterPlayMode()
        {
            _application.PlayMode();
        }

        private void CheckAndCreateEntity()
        {
            if (_selectedEntity == null) return;
            var selectedEntity = _selectedEntity.Value;

            var cameraRay = _application.GetCamera().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out var hit))
            {
                CreateEntity(selectedEntity, hit.point);
            }
        }

        private void CreateEntity(EntityPack selectedEntity, Vector3 position)
        {
            var levelRoot = _application.GetLevelRoot();
            var instance = Instantiate(selectedEntity.Prefab, levelRoot.transform);
            instance.transform.position = position;
            var entityView = instance.GetComponent<EntityView>();
            entityView.AddBehaviours(selectedEntity.Behaviours);
            _application.RegisterEntity(entityView);
        }

        private void OnEntitySelectionChanged(EntityPack? pack)
        {
            _selectedEntity = pack;
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        private void ShowEntityCreationView()
        {
            _application.UIController().Show<EntityCreationMenuView>();
        }

        private void HideEntityCreationView()
        {
            _application.UIController().Hide<EntityCreationMenuView>();
        }

        private void OnEntitySaved(EntityToCreate entityToCreate)
        {
            Debug.Log($"Creating entity {entityToCreate.Prefab} with {entityToCreate.BehaviourTypes.Count} behaviours");
            entityCreationSelector.AddButton(CreateEntityPack(entityToCreate));
            HideEntityCreationView();
        }

        private EntityPack CreateEntityPack(EntityToCreate entityToCreate)
        {
            return new EntityPack
            {
                Prefab = entityToCreate.Prefab,
                Icon = entityToCreate.Icon,
                Behaviours = entityToCreate.BehaviourTypes.Select(GetBehaviour).ToArray()
            }; 
        }

        private IEntityBehaviour GetBehaviour(BehaviourType behaviour)
        {
            switch (behaviour)
            {
                case BehaviourType.Score: return new ScoreBehaviour();
                case BehaviourType.Explosion: return new ExplosionBehaviour();
                default:
                    throw new ArgumentOutOfRangeException(nameof(behaviour), behaviour, null);
            }
        }
    }
}