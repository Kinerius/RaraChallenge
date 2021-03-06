using System;
using System.Collections.Generic;
using System.Linq;
using RaraChallenge.Scripts.Application.Core;
using UnityEngine;

namespace RaraChallenge.Scripts.Application.UnityDelivery
{
    public class UIController : MonoBehaviour, IUIController
    {
        [SerializeField] private ApplicationUIBase[] views;

        public void Init(Application application)
        {
            foreach (var view in views)
            {
                view.Init(application);
                view.Hide();
            }
        }
        
        public T Show<T>() where T : ApplicationUIBase
        {
            var ui = Get<T>();
            ui.Show();
            return ui;
        }
        
        public T Hide<T>() where T : ApplicationUIBase
        {
            var ui = Get<T>();
            ui.Hide();
            return ui;
        }
        public T Get<T>() where T : ApplicationUIBase
        {
            var selectedView = views.FirstOrDefault(v => v is T);
            if (selectedView == null) throw new Exception($"View of type {typeof(T).Name} not implemented");
            return selectedView as T;
        }
    }
}