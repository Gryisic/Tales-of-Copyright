using System;
using System.Collections.Generic;
using Common.Battle;
using Common.Data;
using Common.Models;
using Common.Models.Camera;
using Common.Models.Party;
using Common.Models.Units;
using Common.UI.Battle;
using Core.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = Core.Input.PlayerInput;
using Random = UnityEngine.Random;

namespace Core.GameModes
{
    public class BattleMode : IGameMode, IDeactivatable, IDisposable
    {
        public event Action<GameModeArgs> Finished;

        private Battle _battle;
        
        private readonly GameContext _gameContext;
        private readonly PlayerInput _input;
        
        private BattleContext _battleContext;
        private PlayerData _playerData;
        private BattlePlayer _battlePlayer;

        public BattleMode(GameContext context)
        {
            _gameContext = context;
            _input = context.Resolve<PlayerInput>();
            _playerData = context.Resolve<PlayerData>();
        }

        public void Activate(GameModeArgs args)
        {
            _battleContext = _gameContext.Resolve<SceneContext>() as BattleContext;

            BattleUI battleUI = _battleContext.Resolve<UIContext>().Resolve<BattleUI>();
            BattleMock mock = _battleContext.Resolve<BattleMock>();
            CameraHandler cameraHandler = _battleContext.Resolve<CameraHandler>();
                
            BattleCamera camera = new BattleCamera(cameraHandler.CameraBrain, cameraHandler.VirtualCamera);

            SpawnPointsTemplate spawnPointsTemplate = _playerData.AdventureToBattleData.SpawnPointsTemplate[Random.Range(0, _playerData.AdventureToBattleData.SpawnPointsTemplate.Length)];
            
            BattleArgs battleArgs = new BattleArgs(_playerData.PartyData, battleUI, camera, spawnPointsTemplate);

            _battle = new Battle(battleArgs, _input);

            _battlePlayer = new BattlePlayer(_playerData.PartyData.PlayerUnit);

            SubscribeToEvents();
            AttachInput();

            Time.timeScale = 1;
        }

        public void Deactivate()
        {
            DeAttachInput();
            UnsubscribeToEvents();
            
            _battle.Dispose();

            _battle = null;
        }

        public void Dispose()
        {
            _battle?.Dispose();
        }

        private void AttachInput()
        {
            //_input.Battle.Movement.performed += UpdatePartyPosition;
            //_input.Battle.Movement.canceled += StopUpdatingPosition;
            _input.Battle.Movement.performed += _battlePlayer.StartMoving;
            _input.Battle.Movement.canceled += _battlePlayer.StopMoving;
            _input.Battle.Attack.performed += _battlePlayer.Attack;
            _input.Battle.Skill.performed += _battlePlayer.Action;

            _input.Battle.TargetSelection.performed += _battlePlayer.BeginTargetSelection;
            _input.Battle.CycleClockwise.performed += SelectClockwise;
            _input.Battle.CycleCounterclockwise.performed += SelectCounterclockwise;
            _input.Battle.NextPartyMember.performed += SelectNextPartyMember;
            _input.Battle.PreviousPartyMember.performed += SelectPreviousPartyMember;

            _input.UI.Click.performed += ClickPerformed;
            _input.UI.Cancel.performed += CancelPerformed;
            _input.UI.Navigate.performed += NavigatePerformed;
        }
        
        private void DeAttachInput()
        {
            _input.Disable();

            //_input.Battle.Movement.performed -= UpdatePartyPosition;
            //_input.Battle.Movement.canceled -= StopUpdatingPosition;
            _input.Battle.Movement.performed -= _battlePlayer.StartMoving;
            _input.Battle.Movement.canceled -= _battlePlayer.StopMoving;
            _input.Battle.Attack.performed -= _battlePlayer.Attack;
            _input.Battle.Skill.performed -= _battlePlayer.Action;

            _input.Battle.TargetSelection.performed -= _battlePlayer.BeginTargetSelection;
            _input.Battle.CycleClockwise.performed -= SelectClockwise;
            _input.Battle.CycleCounterclockwise.performed -= SelectCounterclockwise;
            _input.Battle.NextPartyMember.performed -= SelectNextPartyMember;
            _input.Battle.PreviousPartyMember.performed -= SelectPreviousPartyMember;

            _input.UI.Click.performed -= ClickPerformed;
            _input.UI.Cancel.performed -= CancelPerformed;
            _input.UI.Navigate.performed -= NavigatePerformed;
        }

        private void SubscribeToEvents()
        {
            _battlePlayer.ControllableUnitChanged += _battle.Camera.UpdateControllableUnit;
            _battlePlayer.RequestPause += UpdatePause;
            _battlePlayer.RequestTargetSelection += _battle.EnterTargetSelectionState;
            
            _battle.Ended += ChangeToAdventureMode;
            _battle.TargetSelector.TargetChanged += _battlePlayer.UpdateTarget;
        }

        private void UnsubscribeToEvents()
        {
            _battlePlayer.ControllableUnitChanged -= _battle.Camera.UpdateControllableUnit;
            _battlePlayer.RequestPause -= UpdatePause;
            _battlePlayer.RequestTargetSelection -= _battle.EnterTargetSelectionState;
            
            _battle.Ended -= ChangeToAdventureMode;
            _battle.TargetSelector.TargetChanged -= _battlePlayer.UpdateTarget;
        }
        
        private void UpdatePause(bool activate) => Time.timeScale = activate ? 0 : 1;
        
        private void ClickPerformed(InputAction.CallbackContext obj) => _battle.Select();

        private void CancelPerformed(InputAction.CallbackContext obj) => _battle.Cancel();

        private void SelectClockwise(InputAction.CallbackContext obj) => _battle.SelectRight();

        private void SelectCounterclockwise(InputAction.CallbackContext obj) => _battle.SelectLeft();

        private void NavigatePerformed(InputAction.CallbackContext obj)
        {
            Vector2 direction = obj.ReadValue<Vector2>().normalized;

            if (direction.x > 0)
                SelectClockwise(obj);
            else if (direction.x < 0)
                SelectCounterclockwise(obj);
        }
        
        private void SelectNextPartyMember(InputAction.CallbackContext obj)
        {
            List<PartyMember> partyMembers = _battle.UnitsContainer.PartyMembers;
            int currentIndex = partyMembers.IndexOf(_battlePlayer.ControllableUnit);
            PartyMember newUnit = currentIndex + 1 >= partyMembers.Count
                ? partyMembers[0]
                : partyMembers[currentIndex + 1];

            _battlePlayer.UpdateControllableUnit(newUnit);
        }

        private void SelectPreviousPartyMember(InputAction.CallbackContext obj)
        {
            List<PartyMember> partyMembers = _battle.UnitsContainer.PartyMembers;
            int currentIndex = partyMembers.IndexOf(_battlePlayer.ControllableUnit);
            PartyMember newUnit = currentIndex - 1 < 0
                ? partyMembers[partyMembers.Count - 1]
                : partyMembers[currentIndex - 1];
            
            _battlePlayer.UpdateControllableUnit(newUnit);
        }

        private void ChangeToAdventureMode() => 
            Finished?.Invoke(new GameModeArgs(Enums.GameModeType.SceneSwitch, Enums.GameModeType.Adventure, Enums.SceneType.Ruins));
    }
}