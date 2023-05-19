using Common.Models.Units;
using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IEnemyFactory : IUnitFactory
    {
        void Create(Enemy prefab, Vector2 at, out Enemy unit);
    }
}