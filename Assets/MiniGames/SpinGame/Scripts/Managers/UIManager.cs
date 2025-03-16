using Global.Utilities;
using SpinGame.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace SpinGame.Gameplay.Manager
{
    public class UIManager : Singleton<UIManager>, IManager, ISubscribable
    {
        [SerializeField] Button spinButton;
        [SerializeField] Button exitButton;
        
        public bool IsInitialized { get; private set; }
        
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
            
            exitButton.onClick.RemoveAllListeners();
            exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void SetButtonsInteractable(bool isInteractable)
        {
            spinButton.interactable = isInteractable;
            exitButton.interactable = isInteractable;
        }
        
        private void OnSpinButtonClick()
        {
            Signals.GameStateChanged?.Invoke(GameState.SpinStarted);
        }
        
        private void OnExitButtonClick()
        {
        }
        
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
            else if(state == GameState.PostSpinActionEnded)
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