using System;
using UnityEngine;

namespace Common.Dialogue
{
    [Serializable]
    public class DialogueProvider
    {
        [SerializeField] private TextAsset _dialogue;

        public TextAsset Dialogue => _dialogue;
    }
}