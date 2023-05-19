using System;
using System.Collections.Generic;
using Common.Battle.TargetSelector;
using Common.Models.BattleActions;
using Common.Models.StatSystem;
using Common.Models.Sugar;
using Common.Models.Units;
using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IUnitData
    {
        Type Type { get; }
        Unit Target { get; }
        IReadOnlyList<Unit> UnitsInBattle { get; }
        DirectionHandler DirectionHandler { get; }
        Rigidbody2D Rigidbody2D { get; }
        UnitAnimator Animator { get; }
        ActionHandler ActionHandler { get; }
        Stats Stats { get; }
        Collider2D HitBox { get; }
        TargetSelector TargetSelector { get; }
        
        bool IsAlive { get; }
        bool IsStaggered { get; }
        bool IsAwaiting { get; }
    }
}