using System.Collections.Generic;
using Global.Utilities;
using SpinGame.Data;
using SpinGame.Gameplay.Object;
using SpinGame.Utilities;
using UnityEngine;

public class DisplayZoneHandler : MonoBehaviour, ISubscribable
{
    [SerializeField] private DisplayItem displayItemPrefab;
    [SerializeField] private Transform layoutParent;
    
    private Dictionary<ItemData, DisplayItem> _itemDataToDisplayItems = new();
    
    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Subscribe();
    }

    public void Initialize()
    {
        
    }

    private void OnItemAddedToInventory(SlotData slotData)
    {
        if (slotData == null || slotData.ItemData.ItemCategory == ItemData.Category.Death)
        {
            return;
        }

        if (_itemDataToDisplayItems.ContainsKey(slotData.ItemData))
        {
            _itemDataToDisplayItems[slotData.ItemData].Set(slotData);
        }
        else
        {
            var displayItem = Instantiate(displayItemPrefab, layoutParent);
            _itemDataToDisplayItems.Add(slotData.ItemData, displayItem);
            displayItem.Set(slotData);
        }
        
        Signals.GameStateChanged?.Invoke(GameState.PostSpinActionEnded);
    }

    public void Subscribe()
    {
        Signals.ItemAddedToInventory += OnItemAddedToInventory;
    }

    public void Unsubscribe()
    {
        Signals.ItemAddedToInventory -= OnItemAddedToInventory;
    }
}