namespace Global.Utilities
{
    public interface IManager
    {
        public bool IsInitialized { get; }
        public void Initialize();
    }
}