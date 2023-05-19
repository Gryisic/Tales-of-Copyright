using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class SceneTransition : UIElement
    {
        private const string ProgressPropertyName = "_Progress";

        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Material _transitionMaterial;
        [SerializeField] private Image _image;

        private int _progressPropertyID;

        private void Awake()
        {
            _progressPropertyID = Shader.PropertyToID(ProgressPropertyName);

            _image.material = null;
        }

        public override void Activate() { }

        public override void Deactivate() { }

        public async UniTask ActivateAsync()
        {
            gameObject.SetActive(true);

            animator.FadeIn(_canvasGroup, 1f);

            await UniTask.Delay(TimeSpan.FromSeconds(1f));
        }

        public async UniTask DeactivateAsync()
        {
            animator.FadeOut(_canvasGroup, 1f);

            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            
            gameObject.SetActive(false);
        }

        public async UniTask TransitionToBattleAsync()
        {
            _image.material = _transitionMaterial;
            _canvasGroup.alpha = 1;
            
            gameObject.SetActive(true);
            
            float timer = 0;

            while (timer < 1f)
            {
                _transitionMaterial.SetFloat(_progressPropertyID, 1 - timer);
                
                await UniTask.Delay(TimeSpan.FromSeconds(Time.fixedUnscaledDeltaTime), ignoreTimeScale: true);
                
                timer += Time.fixedUnscaledDeltaTime;
            }
            
            _image.material = null;
        }
    }
}