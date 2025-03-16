using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CurrencyData", menuName = "Data/ItemData/CurrencyData")]
    public class CurrencyData : ItemData
    {
        [SerializeField] private SubType subType;
    
        public SubType CurrencyDataSubType => subType;
        
        public override Category ItemCategory => Category.Currency;

    
        public enum SubType
        {
            None,
            Cash,
            Gold
        }
    }
}