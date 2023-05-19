using System;
using System.Collections.Generic;
using Common.Models.Units;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.Battle.TargetSelector
{
    public class NearestTarget : ITargetSelectionStrategy
    {
        private IReadOnlyList<Unit> _selectFrom;

        public NearestTarget(IReadOnlyList<Unit> selectFrom)
        {
            _selectFrom = selectFrom;
        }

        public void UpdatePossibleTargets(IReadOnlyList<Unit> possibleTargets) => _selectFrom = possibleTargets;
        
        public Unit Select(Type targetType, IUnitData selectTo, bool ignoreDead = true)
        {
            Unit closestTarget = null;
            float minDistance = 999;

            foreach (var unit in _selectFrom)
            {
                if (unit.Type != targetType) 
                    continue;
                
                if (ignoreDead == false && unit.IsAlive == false)
                    continue;
                
                float distance = Mathf.Abs(selectTo.Rigidbody2D.position.x - unit.transform.position.x);

                if (distance > minDistance) 
                    continue;
                
                minDistance = distance;
                closestTarget = unit;
            }
            
            return closestTarget;
        }
    }
}