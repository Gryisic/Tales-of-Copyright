using System;
using UnityEngine;

namespace Common.Models.Units
{
    [Serializable]
    public class SoundsContainer
    {
        [SerializeField] private AudioClip[] _hit;
        [SerializeField] private AudioClip[] _takeHit;
        [SerializeField] private AudioClip[] _death;

        public AudioClip[] Hit => _hit;

        public AudioClip[] TakeHit => _takeHit;

        public AudioClip[] Death => _death;
    }
}