using Common.Models.Units;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.Factories
{
    public abstract class UnitFactory : IUnitFactory
    {
        public void Create<T>(T prefab, Vector2 at, out T unit) where T: Unit => 
            unit = GameObject.Instantiate(prefab, at, Quaternion.identity);
    }
}