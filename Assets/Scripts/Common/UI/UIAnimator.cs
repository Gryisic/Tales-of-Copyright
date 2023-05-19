using DG.Tweening;
using UnityEngine;

namespace Common.UI
{
    public class UIAnimator
    {
        public void FadeIn(CanvasGroup canvasGroup, float duration) => canvasGroup.DOFade(1, duration).From(0);

        public void FadeOut(CanvasGroup canvasGroup, float duration) => canvasGroup.DOFade(0, duration).SetEase(Ease.InOutCubic);

        public void Shake(RectTransform transform, float duration) => transform.DOShakeAnchorPos(duration, strength: 5f);
    }
}