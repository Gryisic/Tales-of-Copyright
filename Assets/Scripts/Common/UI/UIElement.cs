using UnityEngine;

namespace Common.UI
{
    public abstract class UIElement : MonoBehaviour
    {
        protected UIAnimator animator = new UIAnimator();
        
        public abstract void Activate();

        public abstract void Deactivate();
    }
}
