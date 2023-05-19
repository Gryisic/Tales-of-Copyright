using Common.StateMachines;

namespace Common.Battle.States
{
    public abstract class BattleState : State
    {
        protected Battle battle;

        protected BattleState(Battle battle) : base(battle)
        {
            this.battle = battle;
        }
    }
}