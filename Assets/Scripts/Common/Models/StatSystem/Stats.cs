using System.Collections.Generic;
using Infrastructure.Utils;

namespace Common.Models.StatSystem
{
    public class Stats
    {
        private readonly Dictionary<Enums.StatType, Stat> _stats = new Dictionary<Enums.StatType, Stat>();

        public Stats(IReadOnlyDictionary<Enums.StatType, int> stats)
        {
            foreach (var stat in stats)
                _stats.Add(stat.Key, new Stat(stat.Value));
        }
        
        public Stat GetStat(Enums.StatType type)
        {
            if(_stats.TryGetValue(type, out Stat stat))
                return stat;

            throw new System.ArgumentNullException($"Trying to get '{type}' stat not presented in dictionary");
        }
    }
}