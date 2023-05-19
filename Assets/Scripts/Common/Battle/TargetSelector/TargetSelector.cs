using System;
using System.Collections.Generic;
using Common.Models.Units;
using Infrastructure.Interfaces;
using Infrastructure.Utils;

namespace Common.Battle.TargetSelector
{
    public class TargetSelector
    {
        public event Action<Unit> TargetChanged;

        private IReadOnlyList<Unit> _selectFrom = new List<Unit>();
        
        private ITargetSelectionStrategy _selectionStrategy;
        private Dictionary<Enums.TargetSelectionStrategy, ITargetSelectionStrategy> _selectionStrategies;
        
        private bool _ignoreDead;
        private Unit _currentTarget;

        public TargetSelector(IReadOnlyList<Unit> possibleTargets)
        {
            Initialize(possibleTargets);
        }
        
        private void Initialize(IReadOnlyList<Unit> possibleTargets)
        {
            _selectFrom = possibleTargets;
            
            _selectionStrategies = new Dictionary<Enums.TargetSelectionStrategy, ITargetSelectionStrategy>()
            {
                {Enums.TargetSelectionStrategy.Nearest, new NearestTarget(_selectFrom)},
                {Enums.TargetSelectionStrategy.NextInOrder,new NextInOrder(_selectFrom, true)}
            };
        }

        public void UpdatePossibleTargets(IReadOnlyList<Unit> possibleTargets) => _selectFrom = possibleTargets;

        public void SelectClockwise(TargetSelectionArgs args) =>
            SelectManually(args, true);
        
        public void SelectCounterclockwise(TargetSelectionArgs args) =>
            SelectManually(args, false);

        public Unit Select(TargetSelectionArgs args)
        {
            Type typeToSelect = TypeToSelect(args.TargetType, args.SelectTo);
            
            _selectionStrategy = _selectionStrategies[args.SelectionStrategy];

            return _selectionStrategy.Select(typeToSelect, args.SelectTo, args.IgnoreDead);
        }

        private void SelectManually(TargetSelectionArgs args, bool isClockwise)
        {
            NextInOrder nextInOrder = _selectionStrategies[Enums.TargetSelectionStrategy.NextInOrder] as NextInOrder;
            
            nextInOrder.SetDirection(isClockwise);

            Unit target = Select(args);

            _currentTarget = target;
            
            TargetChanged?.Invoke(target);
            
            nextInOrder.SetDefaultDirection();
        }

        private Type TypeToSelect(Enums.TargetType type, IUnitData selectTo)
        {
            return type switch
            {
                Enums.TargetType.SameAsUnit => selectTo.Type == typeof(PartyMember) ? typeof(PartyMember) : typeof(Enemy),
                Enums.TargetType.Opposite => selectTo.Type == typeof(PartyMember) ? typeof(Enemy) : typeof(PartyMember),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}