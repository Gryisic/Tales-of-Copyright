using System;
using Common.Models.BattleActions;

namespace Infrastructure.Interfaces
{
    public interface IRangeAction
    {
        event Func<Projectile> RequestProjectile;
    }
}