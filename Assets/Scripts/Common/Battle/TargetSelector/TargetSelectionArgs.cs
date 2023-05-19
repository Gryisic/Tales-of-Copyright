using System;
using Infrastructure.Interfaces;
using Infrastructure.Utils;

namespace Common.Battle.TargetSelector
{
    public class TargetSelectionArgs : EventArgs
    {
        public Enums.TargetSelectionStrategy SelectionStrategy { get; private set; }
        public Enums.TargetType TargetType { get; private set; }
        public IUnitData SelectTo { get; private set; }
        public bool IgnoreDead { get; private set; }

        public TargetSelectionArgs(Enums.TargetSelectionStrategy selectionStrategy, Enums.TargetType targetType, IUnitData selectTo, bool ignoreDead = true)
        {
            SelectionStrategy = selectionStrategy;
            TargetType = targetType;
            SelectTo = selectTo;
            IgnoreDead = ignoreDead;
        }
    }
}