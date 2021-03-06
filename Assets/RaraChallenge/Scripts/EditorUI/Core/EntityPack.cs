using RaraChallenge.Scripts.Behaviours.Core;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.EditorUI.Core
{
    public struct EntityPack
    {
        public GameObject Prefab;
        public Image Icon;
        public IEntityBehaviour[] Behaviours;
    }
}