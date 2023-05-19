using Common.Models.Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common.Battle
{
    public class SpawnPoint : MonoBehaviour
    {
        [FormerlySerializedAs("_unit")] [SerializeField] private Enemy enemy;

        public Vector2 Position => transform.position;
        public Enemy Enemy => enemy;
    }
}