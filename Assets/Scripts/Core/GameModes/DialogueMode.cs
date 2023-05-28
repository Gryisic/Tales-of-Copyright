using System;
using Common.Dialogue;
using Common.UI.Dialogue;
using Core.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using Ink.Runtime;
using UnityEngine.InputSystem;
using PlayerInput = Core.Input.PlayerInput;

namespace Core.GameModes
{
    public class DialogueMode : IGameMode, IDeactivatable, IDisposable
    {
        public event Action<GameModeArgs> Finished;

        private Dialogue _dialogue = new Dialogue();

        private GameContext _gameContext;
        private UIContext _uiContext;
        private DialogueWindow _dialogueWindow;
        
        private PlayerInput _input;
        
        private Enums.GameModeType _previousGameMode;

        public DialogueMode(GameContext gameContext)
        {
            _gameContext = gameContext;
            _input = _gameContext.Resolve<PlayerInput>();
        }
        
        public void Activate(GameModeArgs args)
        {
            _previousGameMode = args.CurrentMode;

            SceneContext sceneContext = _gameContext.Resolve<SceneContext>();
            _uiContext = sceneContext.Resolve<UIContext>();
            _dialogueWindow = _uiContext.Resolve<DialogueWindow>();
            
            SubscribeToEvents();
            AttachInput();
            InitiateDialogue(args.DialogueProvider);
        }

        public void Deactivate()
        {
            DeAttachInput();
            UnsubscribeToEvents();
        }
        
        public void Dispose()
        {
            _dialogue.Dispose();
        }

        private void InitiateDialogue(DialogueProvider provider)
        {
            string dialogueText = provider.Dialogue.text;
            
            _dialogueWindow.Activate();
            
            _dialogue.Initiate(new Story(dialogueText));
        }
        
        private void MoveToNextSentence(InputAction.CallbackContext obj) => _dialogue.NextSentence();

        private void End() => Finished?.Invoke(new GameModeArgs(_previousGameMode));

        private void AttachInput()
        {
            _input.UI.Click.performed += MoveToNextSentence;

            _input.UI.Enable();
        }

        private void DeAttachInput()
        {
            _input.UI.Disable();
            
            _input.UI.Click.performed -= MoveToNextSentence;
        }
        
        private void SubscribeToEvents()
        {
            _dialogue.LetterPrinted += _dialogueWindow.UpdateSentence;
            _dialogue.DialogueEnded += _dialogueWindow.Deactivate;
            _dialogue.DialogueEnded += End;
        }

        private void UnsubscribeToEvents()
        {
            _dialogue.LetterPrinted -= _dialogueWindow.UpdateSentence;
            _dialogue.DialogueEnded -= _dialogueWindow.Deactivate;
            _dialogue.DialogueEnded -= End;
        }
    }
}