using Infrastructure.Interfaces;
using UnityEngine;

namespace Infrastructure.Utils.Calculators
{
    public static class DamageCalculator
    {
        public static void Calculate(IUnitData from, IUnitData to, out int damage, out Vector2 knockback)
        {
            int attack = from.Stats.GetStat(Enums.StatType.Attack).Value;
            int defence = to.Stats.GetStat(Enums.StatType.Defence).Value;
            
            damage = Mathf.Clamp(attack - defence, 1, 999);

            Vector2 direction = (to.Rigidbody2D.position - from.Rigidbody2D.position).normalized;
            int maxHealth = to.Stats.GetStat(Enums.StatType.MaxHealth).Value;
            Enums.KnockbackForceType forceType = ForceType(maxHealth, damage);

            knockback = Knockback(forceType);
            knockback.x *= direction.x;
        }

        private static Vector2 Knockback(Enums.KnockbackForceType forceType)
        {
            switch (forceType)
            {
                case Enums.KnockbackForceType.Light:
                    return new Vector2(0.2f, 0f);
                
                case Enums.KnockbackForceType.Medium:
                    return new Vector2(1f, 0f);
                
                case Enums.KnockbackForceType.Heavy:
                    return new Vector2(4f, 1f);
            }
            
            return Vector2.zero;
        }

        private static Enums.KnockbackForceType ForceType(int maxHealth, int damage)
        {
            int percent = damage * 100 / maxHealth;

            if (percent < 20)
                return Enums.KnockbackForceType.Light;
            
            if (percent < 45)
                return Enums.KnockbackForceType.Medium;
            
            return Enums.KnockbackForceType.Heavy;
        }
    }
}