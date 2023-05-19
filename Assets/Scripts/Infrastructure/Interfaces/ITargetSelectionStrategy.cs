using System;
using Common.Models.Units;

namespace Infrastructure.Interfaces
{
    public interface ITargetSelectionStrategy
    {
        Unit Select(Type targetType, IUnitData selectTo, bool ignoreDead = true);
    }
}