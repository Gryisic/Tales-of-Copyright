using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _battleMusic;
        [SerializeField] private AudioClip _adventureMusic;

        private void Awake()
        {
            if (_source == null)
                _source = GetComponent<AudioSource>();
        }

        public void ChangeToBattleMusic()
        {
            _source.clip = _battleMusic;
            _source.Play();
        }
        
        public void ChangeToAdventureMusic()
        {
            _source.clip = _adventureMusic;
            _source.PlayDelayed(0.8f);
        }

        public async UniTask ChangeToBattleMusicAsync(CancellationToken cancellationToken) => await ChangeClipAsync(_battleMusic, cancellationToken);
        
        public async UniTask ChangeToAdventureMusicAsync(CancellationToken cancellationToken) => await ChangeClipAsync(_adventureMusic, cancellationToken);
        
        public async UniTask ChangeClipAsync(AudioClip clip, CancellationToken cancellationToken)
        {
            float timer = 0;
            float volume = _source.volume;

            while (timer < 0.4f)
            {
                _source.volume = Mathf.Lerp(_source.volume, 0, Time.fixedUnscaledDeltaTime * 2);
                
                await UniTask.Delay(TimeSpan.FromSeconds(Time.fixedUnscaledDeltaTime), ignoreTimeScale: true, cancellationToken: cancellationToken);

                timer += Time.fixedUnscaledDeltaTime;
            }
            
            _source.clip = clip;
            _source.volume = volume;
            
            _source.Play();
        }
    }
}