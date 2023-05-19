using System;
using System.Collections.Generic;
using Common.Models.Sugar;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Units
{
    [RequireComponent(typeof(Animator))]
    public class UnitAnimator : MonoBehaviour
    {
        public event Action<Vector2> ApplyForce;
        public event Action ExecuteAction;
        
        private readonly Dictionary<string, int> _animationHashMap = new Dictionary<string, int>();

        private Animator _animator;
        private Animation _animation;
        private AnimationClip _activeClip;

        public float DurationOfCurrentAnimation => _activeClip == null ? 
            _animator.GetCurrentAnimatorClipInfo(0)[0].clip.length : 
            _activeClip.length;

        public void Play(AnimationClip clip, bool isLooped = false, int numberOfRepeats = 1)
        {
            _activeClip = clip;
            _animator.Play(clip.name);
        }

        public void Play(string name, bool isLooped = false, int numberOfRepeats = 1)
        {
            if(_animator == null)
                _animator = GetComponent<Animator>();

            _activeClip = null;
            
            if (_animationHashMap.ContainsKey(name) == false)
                _animationHashMap.Add(name, Animator.StringToHash(name));

            _animator.Play(_animationHashMap[name]);
        }

        public void Pause() => _animator.speed = 0;

        public void Continue() => _animator.speed = 1;

        public void RaiseActionExecutionEvent() => ExecuteAction?.Invoke();
        
        public void RaiseApplyForceEvent(ApplyForce force) => ApplyForce?.Invoke(force.Force);
    }
}