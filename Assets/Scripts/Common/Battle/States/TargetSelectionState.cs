using System;
using Common.Models.Units;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.States
{
    public class TargetSelectionState : BattleState, IUINavigatable, IPauseProvider
    {
        public event Action RequestPause;
        public event Action EndPause;
        
        public TargetSelectionState(Battle battle) : base(battle) { }

        public override void Enter()
        {
            Time.timeScale = 0;
            
            RequestPause?.Invoke();
            
            battle.TargetSelector.TargetChanged += UpdatePointerPosition;
            battle.TargetSelector.TargetChanged += battle.Camera.FocusOnUnit;
            
            UpdatePointerPosition(battle.TargetSelectionArgs.SelectTo.Target);
            
            battle.Camera.FocusOnUnit(battle.TargetSelectionArgs.SelectTo.Target);
            battle.BattleUI.ActivatePointer();
            battle.Input.UI.Enable();
        }

        public override void Exit()
        {
            battle.Input.UI.Disable();
            battle.BattleUI.DeactivatePointer();
            
            battle.TargetSelector.TargetChanged -= UpdatePointerPosition;
            battle.TargetSelector.TargetChanged -= battle.Camera.FocusOnUnit;
            
            Time.timeScale = 1;
            
            EndPause?.Invoke();
        }

        public void SelectLeft() => battle.TargetSelector.SelectCounterclockwise(battle.TargetSelectionArgs);

        public void SelectRight() => battle.TargetSelector.SelectClockwise(battle.TargetSelectionArgs);

        public void Select() => StateSwitcher.ChangeState<GameplayState>();
        
        public void UndoSelection() { }
        
        private void UpdatePointerPosition(Unit unit) => battle.BattleUI.UpdatePointerPosition(unit.transform, Enums.TargetPointerOrientation.Vertical);
    }
}