using Common.Models.BattleActions;
using Common.Models.StatSystem;
using UnityEngine;

namespace Common.Models.Units
{
    public abstract class UnitConfig : ScriptableObject
    {
        [SerializeField] private StatsTemplate _statsTemplate;
        [SerializeField] private ActionsContainer _actionsContainer;

        public StatsTemplate StatsTemplate => _statsTemplate;
        public ActionsContainer ActionsContainer => _actionsContainer;

        public UnitConfig Clone() => Instantiate(this);
    }
}