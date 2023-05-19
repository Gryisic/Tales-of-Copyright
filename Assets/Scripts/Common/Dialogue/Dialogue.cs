using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Ink.Runtime;

namespace Common.Dialogue
{
    public class Dialogue : IDisposable
    {
        public event Action<string> NamePrinted;
        public event Action<string> LetterPrinted;
        public event Action<bool> SentencePrinting;
        public event Action DialogueEnded;
        
        private CancellationTokenSource _monologueToken = new CancellationTokenSource();

        private bool _canTypeNextSentence = true;
        private bool _canTypeSentenceAsync = true;
        private bool _isSentenceFinished = false;

        public void Initiate(Story story) 
        {
            TypeMonologueAsync(story, _monologueToken.Token).Forget();
        }

        public void Dispose() 
        {
            _monologueToken.Dispose();
        }

        public void NextSentence() 
        {
            if (_isSentenceFinished == false)
                _canTypeSentenceAsync = false;
            else
                _canTypeNextSentence = true;
        }

        private async UniTask TypeMonologueAsync(Story story, CancellationToken token = default) 
        {
            while (token.IsCancellationRequested == false && story.canContinue)
            {
                _canTypeNextSentence = false;

                var typeSentenceTask = TypeSentenceAsync(story.Continue(), token);
                var awaitPermissionToType = UniTask.WaitUntil(() => _canTypeNextSentence, cancellationToken: token);

                await UniTask.WhenAny(AwaitCancellation(token), UniTask.WhenAll(typeSentenceTask, awaitPermissionToType));
            }
            
            DialogueEnded?.Invoke();
        }

        private async UniTask TypeSentenceAsync(string sentence, CancellationToken token = default) 
        {
            string typedSentence = "";

            _canTypeSentenceAsync = true;
            _isSentenceFinished = false;

            SentencePrinting?.Invoke(true);

            foreach (var letter in sentence.ToCharArray())
            {
                if (token.IsCancellationRequested)
                    return;

                if (_canTypeSentenceAsync == false)
                {
                    typedSentence = sentence;

                    LetterPrinted?.Invoke(typedSentence);

                    break;
                }

                typedSentence += letter;

                await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);

                LetterPrinted?.Invoke(typedSentence);
            }

            SentencePrinting?.Invoke(false);
            _isSentenceFinished = true;
        }

        private async UniTask AwaitCancellation(CancellationToken token = default) => 
            await UniTask.WaitUntil(() => token.IsCancellationRequested, cancellationToken: token);
    }
}