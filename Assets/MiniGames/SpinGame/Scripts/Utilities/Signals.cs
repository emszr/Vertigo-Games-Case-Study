using System;
using SpinGame.Data;

namespace SpinGame.Utilities
{
    public class Signals
    {
        public static Action<GameState> GameStateChanged;
        public static Action<SlotData> ItemAddedToInventory;
    }
}