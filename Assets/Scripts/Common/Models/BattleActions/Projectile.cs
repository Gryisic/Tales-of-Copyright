using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.Models.BattleActions
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        public event Action<Projectile> ProjectileCollided; 

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private Collider2D _collider;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        private float _speed;
        private IUnitData _unitData;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _collider.isTrigger = true;
            
            gameObject.SetActive(false);
        }

        public void SetData(IUnitData unitData, ProjectileTemplate template)
        {
            _unitData = unitData;
            _spriteRenderer.sprite = template.Sprite;
            _speed = template.Speed;
        }
        
        public void Launch(Vector2 initialPosition, Vector2 direction) => MoveAsync(initialPosition, direction).Forget();

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out IDamagable damagable) == false || damagable.GetType() == _unitData.Type || damagable.IsAlive == false) 
                return;

            damagable.TakeDamage(_unitData);
                    
            _tokenSource.Cancel();
            
            ProjectileCollided?.Invoke(this);
        }

        private async UniTask MoveAsync(Vector2 initialPosition, Vector2 direction)
        {
            float timer = 0;
            
            gameObject.SetActive(true);

            transform.position = initialPosition;
            
            while (_tokenSource.IsCancellationRequested == false && timer < 5)
            {
                _rigidbody2D.velocity = direction * _speed * Time.fixedDeltaTime;
                
                await UniTask.WaitForFixedUpdate();

                timer += Time.fixedDeltaTime;
            }
            
            gameObject.SetActive(false);
        }
    }
}