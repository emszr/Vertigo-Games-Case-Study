using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpinGame.Gameplay.Object
{
    public class DisplayItem : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI amountText;

        private ItemData _itemData;
        private int _amount;
        
        public void Set(SlotData slotData)
        {
            if (slotData == null || slotData.ItemData == null)
            {
                Debug.LogError("Slot data is null");
                return;
            }

            var setSprite = false;
            if (_itemData == null)
            {
                _itemData = slotData.ItemData;
                setSprite = true;
            }
   
            _amount += slotData.Amount;
            SetVisuals(setSprite);
        }

        private void SetVisuals(bool setSprite)
        {
            if (setSprite)
            {
                itemImage.sprite = _itemData.Sprite;
            }
            
            amountText.text= _amount.ToString();
        }
    }
}