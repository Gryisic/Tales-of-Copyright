using Common.StateMachines;

namespace Infrastructure.Interfaces
{
    public interface IStateSwitcher
    {
        void ChangeState<T>() where T: State;
    }
}