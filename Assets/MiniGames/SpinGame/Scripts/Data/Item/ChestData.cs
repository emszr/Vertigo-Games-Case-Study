using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ChestData", menuName = "Data/ItemData/ChestData")]
    public class ChestData : ItemData
    {
        [SerializeField] private SubType subType;
    
        public SubType ChestDataSubType => subType;

        public override Category ItemCategory => Category.Chest;

        public enum SubType
        {
            None,
            Big,
            Small,
            Bronze,
            Silver,
            Gold,
            Standard,
            Super
        }
    }
}