using RaraChallenge.Scripts.Application.Core;
using UnityEngine;

namespace RaraChallenge.Scripts.Application.UnityDelivery
{
    public abstract class ApplicationUIBase : MonoBehaviour, IApplicationUI
    {
        public abstract void Init(IApplication application);

        public abstract void Show();

        public abstract void Hide();
    }
}