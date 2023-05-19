using Infrastructure.Extensions;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Units
{
    public class Sounds
    {
        private readonly AudioSource _source;
        private readonly SoundsContainer _soundsContainer;

        public Sounds(AudioSource source, SoundsContainer soundsContainer)
        {
            _source = source;
            _soundsContainer = soundsContainer;
        }

        public void Play(AudioClip clip)
        {
            if (clip == null)
                return;

            _source.clip = clip;
            _source.Play();
        }

        public void Play(Enums.UnitSoundType soundType)
        {
            AudioClip clip = null;
            
            switch (soundType)
            {
                case Enums.UnitSoundType.Hit:
                    clip = _soundsContainer.Hit.Random();
                    break;
                
                case Enums.UnitSoundType.TakeHit:
                    clip = _soundsContainer.TakeHit.Random();
                    break;
                
                case Enums.UnitSoundType.Death:
                    clip = _soundsContainer.Death.Random();
                    break;
            }
            
            Play(clip);
        }
    }
}