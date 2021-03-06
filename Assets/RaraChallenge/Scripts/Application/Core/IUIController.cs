using RaraChallenge.Scripts.Application.UnityDelivery;

namespace RaraChallenge.Scripts.Application.Core
{
    public interface IUIController
    {
        T Show<T>() where T : ApplicationUIBase;
        T Hide<T>() where T : ApplicationUIBase;
        T Get<T>() where T : ApplicationUIBase;
    }
}