using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Application.UnityDelivery;

namespace RaraChallenge.Scripts.GameplayUI.UnityDelivery
{
    public class GameplayUIView : ApplicationUIBase
    {
        public override void Init(IApplication application)
        {
            
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
