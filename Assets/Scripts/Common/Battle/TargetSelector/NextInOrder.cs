using System;
using System.Collections.Generic;
using System.Linq;
using Common.Models.Units;
using Infrastructure.Interfaces;

namespace Common.Battle.TargetSelector
{
    public class NextInOrder : ITargetSelectionStrategy
    {
        private bool _isClockwise;
        private Unit _currentTarget;
        private IReadOnlyList<Unit> _selectFrom;

        public NextInOrder(IReadOnlyList<Unit> selectFrom, bool isClockwise)
        {
            _selectFrom = selectFrom;
            _isClockwise = isClockwise;
        }

        public void UpdatePossibleTargets(IReadOnlyList<Unit> possibleTargets) => _selectFrom = possibleTargets;

        public void SetDirection(bool isClockwise) => _isClockwise = isClockwise;

        public void SetDefaultDirection() => _isClockwise = true;
        
        public Unit Select(Type targetType, IUnitData selectTo, bool ignoreDead = true) 
        {
            if (ignoreDead == false)
            {
                List<Unit> possibleTargets = _selectFrom.Where(u => u.Type == targetType && u.IsAlive).ToList();

                _selectFrom = possibleTargets;
            }

            _currentTarget = selectTo.Target == null ? _selectFrom[0] : selectTo.Target;

            return _isClockwise 
                ? SelectClockwise() 
                : SelectCounterClockwise();
        }

        private Unit SelectClockwise()
        {
            int currentIndex = Array.IndexOf(_selectFrom.ToArray(), _currentTarget);

            currentIndex = currentIndex + 1 >= _selectFrom.Count ? 0 : currentIndex + 1;

            _currentTarget = _selectFrom[currentIndex];

            return _currentTarget;
        }
        
        private Unit SelectCounterClockwise()
        {
            int currentIndex = Array.IndexOf(_selectFrom.ToArray(), _currentTarget);

            currentIndex = currentIndex - 1 < 0 ? _selectFrom.Count - 1 : currentIndex - 1; 
            
            _currentTarget = _selectFrom[currentIndex];

            return _currentTarget;
        }
    }
}