using System;
using UnityEngine;

namespace SpinGame.Data
{
    [Serializable, CreateAssetMenu(fileName = "SupportEquipmentData", menuName = "Data/ItemData/SupportEquipmentData")]
    public class SupportEquipment : ItemData
    {
        [SerializeField] private SupportEquipment.SubType subType;
    
        public SupportEquipment.SubType SupportEquipmentDataSubType => subType;

        public override ItemData.Category ItemCategory => ItemData.Category.SupportEquipment;
        
        public enum SubType
        {
            None,
            Throwable,
            Healthshot
        }
    }
}