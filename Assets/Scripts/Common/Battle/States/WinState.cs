using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Battle.States
{
    public class WinState : BattleState
    {
        public event Action Ended;
        
        public WinState(Battle battle) : base(battle) { }

        public override void Enter()
        {
            battle.UnitsContainer.All.ForEach(u => u.DeactivateBehaviour());
            
            EndAsync().Forget();
        }

        public override void Exit() { }

        private async UniTask EndAsync()
        {
            Time.timeScale = 0.5f;
            
            await UniTask.Delay(TimeSpan.FromSeconds(2f), ignoreTimeScale: true);

            Time.timeScale = 1f;
            
            await UniTask.Delay(TimeSpan.FromSeconds(5f));
            
            Ended?.Invoke();
        }
    }
}