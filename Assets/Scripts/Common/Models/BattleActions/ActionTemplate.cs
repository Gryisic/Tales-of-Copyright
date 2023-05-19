using Infrastructure.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common.Models.BattleActions
{
    [CreateAssetMenu(menuName = "Battle / Actions / Action", fileName = "Action")]
    public class ActionTemplate : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private AnimationClip _animation;
        [SerializeField] private int _energyCost;
        [SerializeField] private float _executionDistance;
        [FormerlySerializedAs("_targetType")] [SerializeField] private Enums.ActionTargetType actionTargetType;
        [SerializeField] private Enums.ActionType _actionType;
        [SerializeField] private bool _isSkill = true;

        [SerializeField] private ProjectileTemplate _projectileTemplate;

        public string Name => _name == string.Empty ? _animation.name : _name;

        public AnimationClip Animation => _animation;
        public int EnergyCost => _energyCost;
        public float ExecutionDistance => _executionDistance;
        public Enums.ActionTargetType ActionTargetType => actionTargetType;
        public Enums.ActionType ActionType => _actionType;
        public bool IsSkill => _isSkill;
        
        public ProjectileTemplate ProjectileTemplate => _projectileTemplate;
    }
}