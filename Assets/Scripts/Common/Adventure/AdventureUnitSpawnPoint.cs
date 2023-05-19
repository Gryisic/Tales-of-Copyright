using UnityEngine;

namespace Common.Adventure
{
    public class AdventureUnitSpawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        public Transform SpawnPoint => _spawnPoint;
    }
}