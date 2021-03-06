using RaraChallenge.Scripts.Entity.Core;
using UnityEngine;

namespace RaraChallenge.Scripts.Application.Core
{
    public interface IApplication
    {
        IUIController UIController();
        GameObject GetLevelRoot();
        Camera GetCamera();
        void RegisterEntity(IEntity entity);
        void EditMode();
        void PlayMode();
    }
}