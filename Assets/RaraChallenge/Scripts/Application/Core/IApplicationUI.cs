namespace RaraChallenge.Scripts.Application.Core
{
    public interface IApplicationUI
    {
        void Init(IApplication application);
        void Show();
        void Hide();
    }
}