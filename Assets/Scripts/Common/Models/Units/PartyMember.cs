using System.Collections.Generic;
using System.Linq;
using Common.Battle;
using Common.Battle.TargetSelector;
using Common.Models.BattleActions;
using Common.Models.StatSystem;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Units
{
    [RequireComponent(typeof(AudioSource))]
    public class PartyMember : Unit
    {
        public Dictionary<int, Action> ActiveActions { get; private set; } = new Dictionary<int, Action>();
        
        public Enums.PartyMemberType Type { get; private set; }

        [SerializeField] private PartyMemberConfig _config;
        
        private Sounds _sounds;

        public override void Initialize(IReadOnlyList<Unit> unitsInBattle, ProjectilePool projectilePool, TargetSelector targetSelector)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            
            _config = _config.Clone() as PartyMemberConfig;
            
            Type = _config.Type;

            Stats = new Stats(_config.StatsTemplate.GetValues());
            _sounds = new Sounds(audioSource, _config.SoundsContainer);
            
            actionsHandler = new ActionHandler();
            
            actionsHandler.SetContainer(_config.ActionsContainer);
            actionsHandler.Container.Initialize(this, projectilePool);
            
            SetActiveActions();

            base.Initialize(unitsInBattle, projectilePool, targetSelector);
            
            SubscribeToEvents();
        }
        
        public override void Dispose()
        {
            UnsubscribeToEvents();
            
            base.Dispose();
        }

        private void SubscribeToEvents()
        {
            DamageTaken += DamageSound;
            Died += DiedSound;
            
            Animator.ExecuteAction += HitSound;
        }

        private void UnsubscribeToEvents()
        {
            DamageTaken -= DamageSound;
            Died -= DiedSound;
            
            Animator.ExecuteAction -= HitSound;
        }
        
        private void HitSound() => _sounds.Play(Enums.UnitSoundType.Hit);
        
        private void DamageSound(IDamagable damagable, int value) => _sounds.Play(Enums.UnitSoundType.TakeHit);
        
        private void DiedSound(IDamagable damagable) => _sounds.Play(Enums.UnitSoundType.Death);

        private void SetActiveActions()
        {
            IReadOnlyList<Action> actions = actionsHandler.Container.Actions.Where(a => a.IsSkill).ToList();
            
            for (int i = 0; i < actions.Count; i++)
            {
                ActiveActions.Add(i, actions[i]);
            }
        }
    }
}