using System;
using UnityEngine;

namespace Data
{
    [Serializable, CreateAssetMenu(fileName = "SlotData", menuName = "Data/SlotData")]
    public class SlotData : ScriptableObject
    {
        [SerializeField] private int amount;
        [SerializeField] private ItemData itemData;
        [SerializeField] private Color textColor = Color.white;
        
        public int Amount => amount;
        public ItemData ItemData => itemData;
        public Color TextColor => textColor;
    }
}