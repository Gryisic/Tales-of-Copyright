using Common.Battle.TargetSelector;
using Common.Models.Units;
using Infrastructure.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Models
{
    public class BattlePlayer
    {
        public event System.Action<PartyMember> ControllableUnitChanged;
        public event System.Action<TargetSelectionArgs> RequestTargetSelection;
        public event System.Action<bool> RequestPause;

        private PartyMember _controllableUnit;

        public PartyMember ControllableUnit => _controllableUnit;

        public BattlePlayer(PartyMember controllableUnit)
        {
            _controllableUnit = controllableUnit;
            
            _controllableUnit.ChangeBehaviour(Enums.BehaviourType.Player);
        }

        public void StartMoving(InputAction.CallbackContext context)
        {
            Vector2 movementVector = context.ReadValue<Vector2>();

            _controllableUnit.StartMoving(movementVector);
        }

        public void StopMoving(InputAction.CallbackContext context)
        {
            _controllableUnit.StopMoving();
        }

        public void Attack(InputAction.CallbackContext context) => _controllableUnit.Attack();

        public void Action(InputAction.CallbackContext context) 
        {
            _controllableUnit.UpdateAction(_controllableUnit.ActiveActions[0]);
        }

        public void BeginTargetSelection(InputAction.CallbackContext context)
        {
            RequestTargetSelection?.Invoke(new TargetSelectionArgs(Enums.TargetSelectionStrategy.NextInOrder, Enums.TargetType.Opposite, _controllableUnit, false));
            
            RequestPause?.Invoke(true);
        }

        public void UpdateTarget(Unit target) => _controllableUnit.UpdateTarget(target);

        public void UpdateControllableUnit(PartyMember partyMember)
        {
            _controllableUnit.ChangeBehaviour(Enums.BehaviourType.Default);
            _controllableUnit = partyMember;
            _controllableUnit.ChangeBehaviour(Enums.BehaviourType.Player);

            ControllableUnitChanged?.Invoke(_controllableUnit);
        }
    }
}