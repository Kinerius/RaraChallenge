using System;
using RaraChallenge.Scripts.EditorUI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EditorUI.UnityDelivery
{
    public class EntityButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private RectTransform activeContainer;

        public event Action<EntityButton, EntityPack> OnSelected = (_, __) => { };
        public event Action OnDeselected = () => { };
        
        private bool _isActive;
        private EntityPack _entityPack;

        public void Setup(EntityPack entityPack)
        {
            _entityPack = entityPack;
            image.sprite = entityPack.Icon.sprite;
            button.onClick.AddListener(OnClick);
            SetInactive();
        }

        private void OnClick()
        {
            if (_isActive)
            {
                OnDeselected();
                SetInactive();
            }
            else
            {
                OnSelected(this, _entityPack);
                SetActive();
            }
        }

        public void SetActive()
        {
            if (_isActive) return;
            _isActive = true;
            activeContainer.gameObject.SetActive(true);
        }

        public void SetInactive()
        {
            if (!_isActive) return;
            _isActive = false;
            activeContainer.gameObject.SetActive(false);
        }
    }
}