using System.Collections.Generic;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.StatSystem
{
    [CreateAssetMenu(menuName = "Data / Stats / StatsTemplate", fileName = "Stats")]
    public class StatsTemplate : ScriptableObject
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _maxEnergy;
        [SerializeField] private int _attack;
        [SerializeField] private int _defence;
        [SerializeField] private int _accuracy;
        [SerializeField] private int _agility;

        public IReadOnlyDictionary<Enums.StatType, int> GetValues()
        {
            return new Dictionary<Enums.StatType, int>()
            {
                { Enums.StatType.MaxHealth, _maxHealth },
                { Enums.StatType.Health, _maxHealth },
                { Enums.StatType.MaxEnergy, _maxEnergy },
                { Enums.StatType.Energy, _maxEnergy },
                { Enums.StatType.Attack, _attack },
                { Enums.StatType.Defence, _defence },
                { Enums.StatType.Accuracy, _accuracy },
                { Enums.StatType.Agility, _agility }
            };
        } 
    }
}