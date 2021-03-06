using System;
using UnityEngine;

namespace RaraChallenge.Scripts.Entity.UnityDelivery
{
    public class ClickListener : MonoBehaviour
    {
        public event Action OnClick = () => { };

        public void OnMouseDown()
        {
            OnClick();
        }
    }
}