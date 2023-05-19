using System;
using Infrastructure.Interfaces;

namespace Common.StateMachines
{
    public abstract class StateMachine : IStateSwitcher, IDisposable
    {
        protected State CurrentState;
        
        public abstract void ChangeState<T>() where T : State;
        
        public abstract void Dispose();
    }
}