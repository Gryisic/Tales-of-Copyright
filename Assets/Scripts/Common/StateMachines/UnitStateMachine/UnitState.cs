using System.Threading;
using Common.Models.Units;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.StateMachines.UnitStateMachine
{
    public abstract class UnitState : State
    {
        protected CancellationTokenSource TokenSource = new CancellationTokenSource();
        
        protected readonly Unit Unit;
        
        protected UnitState(Unit unit, IStateSwitcher stateSwitcher) : base(stateSwitcher)
        {
            Unit = unit;
        }

        public abstract void Cancel();
    }
}