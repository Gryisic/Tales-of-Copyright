using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Infrastructure.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class TargetPointer : UIElement
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Image _verticalPointer;
        [SerializeField] private Image _horizontalPointer;

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        
        private bool _isActive;
        
        public override void Activate() 
        {
            gameObject.SetActive(true);

            _isActive = true;
        }

        public override void Deactivate()
        {
            gameObject.SetActive(false);
            
            _verticalPointer.gameObject.SetActive(false);
            _horizontalPointer.gameObject.SetActive(false);
            
            _isActive = false;
        }

        public void UpdatePointerPosition(Transform targetTransform, Enums.TargetPointerOrientation orientation, bool isTransformInWorldSpace = true)
        {
            _tokenSource.Cancel();
            
            Vector2 newPosition = targetTransform.position;

            Image pointer = orientation == Enums.TargetPointerOrientation.Vertical
                ? _verticalPointer
                : _horizontalPointer;

            if (isTransformInWorldSpace)
            {
                newPosition = RectTransformUtility.WorldToScreenPoint(_camera, newPosition);

                newPosition = new Vector2(newPosition.x, newPosition.y + 150);

                UpdatePositionAsync(targetTransform, pointer).Forget();
            }

            if (_isActive) 
                return;
            
            Activate();
                
            pointer.gameObject.SetActive(true);
        }

        private async UniTask UpdatePositionAsync(Transform targetTransform, Image pointer)
        {
            float timer = 0;
            Vector2 newPosition = targetTransform.position;

            while (_tokenSource.IsCancellationRequested == false && timer < 2)
            {
                newPosition = targetTransform.position;
                newPosition = RectTransformUtility.WorldToScreenPoint(_camera, newPosition);
                
                newPosition = new Vector2(newPosition.x, newPosition.y + 150);

                pointer.transform.position = newPosition;

                await UniTask.Delay(TimeSpan.FromSeconds(Time.fixedUnscaledDeltaTime), ignoreTimeScale: true);

                timer += Time.fixedUnscaledDeltaTime;
            }

            _tokenSource = _tokenSource.CancelAndRefresh();
        }
    }
}