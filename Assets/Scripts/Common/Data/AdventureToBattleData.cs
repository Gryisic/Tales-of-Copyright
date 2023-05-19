using Common.Battle;

namespace Common.Data
{
    public class AdventureToBattleData
    {
        public SpawnPointsTemplate[] SpawnPointsTemplate { get; }
        
        public AdventureToBattleData(SpawnPointsTemplate[] spawnPointsTemplate)
        {
            SpawnPointsTemplate = spawnPointsTemplate;
        }
    }
}