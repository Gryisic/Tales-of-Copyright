using Common.Models.BattleActions;
using Infrastructure.Utils;

namespace Common.Battle.BehaviourTree.Actions
{
    public class ChooseNormalAttack : ActionNode
    {
        protected override void Start() { }

        protected override void Stop() { }

        protected override Enums.BehaviourNodeState Update()
        {
            Action attack = unitData.ActionHandler.Container.GetAction(Constants.BaseAttackName);
            
            blackboard.SetAction(attack);
            
            return Enums.BehaviourNodeState.Success;
        }
    }
}