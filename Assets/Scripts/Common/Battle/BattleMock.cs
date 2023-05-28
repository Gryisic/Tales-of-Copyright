using UnityEngine;

namespace Common.Battle
{
    public class BattleMock : MonoBehaviour
    {
        [SerializeField] private SpawnPointsTemplate _enemiesTemplate;

        public SpawnPointsTemplate EnemiesTemplate => _enemiesTemplate;
    }
}