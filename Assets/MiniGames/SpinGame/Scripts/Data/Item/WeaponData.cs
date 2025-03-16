using UnityEngine;

namespace SpinGame.Data
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Data/ItemData/WeaponData")]
    public class WeaponData : ItemData
    {
        [SerializeField] private WeaponData.SubType subType;
    
        public WeaponData.SubType WeaponDataSubType => subType;

        public override ItemData.Category ItemCategory => ItemData.Category.Weapon;
        
        public enum SubType
        {
            None,
            Knife,
            Pistol,
            SubmachineGun,
            Rifle,
            Shotgun,
            Sniper
        }
    }
}