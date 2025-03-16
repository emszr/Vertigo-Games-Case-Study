using UnityEngine;

namespace SpinGame.Data
{
    [CreateAssetMenu(fileName = "ClotheData", menuName = "Data/ItemData/ClotheData")]
    public class ClotheData : ItemData
    {
        [SerializeField] private ClotheData.SubType subType;
    
        public ClotheData.SubType ClotheDataSubType => subType;

        public override ItemData.Category ItemCategory => ItemData.Category.Clothe;
        
        public enum SubType
        {
            None,
            Head
        }
    }
}