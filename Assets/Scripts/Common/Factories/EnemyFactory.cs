using Common.Models.Units;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.Factories
{
    public class EnemyFactory : UnitFactory, IEnemyFactory
    {
        public void Create(Enemy prefab, Vector2 at, out Enemy unit) => base.Create(prefab, at, out unit);
    }
}