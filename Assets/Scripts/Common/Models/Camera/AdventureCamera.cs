using System;
using System.Threading;
using Cinemachine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Camera
{
    public class AdventureCamera : Camera
    {
        private Transform _followAfter;
        
        public AdventureCamera(CinemachineBrain cameraBrain, CinemachineVirtualCamera camera) : base(cameraBrain, camera) { }

        public void Activate(Transform followAfter)
        {
            _followAfter = followAfter;

            Follow(_followAfter);
        }

        public void FocusOn(Transform transform) => Focus(transform);
        
        public async UniTask ChangeToBattleModeAsync(CancellationToken cancellationToken)
        {
            float timer = 0;
            float inTime = Constants.AdventureToBattleModeSwitchTime / 3;
            float outTime = Constants.AdventureToBattleModeSwitchTime - inTime;
            float maxBounceSize = Constants.CameraSizeDuringAdventure + 1;
            float minBounceSize = Constants.CameraSizeDuringAdventure - 3;

            cameraBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.LateUpdate;
            
            while (timer < inTime && cancellationToken.IsCancellationRequested == false)
            {
                camera.m_Lens.OrthographicSize = Mathf.Lerp(camera.m_Lens.OrthographicSize, maxBounceSize, Time.fixedUnscaledDeltaTime * 2);
                
                await UniTask.Delay(TimeSpan.FromSeconds(Time.fixedUnscaledDeltaTime), ignoreTimeScale: true, cancellationToken: cancellationToken);

                timer += Time.fixedUnscaledDeltaTime;
            }

            timer = 0;
            
            while (timer < outTime && cancellationToken.IsCancellationRequested == false)
            {
                camera.m_Lens.OrthographicSize = Mathf.Lerp(camera.m_Lens.OrthographicSize, minBounceSize, Time.fixedUnscaledDeltaTime * 3);
                
                await UniTask.Delay(TimeSpan.FromSeconds(Time.fixedUnscaledDeltaTime), ignoreTimeScale: true, cancellationToken: cancellationToken);

                timer += Time.fixedUnscaledDeltaTime;
            }
            
            cameraBrain.m_UpdateMethod = CinemachineBrain.UpdateMethod.FixedUpdate;
        }
    }
}