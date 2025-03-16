using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable, CreateAssetMenu(fileName = "WheelData", menuName = "Data/WheelData")]
    public class WheelData : ScriptableObject
    {
        [SerializeField] private List<SlotData> slots;
        [SerializeField] private WheelSpinSettingsData wheelSpinSettingsData;
        [SerializeField] private Type type;
        [SerializeField] private Sprite pinSprite;
        [SerializeField] private Sprite wheelSprite;
        
        public List<SlotData> Slots => slots;
        public int SlotCount => slots.Count;
        public Type WheelType => type;
        public Sprite PinSprite => pinSprite;
        public Sprite WheelSprite => wheelSprite;
        public WheelSpinSettingsData WheelSpinSettingsData => wheelSpinSettingsData;

        public enum Type
        {
            Bronze,
            Silver,
            Gold
        }
    }
}