using System;
using System.Threading;
using Common.Models.Units;
using Action = Common.Models.BattleActions.Action;

namespace Common.StateMachines.UnitStateMachine
{
    public class UnitArgs : EventArgs
    {
        public readonly UnitAnimator UnitAnimator;
        public readonly CancellationTokenSource TokenSource;

        public Action Action { get; private set; }

        public UnitArgs(UnitAnimator unitAnimator, CancellationTokenSource tokenSource)
        {
            UnitAnimator = unitAnimator;
            TokenSource = tokenSource;
        }

        public void AddAction(Action action) => Action = action;

        public void RemoveAction() => Action = null;
    }
}