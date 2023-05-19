using UnityEngine;

namespace Infrastructure.Utils
{
    public static class Constants
    {
        public const int StartSceneIndex = 0;

        public const float AdventureUnitSpeed = 3f;

        public const float AdventureToBattleModeSwitchTime = 1.8f;
        public const float BattleInitiationTime = 1.5f;
        
        public const float CameraSizeDuringAdventure = 5f;
        public const float CameraSizeAtTheStartOfBattle = 5f;
        public const float CameraSizeDuringBattle = 4f;

        public const float FallMultiplier = 3f;
        public const float LinearVelocitySlowdownSpeed = 0.9f;

        public const float DefaultHorizontalPartyCenter = 0f;
        public const float VerticalPartyCenter = -1.5f;
        public const float PartyPlacementCorner = 4f;
        public const float LeftBattleAreaCorner = -20f;
        public const float RightBattleAreaCorner = 20f;

        public const string PathToBehaviourTreeEditorUSS = "Assets/EditorExpansions/BehaviourTreeExpansion/UIBuilder/BehaviourTreeEditor.uss";
        public const string PathToBehaviourTreeEditorUXML = "Assets/EditorExpansions/BehaviourTreeExpansion/UIBuilder/BehaviourTreeEditor.uxml";
        public const string PathToBehaviourNodeUXML = "Assets/EditorExpansions/BehaviourTreeExpansion/UIBuilder/BehaviourNodeView.uxml";

        public const string PathToAdventurePartyMemberPrefab = "Prefabs/Units/AdventurePartyMembers";
        public const string PathToBattlePartyMemberPrefabs = "Prefabs/Units/BattlePartyMembers";
        public const string PathToProjectilePrefab = "Prefabs/Projectiles/Projectile";
        public const string PathToBehaviourTrees = "Data/Behaviour";
        
        public const string BaseAttackName = "Attack_Normal";
        public const string VerticalAttackName = "Attack_Air";
        public const string IdleName = "Idle";
        public const string MoveName = "Move";
        public const string TakeDamageInName = "Take_Damage_In";
        public const string TakeDamageOutName = "Take_Damage_Out";
        public const string DeathName = "Death";
        public const string DeathLoopName = "Death_Loop";
    }
}
