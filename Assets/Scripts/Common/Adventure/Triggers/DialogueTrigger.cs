using System;
using Common.Dialogue;
using Infrastructure.Interfaces;
using UnityEngine;

namespace Common.Adventure.Triggers
{
    public class DialogueTrigger : Trigger, IInteractable
    {
        public event Action<DialogueProvider> DialogueInitiated; 

        [SerializeField] private DialogueProvider _provider;
        
        public void Interact()
        {
            Execute();
        }

        public override void Execute()
        {
            DialogueInitiated?.Invoke(_provider);
        }
    }
}