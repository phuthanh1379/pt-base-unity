using System.ComponentModel;
using Core.Factory.GameObject;
using Core.Task;
using IContainer = Base.IoC.DI.Container.IContainer;

namespace GameLogic.Bootstrap
{
    public abstract class GameRoot : ICompositionRoot
    {
        private static IContainer _gameRootContainer;
        private static IContainer _coreContainer;
        private static IContainer _runtimeContainer;

        private IStaticGameObjectFactory _staticGameObjectFactory;
        private TaskExecutor _taskExecutor;
        // private SmartfoxManager _sfManager;
        // private WSManager _wsManager;
        // private LanguageManager _lgManager;

        // protected abstract IGeneralConfig GeneralConfig { get; }
        // protected abstract IWSModuleConfig WsConfig { get; }
        // protected abstract ISfsModuleConfig SfsModuleConfig { get; }

        public void OnContextInitialized()
        {
            _coreContainer = new Container("Core Container");

        }

        public void OnContextDestroyed()
        {
            throw new System.NotImplementedException();
        }

        public void OnContextUpdate(float elapseSeconds, float realElapseSeconds)
        {
            throw new System.NotImplementedException();
        }

        public void OnContextCreated<T>(T contextHolder)
        {
            throw new System.NotImplementedException();
        }
    }
}