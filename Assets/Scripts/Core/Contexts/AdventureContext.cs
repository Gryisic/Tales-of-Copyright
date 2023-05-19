using Common.Adventure;
using Common.Adventure.Triggers;
using Common.Battle;
using UnityEngine;

namespace Core.Contexts
{
    public class AdventureContext : SceneContext
    {
        [SerializeField] private AdventureUnitSpawnPoint _adventureUnitSpawnPoint;
        [SerializeField] private TriggersContainer _triggersContainer;
        [SerializeField] private SpawnPointsTemplate[] _battleSpawnPoints;

        public override void Construct()
        {
            base.Construct();
            
            RegisterInstance(_adventureUnitSpawnPoint);
            RegisterInstance(_triggersContainer);
            RegisterInstance(_battleSpawnPoints);
        }
    }
}