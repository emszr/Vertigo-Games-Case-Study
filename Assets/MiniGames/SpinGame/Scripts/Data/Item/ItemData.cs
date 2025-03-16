using System;
using UnityEngine;

namespace SpinGame.Data
{
    [Serializable]
    public abstract class ItemData : ScriptableObject
    {
        [SerializeField] protected Sprite sprite;
        [SerializeField] protected int id;
        [SerializeField] protected string displayName;
     
        public virtual Category ItemCategory => Category.None;
        
        public Sprite Sprite => sprite;
        public string DisplayName => displayName;
        
        public enum Category
        {
            None,
            Currency,
            Chest,
            SupportEquipment,
            Weapon,
            Clothe,
            Point,
            Death
        }
    }
}