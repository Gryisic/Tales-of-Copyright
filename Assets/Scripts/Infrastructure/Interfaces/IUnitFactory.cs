using Common.Models.Units;
using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IUnitFactory
    {
        public void Create<T>(T prefab, Vector2 at, out T unit) where T: Unit;
    }
}