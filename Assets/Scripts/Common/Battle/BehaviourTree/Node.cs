using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Battle.BehaviourTree
{
    public abstract class Node : ScriptableObject
    {
        [TextArea] [SerializeField] protected string description;
        
        [HideInInspector] [SerializeField] protected string guid;
        [HideInInspector] [SerializeField] protected Vector2 position;
        
        protected Blackboard blackboard;
        protected IUnitData unitData;
        protected bool isStarted;
        
        public Enums.BehaviourNodeState State { get; private set; } = Enums.BehaviourNodeState.Running;

        public string Description => description;
        public string GUID => guid;
        public Vector2 Position => position;
        public Blackboard Blackboard => blackboard;
        public IUnitData UnitData => unitData;
        public bool IsStarted => isStarted;

        public void SetGUID(string guid) => this.guid = guid;

        public void SetPosition(Vector2 position) => this.position = position;

        public void SetBlackboard(Blackboard blackboard) => this.blackboard = blackboard;

        public void SetUnitData(IUnitData unitData) => this.unitData = unitData;
        
        public Enums.BehaviourNodeState UpdateCurrentState()
        {
            if (isStarted == false)
            {
                Start();

                isStarted = true;
            }

            State = Update();
            
            if (State != Enums.BehaviourNodeState.Running)
            {
                Stop();

                isStarted = false;
            }

            return State;
        }

        public virtual Node Clone() => Instantiate(this);
        
        protected abstract void Start();
        
        protected abstract void Stop();

        protected abstract Enums.BehaviourNodeState Update();
    }
}