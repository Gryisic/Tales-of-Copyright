using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using UnityEngine;

namespace Common.Battle
{
    public class ImpactEffects
    {
        private CancellationTokenSource _stopTimeOnHitTokenSource = new CancellationTokenSource();
        
        public void StopTimeOnHit()
        {
            _stopTimeOnHitTokenSource = _stopTimeOnHitTokenSource.CancelAndRefresh();
            
            StopTimeOnHitAsync().Forget();
        }

        private async UniTask StopTimeOnHitAsync()
        {
            Time.timeScale = 0;

            await UniTask.Delay(TimeSpan.FromSeconds(0.1f), ignoreTimeScale: true, cancellationToken: _stopTimeOnHitTokenSource.Token);
            
            Time.timeScale = 1;
        }
    }
}