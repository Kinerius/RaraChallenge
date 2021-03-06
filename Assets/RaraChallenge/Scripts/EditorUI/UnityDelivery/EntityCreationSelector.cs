using System;
using System.Collections.Generic;
using RaraChallenge.Scripts.EditorUI.Core;
using UnityEngine;

namespace RaraChallenge.Scripts.EditorUI.UnityDelivery
{
    public class EntityCreationSelector : MonoBehaviour
    {
        [SerializeField] private EntityButton buttonPrefab;
        [SerializeField] private RectTransform buttonsContainer;

        private List<EntityButton> _buttons = new List<EntityButton>();
        public event Action<EntityPack?> OnStateChanged = _ => {};
        
        public void AddButton(EntityPack pack)
        {
            var instance = Instantiate(buttonPrefab, buttonsContainer);
            instance.Setup(pack);
            instance.OnSelected += OnEntitySelected;
            instance.OnDeselected += OnEntityDeselected;
            _buttons.Add(instance);
        }

        private void OnEntitySelected(EntityButton activeButton, EntityPack pack)
        {
            foreach (var button in _buttons)
            {
                if (button != activeButton) button.SetInactive();
            }
            
            OnStateChanged(pack);
        }

        private void OnEntityDeselected()
        {
            OnStateChanged(null);
        }
    }
}