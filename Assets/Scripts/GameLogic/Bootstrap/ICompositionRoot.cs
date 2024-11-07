namespace GameLogic.Bootstrap
{
    public interface ICompositionRoot
    {
        void OnContextInitialized();

        void OnContextDestroyed();

        void OnContextUpdate(float elapseSeconds, float realElapseSeconds);

        void OnContextCreated<T>(T contextHolder);
    }
}