namespace Infrastructure.Utils
{
    public static class Enums 
    {
        public enum GameModeType 
        {
            GameInit,
            SceneSwitch,
            Adventure,
            Battle,
            Dialogue
        }

        public enum SceneType 
        {
            Default,
            Battle,
            Ruins
        }

        public enum BehaviourNodeState
        {
            Running,
            Success,
            Failure
        }

        public enum ActionType
        {
            Melee,
            Projectile,
            Item
        }
        
        public enum UnitSoundType
        {
            Hit,
            TakeHit,
            Death
        }

        public enum InitialProjectilePosition
        {
            OnThisUnit,
            AboveThisUnit,
            OneTargetUnit,
            AboveTargetUnit
        }

        public enum TargetSelectionStrategy
        {
            Nearest,
            NextInOrder
        }
        
        public enum TargetType
        {
            SameAsUnit,
            Opposite
        }
        
        public enum ActionTargetType
        {
            Self,
            Enemy,
            SelfArea,
            EnemyArea,
            SelfAll,
            EnemyAll
        }

        public enum PartyPlacementSide
        {
            Center,
            Left,
            Right
        }

        public enum PartyMemberType
        {
            Swordsman,
            MartialArtist,
            Archer
        }

        public enum BehaviourType
        {
            Default,
            Aggressive,
            Player
        }

        public enum StatType
        {
            MaxHealth,
            Health,
            MaxEnergy,
            Energy,
            Attack,
            Defence,
            Accuracy,
            Agility
        }

        public enum KnockbackForceType
        {
            Light,
            Medium,
            Heavy
        }

        public enum TargetPointerOrientation
        {
            Vertical,
            Horizontal
        }
    }
}
