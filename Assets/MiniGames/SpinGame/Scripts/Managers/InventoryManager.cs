using Global.Utilities;

namespace SpinGame.Gameplay.Manager
{
    public class InventoryManager : Singleton<InventoryManager>, IManager, ISubscribable
    {
        public bool IsInitialized { get; }

        public void Subscribe()
        {
        }

        public void Unsubscribe()
        {
        }

        public void Initialize()
        {

        }
    }
}