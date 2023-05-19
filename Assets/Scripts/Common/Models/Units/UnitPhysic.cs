using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Units
{
    public class UnitPhysic : IDisposable
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private Vector2 _gravityVector;
        private Rigidbody2D _rigidbody;

        public UnitPhysic(Rigidbody2D rigidbody) 
        {
            _rigidbody = rigidbody;
            _gravityVector = new Vector2(0, -Physics2D.gravity.y);
        }

        public void Dispose()
        {
            _tokenSource.Cancel();
            
            _tokenSource.Dispose();
        }

        public void Update() => UpdateAsync().Forget();

        private async UniTask UpdateAsync() 
        {
            while (_tokenSource.IsCancellationRequested == false) 
            {
                if (_rigidbody.velocity.y < 0)
                {
                    _rigidbody.velocity -= _gravityVector * Constants.FallMultiplier * Time.fixedDeltaTime;
                }
                else if (_rigidbody.velocity.y > 0)
                {
                    _rigidbody.velocity *= Constants.LinearVelocitySlowdownSpeed;
                }

                await UniTask.WaitForFixedUpdate();
            }
        }
    }
}