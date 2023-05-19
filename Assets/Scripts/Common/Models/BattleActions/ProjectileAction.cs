using System;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.Models.BattleActions
{
    public class ProjectileAction : Action, IRangeAction
    {
        public event Func<Projectile> RequestProjectile;

        private IUnitData _unitData;
        private ProjectileTemplate _projectileTemplate;
        
        public ProjectileAction(ActionTemplate template, IUnitData unitData) : base(template)
        {
            _projectileTemplate = template.ProjectileTemplate;

            _unitData = unitData;
        }

        public override void Execute()
        {
            Projectile projectile = RequestProjectile?.Invoke();

            Vector2 position = _unitData.HitBox.transform.position;

            projectile.SetData(_unitData, _projectileTemplate);
            
            Vector2 direction = (_unitData.Target.transform.position - _unitData.Rigidbody2D.transform.position).normalized;
            Rotate(direction, projectile.transform);
            
            projectile.Launch(position, direction);
        }

        private void Rotate(Vector2 direction, Transform rotate)
        {
            float rotationAngle = direction.x >= 0 ? 0f : 180f;

            rotate.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
        }
    }
}