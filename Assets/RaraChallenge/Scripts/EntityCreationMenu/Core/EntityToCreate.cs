using System.Collections.Generic;
using RaraChallenge.Scripts.Behaviours.Core;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EntityCreationMenu.Core
{
    public struct EntityToCreate
    {
        public GameObject Prefab;
        public Image Icon;
        public HashSet<BehaviourType> BehaviourTypes;
    }
}