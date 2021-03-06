using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.EditorUI.UnityDelivery;
using UnityEngine;

namespace RaraChallenge.Scripts.Application.UnityDelivery
{
    public class Application : MonoBehaviour, IApplication
    {
        [SerializeField] private UIController uiController;
        public void Start()
        {
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            uiController.Init(this);
            uiController.Show<EditorUIView>();
        }

        public IUIController UIController() => uiController;
    }
}
