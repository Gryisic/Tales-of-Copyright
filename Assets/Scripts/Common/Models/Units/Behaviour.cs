using System;
using System.Threading;
using Common.Battle.BehaviourTree;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Units
{
    [Serializable]
    public class Behaviour
    {
        [SerializeField] private BehaviourTree _behaviourTree;

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private BehaviourTree _defaultTree;
        private IUnitData _unitData;

        public BehaviourTree Tree => _behaviourTree;

        public void Initialize(IUnitData unitData)
        {
            _unitData = unitData;
            
            _behaviourTree = _behaviourTree.Clone();
            _behaviourTree.Bind(unitData);

            _defaultTree = _behaviourTree;
        }

        public void Update() => UpdateAsync().Forget();

        public void StopUpdating() 
        {
            _tokenSource.Cancel();
            
            _unitData.DirectionHandler.Update(Vector2.zero);
        }

        public void Change(Enums.BehaviourType behaviourType)
        {
            StopUpdating();

            if (behaviourType == Enums.BehaviourType.Default)
                _behaviourTree = _defaultTree;
            else
                _behaviourTree = Resources.Load<BehaviourTree>($"{Constants.PathToBehaviourTrees}/{behaviourType}").Clone();
            
            _behaviourTree.Bind(_unitData);
            
            Update();
        }

        private async UniTask UpdateAsync()
        {
            while (_tokenSource.IsCancellationRequested == false)
            {
                _behaviourTree.Update();
                
                await UniTask.WaitForFixedUpdate();
            }
            
            _tokenSource = _tokenSource.CancelAndRefresh();
        }
    }
}