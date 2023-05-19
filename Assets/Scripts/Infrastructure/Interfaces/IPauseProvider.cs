using System;

namespace Infrastructure.Interfaces
{
    public interface IPauseProvider
    {
        public event Action RequestPause;
        public event Action EndPause;
    }
}