using Common.Models.Units;

namespace Common.Models.BattleActions
{
    public class ActionHandler
    {
        private UnitAnimator _unitAnimator;
        
        private Action _bufferedAction;

        public Action CurrentAction { get; private set; }
        public ActionsContainer Container { get; private set; }

        public void SetContainer(ActionsContainer container) => Container = container;

        public void SetAnimator(UnitAnimator animator) => _unitAnimator = animator;
        
        public void RegisterAction(Action action)
        {
            if (CurrentAction == null)
            {
                CurrentAction = action;

                _unitAnimator.ExecuteAction += CurrentAction.Execute;
            }
            else
            {
                _bufferedAction = action;
            }
        }

        public void UpdateCurrentActionState()
        {
            if(CurrentAction == null)
                return;
            
            if (_bufferedAction == null)
            {
                _unitAnimator.ExecuteAction -= CurrentAction.Execute;
                
                CurrentAction = null;
            }
            else
            {
                _unitAnimator.ExecuteAction -= CurrentAction.Execute;
                
                CurrentAction = _bufferedAction;
                _bufferedAction = null;
                
                _unitAnimator.ExecuteAction += CurrentAction.Execute;
            }
        }

        public void ClearActions()
        {
            if (CurrentAction != null)
                _unitAnimator.ExecuteAction -= CurrentAction.Execute;
            
            CurrentAction = null;
            _bufferedAction = null;
        }
    }
}