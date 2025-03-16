using SpinGame.Gameplay.Manager;
using SpinGame.Utilities;
using UnityEngine;

namespace SpinGame.Gameplay.Loader
{
    public class SpinGameLoader : SceneLoader
    {
        protected override async void Initialize()
        {/*
            try
            {
                Debug.Log("SpinGame Loader Initializing");
                Signals.GameStateChanged?.Invoke(GameState.Initializing);
                await InitializeManagers();
                Signals.GameStateChanged?.Invoke(GameState.Idle);
                Debug.Log("SpinGame Loader Initialized");
            }
            catch (Exception)
            {
                Debug.LogError("Spin Game managers couldn't be initialized");
            }*/
            
            Debug.Log("SpinGame Loader Initializing");
            Signals.GameStateChanged?.Invoke(GameState.Initializing);
            await InitializeManagers();
            Signals.GameStateChanged?.Invoke(GameState.Initialized);
            Debug.Log("SpinGame Loader Initialized");
        }

        protected override void AddManagers()
        {
            Managers.Add(UIManager.instance);
            Managers.Add(DataManager.instance);
            Managers.Add(GameManager.instance);
            
        }
    }
}