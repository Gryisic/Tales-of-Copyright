using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Random = UnityEngine.Random;

namespace Common.Adventure
{
    public class RandomEncounter
    {
        public event Action Encountered;

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        
        private float _percent = 0;

        public void StartChecking() 
        {
            _tokenSource = _tokenSource.CancelAndRefresh();
            
            CheckPercentageAsync().Forget();
        }

        public void StopChecking() => _tokenSource.Cancel();

        private void RaiseEncounteredEvent()
        {
            _percent = 0;
            
            Encountered?.Invoke();
        }
        
        private async UniTask CheckPercentageAsync()
        {
            while (_tokenSource.IsCancellationRequested == false)
            {
                float randomRate = Random.Range(0, 100);

                _percent += 15;

                if (_percent > 0 && randomRate <= _percent || _percent >= 100)
                {
                    RaiseEncounteredEvent();
                    
                    break;
                }

                await UniTask.Delay(TimeSpan.FromSeconds(5f));
            }
        }
    }
}