using System.Collections.Generic;
using Common.Models.Units;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.UI.Battle
{
    public class BattleUI : UIElement
    {
        [SerializeField] private PartyStatus _partyStatus;
        [SerializeField] private TargetPointer _targetPointer;
        
        public override void Activate() { }

        public override void Deactivate() { }

        public void Initialize(IReadOnlyList<PartyMember> partyMembers)
        {
            _partyStatus.Initialize(partyMembers);
            _partyStatus.Activate();
        }
        
        public void UpdatePartyMemberHealth(Unit partyMember, int health) =>
            _partyStatus.UpdateHealth(partyMember, health);
        
        public void UpdatePartyMemberEnergy(Unit partyMember, int energy) =>
            _partyStatus.UpdateEnergy(partyMember, energy);

        public void ShakePartyMemberStatus(IDamagable damagable, int value)
        {
            Unit unit = damagable as Unit;
            
            _partyStatus.ShakeStatus(unit);
        }

        public void ActivatePointer() => _targetPointer.Activate();

        public void DeactivatePointer() => _targetPointer.Deactivate();
        
        public void UpdatePointerPosition(Transform targetTransform, Enums.TargetPointerOrientation orientation,
            bool isTransformInWorldSpace = true) => _targetPointer.UpdatePointerPosition(targetTransform, orientation, isTransformInWorldSpace);
    }
}