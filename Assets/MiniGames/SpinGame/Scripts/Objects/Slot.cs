using System.Collections.Generic;
using SpinGame.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpinGame.Gameplay.Object
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private List<Image> images;
        [SerializeField] private TextMeshProUGUI amountText;

        private readonly Dictionary<ItemData.Category, Image> _categoryToImages = new();
        private SlotData _slotData;
        private ItemData ItemData => _slotData.ItemData;

        public void Initialize()
        {
            FillDictionary();
        }

        public void Set(SlotData slotData)
        {
            SetData(slotData);
            SetVisuals();
        }

        private void SetData(SlotData slotData) => _slotData = slotData;

        private void SetVisuals()
        {
            foreach (var image in images)
            {
                image.gameObject.SetActive(false);
            }

            var activeImage = _categoryToImages[ItemData.ItemCategory];
            activeImage.gameObject.SetActive(true);
            activeImage.sprite = ItemData.Sprite;
            amountText.text = "x" + _slotData.Amount;
            amountText.color = _slotData.TextColor;
        }

        private void FillDictionary()
        {
            _categoryToImages.Clear();
            _categoryToImages.Add(ItemData.Category.Clothe, images[0]);
            _categoryToImages.Add(ItemData.Category.SupportEquipment, images[1]);
            _categoryToImages.Add(ItemData.Category.Point, images[2]);
            _categoryToImages.Add(ItemData.Category.Weapon, images[3]);
            _categoryToImages.Add(ItemData.Category.Chest, images[4]);
            _categoryToImages.Add(ItemData.Category.Currency, images[5]);
        }
    }
}