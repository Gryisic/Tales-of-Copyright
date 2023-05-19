using UnityEngine;

namespace Common.Adventure.Triggers
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Trigger : MonoBehaviour
    {
        protected Collider2D triggerCollider2D;
        
        private void Awake()
        {
            Initialize();
        }

        public abstract void Execute();

        private void Initialize()
        {
            triggerCollider2D = GetComponent<Collider2D>();
            triggerCollider2D.isTrigger = true;
        }
    }
}