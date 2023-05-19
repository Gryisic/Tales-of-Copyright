using System.Collections.Generic;
using Common.Factories;
using Common.Models.BattleActions;
using UnityEngine;

namespace Common.Battle
{
    public class ProjectilePool
    {
        private List<Projectile> _projectiles = new List<Projectile>();
        private ProjectileFactory _projectileFactory = new ProjectileFactory();

        public ProjectilePool()
        {
            Initialize();
        }
        
        public Projectile Get()
        {
            if (_projectiles.Count <= 0)
                CreateProjectile();
            
            Projectile projectile = _projectiles[0];

            _projectiles.Remove(projectile);
            
            return projectile;
        }

        public void Return(Projectile projectile) 
        {
            projectile.ProjectileCollided -= Return;
            
            _projectiles.Add(projectile);
        }
        
        private void Initialize()
        {
            _projectileFactory.Load();
            
            for (int i = 0; i <= 10; i++)
                CreateProjectile();
        }

        private void CreateProjectile()
        {
            _projectileFactory.Create(out Projectile newProjectile);

            newProjectile.ProjectileCollided += Return;
                    
            _projectiles.Add(newProjectile);
        }
    }
}