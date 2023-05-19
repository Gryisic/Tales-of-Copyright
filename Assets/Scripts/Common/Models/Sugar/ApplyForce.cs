using UnityEngine;

namespace Common.Models.Sugar
{
    [CreateAssetMenu(menuName = "Battle / Sugar / Force", fileName = "Force")]
    public class ApplyForce : ScriptableObject
    {
        [SerializeField] private Vector2 _force;

        public Vector2 Force => _force;
    }
}