using System;
using RaraChallenge.Scripts.Behaviours.Core;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EntityCreationMenu.Core
{
    [Serializable]
    public struct Behaviour
    {
        public Button button;
        public BehaviourType type;
    }
}