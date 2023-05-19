using System.Linq;
using Common.Models.Units;
using Infrastructure.Interfaces;

namespace Common.StateMachines.UnitStateMachine
{
    public class UnitStateMachine : StateMachine
    {
        private readonly UnitState[] _unitStates;
        private readonly Unit _unit;

        public UnitStateMachine(Unit unit)
        {
            _unit = unit;
            
            _unitStates = new UnitState[]
            {
                new NeutralState(unit, this),
                new MoveState(unit, this),
                new ActionState(unit, this),
                new StaggerState(unit, this),
                new DeathState(unit, this)
            };

            unit.DamageTaken += ForciblyChangeState;
            unit.Died += ForciblyChangeState;
            
            foreach (var state in _unitStates)
            {
                if (state is IUnitActionExecutable executable)
                {
                    executable.ActionExecuted += unit.UpdateCurrentActionState;
                    executable.ActionCancelled += unit.ClearActions;
                }
            }
        }
        
        public override void Dispose()
        {
            _unit.DamageTaken -= ForciblyChangeState;
            _unit.Died -= ForciblyChangeState;
            
            foreach (var state in _unitStates)
            {
                if (state is IUnitActionExecutable executable)
                {
                    executable.ActionExecuted -= _unit.UpdateCurrentActionState;
                    executable.ActionCancelled -= _unit.ClearActions;
                }
            }
        }
        
        public override void ChangeState<T>() 
        {
            CurrentState?.Exit();
            
            CurrentState = _unitStates.FirstOrDefault(state => state is T);

            CurrentState.Enter();
        }

        public void Start() => ChangeState<NeutralState>();

        public void Stop()
        {
            UnitState state = CurrentState as UnitState;
            
            state?.Cancel();
        }

        private void ForciblyChangeState(IDamagable damagable, int damage) => ForciblyChangeState<StaggerState>();

        private void ForciblyChangeState(Unit unit) => ForciblyChangeState<DeathState>();

        private void ForciblyChangeState<T>() where T: UnitState
        {
            if (CurrentState is UnitState unitState)
                unitState.Cancel();
            
            ChangeState<T>();
        }
    }
}