using System.Collections.Generic;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.BattleActions
{
    public class MeleeAction : Action
    {
        private readonly Collider2D _hitBox;
        private readonly IUnitData _unitData;
        
        public MeleeAction(ActionTemplate template, IUnitData unitData) : base(template)
        {
            _hitBox = unitData.HitBox;
            _unitData = unitData;
        }

        public override void Execute()
        {
            base.Execute();
            
            List<Collider2D> colliders = new List<Collider2D>();
            ContactFilter2D filter2D = new ContactFilter2D();
            
            filter2D.useTriggers = true;

            int collidersCount = Physics2D.OverlapCollider(_hitBox, filter2D, colliders);

            for (int i = 0; i < collidersCount; i++)
            {
                if (colliders[i].TryGetComponent(out IDamagable damagable) == false) 
                    continue;
                
                if (damagable.GetType() != _unitData.Type)
                    damagable.TakeDamage(_unitData);
            }
        }
    }
}