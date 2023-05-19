using Common.Models.BattleActions;
using Common.Models.Units;

namespace Common.Battle.BehaviourTree
{
    [System.Serializable]
    public class Blackboard
    {
        private Unit _target;
        private Action _cashedAction;
        private float _awaitTime;
        
        public Unit Target => _target;
        public Action CashedAction => _cashedAction;
        public float AwaitTime => _awaitTime;

        public void SetTarget(Unit target) => _target = target;

        public void SetAction(Action action) => _cashedAction = action;

        public void SetAwaitTime(float time) => _awaitTime = time;

        public void ClearAction() => _cashedAction = null;
    }
}