using Common.Models.BattleActions;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Factories
{
    public class ProjectileFactory : IProjectileFactory
    {
        private Projectile _projectile;
        
        public void Load() => _projectile = Resources.Load<Projectile>(Constants.PathToProjectilePrefab);

        public void Create(out Projectile projectile)
        {
            projectile = GameObject.Instantiate(_projectile, _projectile.transform.position, Quaternion.identity);
            projectile.gameObject.SetActive(false);
        }
    }
}