using System;
using Cinemachine;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Camera
{
    public class BattleCamera : Camera
    {
        private Transform _controllableUnitTransform;
        
        public BattleCamera(CinemachineBrain cameraBrain, CinemachineVirtualCamera camera) : base(cameraBrain, camera) { }

        public void Activate(Unit followAfter)
        {
            InitialSpanAsync(followAfter).Forget();
            
            UpdateControllableUnit(followAfter);
        }

        public void FollowControllableUnit() => Follow(_controllableUnitTransform);

        public void FollowUnit(Unit unit) => Follow(unit.transform);

        public void FocusOnUnit(Unit unit) => FollowUnit(unit);

        public void ChangeUpdateMethod(bool isGamePaused) =>
            cameraBrain.m_UpdateMethod = isGamePaused ? CinemachineBrain.UpdateMethod.LateUpdate : CinemachineBrain.UpdateMethod.FixedUpdate;

        public void UpdateControllableUnit(IUnitData unit)
        {
            _controllableUnitTransform = unit.Rigidbody2D.transform;
            
            FollowControllableUnit();
        }

        private async UniTask InitialSpanAsync(Unit followAfter)
        {
            camera.m_Lens.OrthographicSize = Constants.CameraSizeAtTheStartOfBattle;

            float currentTime = 0;
            float blendingTime = 0.7f;
            float blendingSpeed = 2f;
            float targetSize = Constants.CameraSizeDuringBattle;
            
            while (currentTime <= blendingTime)
            {
                float currentSize = camera.m_Lens.OrthographicSize;
                
                camera.m_Lens.OrthographicSize = Mathf.Lerp(currentSize, targetSize, Time.fixedDeltaTime * blendingSpeed);
                
                await UniTask.WaitForFixedUpdate();

                currentTime += Time.fixedDeltaTime;
            }

            FollowUnit(followAfter);
        }
    }
}