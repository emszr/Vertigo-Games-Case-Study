using System.Collections.Generic;
using Data;
using Global.Utilities;
using SpinGame.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace SpinGame.Gameplay.Object
{
    public class Wheel : MonoBehaviour, ISubscribable
    {
        [SerializeField] private List<Slot> slots;
        [SerializeField] private Image wheelImage;
        [SerializeField] private Image pinImage;
        [SerializeField] private SpinComponent spinComponent;
        
        private WheelData _wheelData;
        private int SlotCount => slots.Count;
        private bool IsDataCorrect => slots.Count == Constants.SlotCount && _wheelData.SlotCount == Constants.SlotCount;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void Initialize(WheelData wheelData)
        {
            gameObject.SetActive(true);
            SetData(wheelData);
            if (!IsDataCorrect)
            {
                Debug.LogError("Error occured at wheel data");
                return;
            }
            
            for (var i = 0; i < Constants.SlotCount; i++)
            {
                slots[i].Initialize();
            }
            
            SetContent();
        }

        public void Set(WheelData wheelData)
        {
            SetData(wheelData);
            if (!IsDataCorrect)
            {
                Debug.LogError("Error occured at wheel data");
                return;
            }
            
            SetContent();
        }

        private void SetData(WheelData wheelData) => _wheelData = wheelData;

        private void SetContent()
        {
            spinComponent.Reset();
            
            pinImage.sprite = _wheelData.PinSprite;
            wheelImage.sprite = _wheelData.WheelSprite;
            
            for (var i = 0; i < Constants.SlotCount; i++)
            {
                slots[i].Set(_wheelData.Slots[i]);
            }
        }

        private void StartSpin()
        {
            var index = Random.Range(0, SlotCount);
            spinComponent?.PlayTween(_wheelData.WheelSpinSettingsData, index, Constants.SlotCount,
                () => { Signals.GameStateChanged?.Invoke(GameState.Spinning); },
                () => { Signals.GameStateChanged?.Invoke(GameState.SpinEnded); });
        }

        private void OnGameStateChanged(GameState state)
        {
            if (state == GameState.SpinStarted)
            {
                StartSpin();
            }
        }

        public void Subscribe()
        {
            Signals.GameStateChanged += OnGameStateChanged;
        }

        public void Unsubscribe()
        {
            Signals.GameStateChanged -= OnGameStateChanged;
        }
    }
}