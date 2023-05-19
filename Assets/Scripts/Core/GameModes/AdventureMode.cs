using System;
using System.Threading;
using Common.Adventure;
using Common.Adventure.Triggers;
using Common.Audio;
using Common.Battle;
using Common.Data;
using Common.Dialogue;
using Common.Factories;
using Common.Models;
using Common.Models.Camera;
using Common.Models.Units;
using Core.Contexts;
using Cysharp.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Core.Input.PlayerInput;

namespace Core.GameModes
{
    public class AdventureMode : IGameMode, IDeactivatable, IResettable, IDisposable
    {
        public event Action<GameModeArgs> Finished;

        private readonly CashedData _cashedData = new CashedData();
        private readonly RandomEncounter _randomEncounter = new RandomEncounter();
        
        private readonly GameContext _gameContext;
        private readonly PlayerInput _input;
        private readonly PlayerData _playerData;
        private readonly AudioHandler _audio;
        
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        
        private AdventureContext _adventureContext;
        private AdventurePlayer _player;
        private AdventureCamera _adventureCamera;
        
        private TriggersContainer _triggersContainer;

        private bool _isConstructed;
        private bool _isResetRequired;
        
        public AdventureMode(GameContext gameContext)
        {
            _gameContext = gameContext;
            _input = _gameContext.Resolve<PlayerInput>();
            _playerData = _gameContext.Resolve<PlayerData>();
            _audio = _gameContext.Resolve<AudioHandler>();
        }

        public void Activate(GameModeArgs args)
        {
            _adventureContext = _gameContext.Resolve<SceneContext>() as AdventureContext;
            _triggersContainer = _adventureContext.Resolve<TriggersContainer>();

            if (_cashedData.PlayerPosition == Vector2.zero)
            {
                AdventureUnitSpawnPoint spawnPoint = _adventureContext.Resolve<AdventureUnitSpawnPoint>();
                _cashedData.UpdateData(spawnPoint.SpawnPoint.position);
            }

            _audio.BackgroundMusic.ChangeToAdventureMusic();
            
            CreatePlayerUnit();
            SubscribeToEvents();
            AttachInput();
            AttachCamera();
        }

        public void Deactivate()
        {
            DeAttachInput();
            UnsubscribeToEvents();
        }
        
        public void Dispose()
        {
            _tokenSource.Cancel();
            _tokenSource.Dispose();
        }
        
        public void Reset()
        {
            if (_isResetRequired)
                _isConstructed = false;
        }

        private void AttachInput()
        {
            _input.Adventure.Movement.performed += _player.StartMoving;
            _input.Adventure.Movement.canceled += _player.StopMoving;
            _input.Adventure.Interact.performed += _player.Interact;
            
            _input.Adventure.Movement.started += StartEncounterChecking;
            _input.Adventure.Movement.canceled += StopEncounterChecking;
            
            _input.Adventure.Enable();
        }

        private void DeAttachInput()
        {
            _input.Adventure.Disable();
            
            _input.Adventure.Movement.performed -= _player.StartMoving;
            _input.Adventure.Movement.canceled -= _player.StopMoving;
            _input.Adventure.Interact.performed -= _player.Interact;
            
            _input.Adventure.Movement.started -= StartEncounterChecking;
            _input.Adventure.Movement.canceled -= StopEncounterChecking;
        }

        private void SubscribeToEvents()
        {
            _randomEncounter.Encountered += ChangeToBattleMode;
            
            foreach (var trigger in _triggersContainer.Triggers)
            {
                if (trigger is DialogueTrigger dialogueTrigger)
                    dialogueTrigger.DialogueInitiated += ChangeToDialogueMode;
            }
        }

        private void UnsubscribeToEvents()
        {
            _randomEncounter.Encountered -= ChangeToBattleMode;
            
            foreach (var trigger in _triggersContainer.Triggers)
            {
                if (trigger is DialogueTrigger dialogueTrigger)
                    dialogueTrigger.DialogueInitiated -= ChangeToDialogueMode;
            }
        }
        
        private void CreatePlayerUnit()
        {
            if (_player != null && _player.IsExist) 
                return;
            
            AdventureUnitFactory adventureUnitFactory = new AdventureUnitFactory();
            
            adventureUnitFactory.Load(Enums.PartyMemberType.Swordsman);
            adventureUnitFactory.Create(_cashedData.PlayerPosition, out AdventureUnit unit);

            _player = new AdventurePlayer(unit);
        }

        private void AttachCamera()
        {
            CameraHandler cameraHandler = _adventureContext.Resolve<CameraHandler>();
            _adventureCamera = new AdventureCamera(cameraHandler.CameraBrain, cameraHandler.VirtualCamera);
            
            _adventureCamera.Activate(_player.Transform);
        }

        private void StartEncounterChecking(InputAction.CallbackContext obj) => _randomEncounter.StartChecking();
        
        private void StopEncounterChecking(InputAction.CallbackContext obj) => _randomEncounter.StopChecking();

        private void ChangeToDialogueMode(DialogueProvider dialogueProvider) => 
            Finished?.Invoke(new GameModeArgs(Enums.GameModeType.Dialogue, Enums.GameModeType.Adventure, dialogueProvider));

        private void ChangeToBattleMode() => ChangeToBattleModeAsync().Forget();

        private async UniTask ChangeToBattleModeAsync()
        {
            DeAttachInput();
            
            _cashedData.UpdateData(_player.Transform.position);

            UniTask cameraTask = _adventureCamera.ChangeToBattleModeAsync(_tokenSource.Token);
            UniTask audioTask = _audio.BackgroundMusic.ChangeToBattleMusicAsync(_tokenSource.Token);
            UniTask delayTask = UniTask.Delay(TimeSpan.FromSeconds(Constants.AdventureToBattleModeSwitchTime), ignoreTimeScale: true, cancellationToken: _tokenSource.Token);
            
            Time.timeScale = 0;
            
            await UniTask.WhenAll(cameraTask, audioTask, delayTask);

            SpawnPointsTemplate[] spawnPointsTemplates = _adventureContext.Resolve<SpawnPointsTemplate[]>();

            _playerData.UpdateAdventureToBattleData(spawnPointsTemplates);

            Finished?.Invoke(new GameModeArgs(Enums.GameModeType.SceneSwitch, Enums.GameModeType.Battle, Enums.SceneType.Battle));
        }
    }
}