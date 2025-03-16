using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PointsData", menuName = "Data/ItemData/PointsData")]
    public class PointsData : ItemData
    {
        [SerializeField] private SubType subType;

        public SubType PointsDataSubType => subType;
        
        public override Category ItemCategory => Category.Point;

        public enum SubType
        {
            None,
            ArmorPoints,
            ShotgunPoints,
            SubmachineGunPoints,
            SniperPoints,
            RiflePoints,
            PistolPoints,
            KnifePoints,
            VestPoints
        }
    }
}