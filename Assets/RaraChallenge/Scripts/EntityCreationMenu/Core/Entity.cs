using System;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EntityCreationMenu.Core
{
    [Serializable]
    public struct Entity
    {
        public Button button;
        public Image icon;
        public GameObject prefab;
    }
}