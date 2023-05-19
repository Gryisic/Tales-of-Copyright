using System;
using System.Collections.Generic;
using Common.Models.Camera;
using UnityEngine;

namespace Core.Contexts
{
    public abstract class SceneContext : MonoBehaviour
    {
        [SerializeField] private UIContext _uiContext;
        [SerializeField] private CameraHandler _cameraHandler;

        private Dictionary<Type, object> _registeredTypes;

        public IReadOnlyDictionary<Type, object> RegisteredTypes => _registeredTypes;

        public virtual void Construct()
        {
            _registeredTypes = new Dictionary<Type, object>();

            RegisterInstance(_uiContext);
            RegisterInstance(_cameraHandler);
        }

        public T Resolve<T>() => (T)_registeredTypes[typeof(T)];

        protected void RegisterInstance<T>(T instance) => _registeredTypes.Add(typeof(T), instance);
    }
}