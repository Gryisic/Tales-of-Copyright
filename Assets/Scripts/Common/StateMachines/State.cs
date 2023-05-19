using Infrastructure.Interfaces;

namespace Common.StateMachines
{
    public abstract class State
    {
        protected IStateSwitcher StateSwitcher;

        protected State(IStateSwitcher stateSwitcher)
        {
            StateSwitcher = stateSwitcher;
        }
        
        public abstract void Enter();

        public abstract void Exit();
    }
}