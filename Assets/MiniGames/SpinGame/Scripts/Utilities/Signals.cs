using System;
using Data;

namespace SpinGame.Utilities
{
    public class Signals
    {
        public static Action<GameState> GameStateChanged;
        public static Action<SlotData> ItemAddedToInventory;
    }
}