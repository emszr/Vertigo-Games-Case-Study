using Global.Utilities;
using SpinGame.Data;
using SpinGame.Gameplay.Object;
using SpinGame.Utilities;
using UnityEngine;

public class CardHandler : MonoBehaviour, ISubscribable
{
    [SerializeField] private Card card;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Subscribe();
    }

    
    
    public void Subscribe()
    {
        Signals.ItemAddedToInventory += OnItemAddedToInventory;
    }

    public void Unsubscribe()
    {
        Signals.ItemAddedToInventory += OnItemAddedToInventory;
    }
    
    private void OnItemAddedToInventory(SlotData slotData)
    {
        card?.Show(slotData, null, () =>
        {
            Signals.GameStateChanged?.Invoke(GameState.PostSpinActionEndStarted);
        },
        () =>
        {
            Signals.GameStateChanged?.Invoke(GameState.PostSpinActionEnded);
        });
    }
}