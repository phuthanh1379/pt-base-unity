using System.Collections;
using UnityEngine;

namespace GameLogic.Bootstrap
{
    public abstract class UnityContext : MonoBehaviour
    {
        protected abstract void OnAwake();

        private void Awake()
        {
            OnAwake();
        }
    }

    public class UnityContext<T> : UnityContext where T : class, ICompositionRoot, new()
    {
        private T _applicationRoot;

        protected override void OnAwake()
        {
            _applicationRoot = new T();
            _applicationRoot.OnContextCreated(this);
        }

        private void OnDestroy()
        {
            _applicationRoot.OnContextDestroyed();
        }

        private void Start()
        {
            if (UnityEngine.Application.isPlaying == true)
            {
                StartCoroutine(WaitForUnityInitialization());
            }
        }

        private void Update()
        {
            _applicationRoot.OnContextUpdate(Time.deltaTime, Time.unscaledDeltaTime);
        }

        private IEnumerator WaitForUnityInitialization()
        {
            yield return new WaitForEndOfFrame();

            _applicationRoot.OnContextInitialized();
        }
    }

    public class StaticUnityContext<T> : UnityContext<T> where T : class, ICompositionRoot, new()
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            DontDestroyOnLoad(this);
        }
    }
}