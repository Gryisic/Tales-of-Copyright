using Common.Battle;
using Common.Models.Party;

namespace Common.Data
{
    public class PlayerData
    {
        public PartyData PartyData { get; private set; }
        public AdventureToBattleData AdventureToBattleData { get; private set; }

        public void UpdatePartyData(PartyFormationsTemplate partyFormationsTemplate) =>
            PartyData = new PartyData(partyFormationsTemplate);
        
        public void UpdateAdventureToBattleData(SpawnPointsTemplate[] spawnPointsTemplates) =>
            AdventureToBattleData = new AdventureToBattleData(spawnPointsTemplates);
    }
}