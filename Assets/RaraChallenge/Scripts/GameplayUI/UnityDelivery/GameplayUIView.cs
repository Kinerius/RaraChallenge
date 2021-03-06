using RaraChallenge.Scripts.Application.Core;
using RaraChallenge.Scripts.Application.UnityDelivery;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RaraChallenge.Scripts.GameplayUI.UnityDelivery
{
    public class GameplayUIView : ApplicationUIBase
    {
        [SerializeField] private Button stopButton;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private IApplication _application;

        public override void Init(IApplication application)
        {
            _application = application;
            stopButton.onClick.AddListener(EnterEditMode);
        }

        private void EnterEditMode()
        {
            _application.EditMode();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ResetState()
        {
            scoreText.text = "0";
        }

        public void OnScoreUpdated(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}
