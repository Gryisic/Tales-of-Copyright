using Common.Models.BattleActions;

namespace Infrastructure.Interfaces
{
    public interface IProjectileFactory
    {
        void Load();

        void Create(out Projectile projectile);
    }
}