using UnityEngine;

namespace Common.Battle.States
{
    public class LoseState : BattleState
    {
        public LoseState(Battle battle) : base(battle) { }

        public override void Enter()
        {
            Debug.Log("Lose");
            
            battle.UnitsContainer.All.ForEach(u => u.DeactivateBehaviour());
        }

        public override void Exit() { }
    }
}