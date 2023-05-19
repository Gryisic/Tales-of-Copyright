using System;
using System.Collections.Generic;
using Common.Battle;
using Common.Battle.BehaviourTree;
using Common.Battle.TargetSelector;
using Common.Models.BattleActions;
using Common.Models.StatSystem;
using Common.Models.Sugar;
using Common.StateMachines.UnitStateMachine;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using Infrastructure.Utils.Calculators;
using UnityEngine;
using Action = Common.Models.BattleActions.Action;

namespace Common.Models.Units
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Unit : MonoBehaviour, IDamagable, IUnitData, IBehaviourTreeProvider, IDisposable
    {
        [SerializeField] private Collider2D _hitBox;
        [SerializeField] private Behaviour _behaviour;

        public event Action<Unit, int> HealthChanged;
        public event Action<Unit, int> EnergyChanged; 
        public event Action<IDamagable, int> DamageTaken;
        public event Action<Unit> Died;

        protected UnitStateMachine stateMachine;
        protected ActionHandler actionsHandler;

        protected int health;
        protected int energy;

        private UnitPhysic _unitPhysic;

        public DirectionHandler DirectionHandler { get; } = new DirectionHandler();
        public Stats Stats { get; protected set; }
        public TargetSelector TargetSelector { get; private set; }
        public IReadOnlyList<Unit> UnitsInBattle { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public UnitAnimator Animator { get; private set; }
        
        public bool IsAlive { get; private set; } = true;
        public bool IsStaggered { get; private set; }
        public bool IsAwaiting { get; private set; }
        
        public Type Type => GetType();
        public Unit Target => Tree.Blackboard.Target;
        public Collider2D HitBox => _hitBox;
        public BehaviourTree Tree => _behaviour.Tree;
        public ActionHandler ActionHandler => actionsHandler;

        public virtual void Initialize(IReadOnlyList<Unit> unitsInBattle, ProjectilePool projectilePool, TargetSelector targetSelector)
        {
            UnitsInBattle = unitsInBattle;
            TargetSelector = targetSelector;

            Rigidbody2D = GetComponent<Rigidbody2D>();

            Animator = GetComponentInChildren<UnitAnimator>();

            actionsHandler.SetAnimator(Animator);
            
            health = Stats.GetStat(Enums.StatType.Health).Value;
            energy = Stats.GetStat(Enums.StatType.Energy).Value;

            if (Animator == null)
                throw new Exception($"Component {typeof(Animator)} wasn't found");

            stateMachine = new UnitStateMachine(this);
            stateMachine.Start();

            _unitPhysic = new UnitPhysic(Rigidbody2D);
            _unitPhysic.Update();
            
            _behaviour.Initialize(this);

            SubscribeToEvents();
        }

        public virtual void Dispose()
        {
            _unitPhysic.Dispose();
            
            stateMachine.Stop();
            stateMachine.Dispose();

            DeactivateBehaviour();
            UnsubscribeToEvents();
        }

        public void ActivateBehaviour() => _behaviour.Update();

        public void DeactivateBehaviour() => _behaviour.StopUpdating();

        public void ChangeBehaviour(Enums.BehaviourType behaviourType) => _behaviour.Change(behaviourType);

        public void TakeDamage(IUnitData from)
        {
            if (IsAlive == false)
                return;
            
            DamageCalculator.Calculate(from, this, out int damage, out Vector2 knockback);
            
            health -= damage;

            HealthChanged?.Invoke(this, health);
            
            if (health <= 0)
            {
                Death();
                
                return;
            }
            
            DamageTaken?.Invoke(this, damage);

            Knockback(knockback);
        }

        public void Attack()
        {
            string actionName = DirectionHandler.VerticalDirection.y > 0
                ? Constants.VerticalAttackName
                : Constants.BaseAttackName;

            Action action = actionsHandler.Container.GetAction(actionName);
            
            UpdateAction(action);
        }

        public void UpdateAction(string actionName)
        {
            Action action = actionsHandler.Container.GetAction(actionName);
            
            UpdateAction(action);
        }

        public void UpdateAction(Action action) 
        {
            if (energy >= action.EnergyCost)
                _behaviour.Tree.Blackboard.SetAction(action);
        }
        
        public void RegisterAction(Action action) 
        {
            if (energy >= action.EnergyCost)
                actionsHandler.RegisterAction(action);
        }

        public void UpdateCurrentActionState() => actionsHandler.UpdateCurrentActionState();

        public void ClearActions() => actionsHandler.ClearActions();

        public void StartMoving(Vector2 direction) => DirectionHandler.Update(direction);

        public void StopMoving() => DirectionHandler.Update(Vector2.zero);

        public void UpdateTarget(Unit target) => _behaviour.Tree.Blackboard.SetTarget(target);

        public void UpdateStaggerState(bool isStaggered) => IsStaggered = isStaggered;

        private void SubscribeToEvents()
        {
            Animator.ApplyForce += ApplyForce;
            
            foreach (var action in actionsHandler.Container.Actions)
            {
                action.ExecutionRequested += RegisterAction;
                action.EnergyUsed += ConsumeEnergy;
            }
        }

        private void UnsubscribeToEvents()
        {
            Animator.ApplyForce -= ApplyForce;
            
            foreach (var action in actionsHandler.Container.Actions)
            {
                action.ExecutionRequested -= RegisterAction;
                action.EnergyUsed -= ConsumeEnergy;
            }
        }
        
        private void ConsumeEnergy(int energyCost) 
        {
            energy = energy - energyCost <= 0 ? 0 : energy - energyCost;
            
            EnergyChanged?.Invoke(this, energy);
        }
        
        private void Death()
        {
            health = 0;
            IsAlive = false;

            Died?.Invoke(this);
        }

        private void Knockback(Vector2 force)
        {
            Rigidbody2D.velocity = Vector2.zero;
            Rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }
        
        private void ApplyForce(Vector2 force)
        {
            float horizontalDirection =
                _behaviour.Tree.Blackboard.Target.transform.position.x > transform.position.x ? 1 : -1;
                
            force.x *= horizontalDirection >= 0 ? 1 : -1;
            
            Rigidbody2D.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
