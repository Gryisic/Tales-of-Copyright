using UnityEngine;

namespace Common.Models.BattleActions
{
    public abstract class Action
    {
        public event System.Action<Action> ExecutionRequested;
        public event System.Action<int> EnergyUsed;
        
        public readonly string Name;
        public readonly AnimationClip Animation;
        public readonly int EnergyCost;
        public readonly float ExecutionDistance;
        public readonly bool IsSkill;

        private bool _isExecuting;

        protected Action(ActionTemplate template)
        {
            Name = template.Name;
            Animation = template.Animation;
            EnergyCost = template.EnergyCost;
            ExecutionDistance = template.ExecutionDistance;
            IsSkill = template.IsSkill;
        }

        public virtual void Execute()
        {
            if (_isExecuting == false)
            {
                _isExecuting = true;
                
                EnergyUsed?.Invoke(EnergyCost);
            }
        }

        public void RequestExecution()
        {
            _isExecuting = false;
            
            ExecutionRequested?.Invoke(this);
        }
    }
}