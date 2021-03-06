using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Application.UnityDelivery;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EditorUI.UnityDelivery
{
    public class EditorUIView : ApplicationUIBase
    {
        [SerializeField] private Button createButton;
        private IApplication _application;

        public override void Init(IApplication application)
        {
            _application = application;
            
            createButton.onClick.AddListener(ShowEntityCreationView);
            
            var creationMenu = _application.UIController().Get<EntityCreationMenuView>();
            creationMenu.OnEntitySaved += OnEntitySaved;
            creationMenu.OnCancel += HideEntityCreationView;
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
            Debug.Log($"Creating entity {entityToCreate.Prefab} with behaviour {entityToCreate.BehaviourType}");
            HideEntityCreationView();
        }
    }
}
