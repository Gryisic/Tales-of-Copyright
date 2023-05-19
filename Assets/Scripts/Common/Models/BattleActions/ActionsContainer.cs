using System;
using System.Collections.Generic;
using System.Linq;
using Common.Battle;
using Common.Models.Units;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.BattleActions
{
    [Serializable]
    public class ActionsContainer : IDisposable
    {
        [SerializeField] private ActionTemplate[] _templates;

        private List<Action> _actions = new List<Action>();

        private ProjectilePool _projectilePool;

        public IReadOnlyList<Action> Actions => _actions;

        private Unit _unit;

        public void Initialize(Unit unit, ProjectilePool projectilePool)
        {
            _unit = unit;
            _projectilePool = projectilePool;
            
            foreach (var template in _templates)
            {
                Action action = DefineType(template);
                
                _actions.Add(action);

                if (action is IRangeAction rangeAction)
                    rangeAction.RequestProjectile += _projectilePool.Get;
            }
        }

        public void Dispose()
        {
            foreach (var action in _actions)
            {
                if (action is IRangeAction rangeAction)
                    rangeAction.RequestProjectile -= _projectilePool.Get;
            }
        }

        public Action GetAction(string name) => _actions.First(a => a.Name == name);

        private Action DefineType(ActionTemplate template)
        {
            switch (template.ActionType)
            {
                case Enums.ActionType.Melee:
                    return new MeleeAction(template, _unit);

                case Enums.ActionType.Projectile:
                    return new ProjectileAction(template, _unit);
                
                case Enums.ActionType.Item:
                    return null;
                
                default:
                    throw new ArgumentOutOfRangeException($"{template.ActionType} isn't defined");
            }
        }
    }
}