using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Units
{
    [RequireComponent(typeof(Rigidbody2D), typeof(UnitAnimator))]
    public class AdventureUnit : MonoBehaviour
    {
        [SerializeField] private Collider2D _interactionCollider;
        [SerializeField] private UnitAnimator _animator;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void StartMoving(Vector2 movementVector) 
        {
            Rotate(movementVector);
            
            _animator.Play(Constants.MoveName);
            
            _rigidbody2D.velocity = movementVector * Constants.AdventureUnitSpeed;
        }

        public void StopMoving() 
        {
            _animator.Play(Constants.IdleName);
            
            _rigidbody2D.velocity = Vector2.zero;
        }

        public void Interact()
        {
            Collider2D[] colliders = new Collider2D[10];
            var collidersCount = Physics2D.OverlapCircleNonAlloc(_interactionCollider.transform.position, _interactionCollider.bounds.size.x / 2, colliders);

            for (int i = 0; i < collidersCount; i++)
            {
                if (colliders[i].TryGetComponent(out IInteractable interactable) == false)
                    continue;
                
                interactable.Interact();
                return;
            }
        }
        
        private void Rotate(Vector2 direction)
        {
            float rotationAngle = direction.x >= 0 ? 0f : 180f;

            _rigidbody2D.transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}