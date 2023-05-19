using System;
using System.Collections.Generic;
using Common.Audio;
using Common.Data;
using Common.UI;
using Core.Configs;
using Core.Input;
using UnityEngine;

namespace Core.Contexts
{
    public class GameContext : MonoBehaviour, IDisposable 
    {
        [SerializeField] private AudioHandler _audioHandler;
        [SerializeField] private SceneTransition _sceneTransition;

        [Header("Configs")]
        [SerializeField] private DefaultDataConfig _defaultData;

        private PlayerData _playerData;
        
        private SceneSwitcher _sceneSwitcher;

        private Dictionary<Type, object> _registeredTypes;

        public void Construct()
        {
            _registeredTypes = new Dictionary<Type, object>();
            _sceneSwitcher = new SceneSwitcher(_sceneTransition);

            _playerData = new PlayerData();
            _playerData.UpdatePartyData(_defaultData.PartyFormations);

            RegisterInstance(_sceneSwitcher);
            RegisterInstance(_audioHandler);
            RegisterInstance(_playerData);
            RegisterInstance(_defaultData);
            RegisterInstance(GetInput());

            _sceneSwitcher.SceneChanged += RegisterSceneContext;
        }

        public void Dispose()
        {
            _sceneSwitcher.SceneChanged -= RegisterSceneContext;
        }

        public T Resolve<T>() => (T)_registeredTypes[typeof(T)];

        private void RegisterSceneContext(SceneContext context)
        {
            if (_registeredTypes.ContainsKey(typeof(SceneContext)))
                _registeredTypes.Remove(typeof(SceneContext));

            context.Construct();
            RegisterInstance(context);
        }

        private void RegisterInstance<T>(T instance) => _registeredTypes.Add(typeof(T), instance);

        private PlayerInput GetInput() => new PlayerInput();
    }
}