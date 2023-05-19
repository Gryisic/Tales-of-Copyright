using Common.Battle.TargetSelector;
using Common.Models.Units;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.BehaviourTree.Actions
{
    public class FindTarget : ActionNode
    {
        [SerializeField] private Enums.TargetSelectionStrategy _targetSelectionStrategy;
        [SerializeField] private Enums.TargetType _targetType;
        [SerializeField] private bool _ignoreDead;

        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            if (blackboard.Target != null) 
                return Enums.BehaviourNodeState.Success;

            Unit target = unitData.TargetSelector.Select(new TargetSelectionArgs(_targetSelectionStrategy, _targetType, unitData, _ignoreDead));
            
            blackboard.SetTarget(target);

            return blackboard.Target != null 
                ? Enums.BehaviourNodeState.Success 
                : Enums.BehaviourNodeState.Failure;
        }
    }
}