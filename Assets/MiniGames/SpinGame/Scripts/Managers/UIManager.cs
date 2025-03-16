using Global.Utilities;
using SpinGame.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace SpinGame.Gameplay.Manager
{
    public class UIManager : Singleton<UIManager>, IManager, ISubscribable
    {
        [SerializeField] Button spinButton;
        
        public void Initialize()
        {
            Subscribe();
            HandleButtons();
            IsInitialized = true;
        }
        
        private void HandleButtons()
        {
            spinButton.onClick.RemoveAllListeners();
            spinButton.onClick.AddListener(OnSpinButtonClick);
        }

        private void SetButtonsInteractable(bool isInteractable)
        {
            spinButton.interactable = isInteractable;
        }
        
        private void OnSpinButtonClick()
        {
            Signals.GameStateChanged?.Invoke(GameState.SpinStarted);
        }

        public bool IsInitialized { get; set; }

        public void Subscribe()
        {
            Signals.GameStateChanged += OnGameStateChanged;
        }

        public void Unsubscribe()
        {
            Signals.GameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            if (state == GameState.SpinStarted)
            {
                SetButtonsInteractable(false);
            }
            else
            {
                SetButtonsInteractable(true);
            }
        }
        
        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}