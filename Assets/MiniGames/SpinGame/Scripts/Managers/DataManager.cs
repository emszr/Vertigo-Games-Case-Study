using System.Collections.Generic;
using Global.Utilities;
using SpinGame.Data;
using SpinGame.Utilities;
using UnityEngine;

namespace SpinGame.Gameplay.Manager
{
    public class DataManager : Singleton<DataManager>, IManager, ISubscribable
    {
        [SerializeField] List<StageData> stageDataList;

        public static DataManager Instance => instance as DataManager;
        
        public int StageCount => stageDataList.Count;
        public StageData GetStageData(int index) => stageDataList[index];

        public bool IsInitialized { get; set; }

        public void Initialize()
        {
            Subscribe();
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
        }
        
        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}