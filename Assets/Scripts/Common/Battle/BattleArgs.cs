using System;
using Common.Data;
using Common.Models.Camera;
using Common.UI.Battle;

namespace Common.Battle
{
    public class BattleArgs : EventArgs
    {
        public SpawnPointsTemplate SpawnPointsTemplate { get; }
        public BattleUI UI { get; }
        public BattleCamera Camera { get; }
        public PartyData PartyData { get; }

        public BattleArgs(PartyData partyData, BattleUI ui, BattleCamera camera, SpawnPointsTemplate spawnPointsTemplate)
        {
            PartyData = partyData;
            UI = ui;
            Camera = camera;
            SpawnPointsTemplate = spawnPointsTemplate;
        }
    }
}