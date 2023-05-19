namespace Common.Battle.States
{
    public class GameplayState : BattleState
    {
        public GameplayState(Battle battle) : base(battle) { }

        public override void Enter()
        {
            battle.Camera.FollowControllableUnit();
            battle.Input.Battle.Enable();
        }

        public override void Exit()
        {
            battle.Input.Battle.Disable();
        }
    }
}