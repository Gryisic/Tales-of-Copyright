using System;
using Common.Dialogue;
using static Infrastructure.Utils.Enums;

namespace Core.GameModes
{
    public class GameModeArgs : EventArgs
    {
        public GameModeType NewMode { get; }
        public GameModeType CurrentMode { get; }
        public SceneType NewScene { get; }

        public DialogueProvider DialogueProvider { get; }

        public GameModeArgs(GameModeType newMode)
        {
            NewMode = newMode;
        }
        
        public GameModeArgs(GameModeType newMode, GameModeType postChangeMode, SceneType newScene)
        {
            NewMode = newMode;
            CurrentMode = postChangeMode;
            NewScene = newScene;
        }

        public GameModeArgs(GameModeType newMode, GameModeType currentMode, DialogueProvider dialogueProvider)
        {
            NewMode = newMode;
            CurrentMode = currentMode;
            DialogueProvider = dialogueProvider;
        }
    }
}