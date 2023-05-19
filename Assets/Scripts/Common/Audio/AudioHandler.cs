using UnityEngine;
using UnityEngine.Audio;

namespace Common.Audio
{
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private BackgroundMusic _backgroundMusic;

        public BackgroundMusic BackgroundMusic => _backgroundMusic;
    }
}