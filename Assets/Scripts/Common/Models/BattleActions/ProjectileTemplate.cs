using UnityEngine;

namespace Common.Models.BattleActions
{
    [CreateAssetMenu(menuName = "Battle / Actions / Projectile", fileName = "Projectile")]
    public class ProjectileTemplate : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _speed;

        public Sprite Sprite => _sprite;
        public float Speed => _speed;
    }
}