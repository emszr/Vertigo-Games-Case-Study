using Data;
using Global.Utilities;
using SpinGame.Gameplay.Object;
using SpinGame.Utilities;
using UnityEngine;

namespace SpinGame.Gameplay.Manager
{
    public class GameManager : Singleton<GameManager>, IManager, ISubscribable
    {
        [SerializeField] private Wheel wheel;

        public bool IsInitialized { get; set; }

        private WheelData CurrentWheelData => DataManager.Instance.GetStageData(CurrentStageIndex).Wheels[CurrentWheelIndex];
        
        public GameState GameState { get; private set; }
        public int CurrentStageIndex { get; private set; }
        public int CurrentWheelIndex { get; private set; }
        
        public void Initialize()
        {
            Subscribe();
            wheel.gameObject.SetActive(false);
            CurrentStageIndex = 0;
            CurrentWheelIndex = 0;
            IsInitialized = true;
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
            switch (state)
            {
                case GameState.Initialized:
                    wheel.Initialize(CurrentWheelData);
                    break;
                case GameState.PostSpinActionEnded:
                    CurrentWheelIndex++;
                    wheel.Set(CurrentWheelData);
                    break;
            }

            GameState = state;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}