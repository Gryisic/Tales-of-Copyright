using System.Collections.Generic;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle
{
    public class SpawnPointsTemplate : MonoBehaviour
    {
        [SerializeField] private Enums.PartyPlacementSide _partySide;
        [SerializeField] private SpawnPoint[] _spawnPoints;

        public Enums.PartyPlacementSide PartySide => _partySide;
        public IReadOnlyCollection<SpawnPoint> SpawnPoints => _spawnPoints;
    }
}