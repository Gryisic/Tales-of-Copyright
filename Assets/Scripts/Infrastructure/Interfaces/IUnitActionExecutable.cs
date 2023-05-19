using System;

namespace Infrastructure.Interfaces
{
    public interface IUnitActionExecutable
    {
        event Action ActionExecuted;
        event Action ActionCancelled;
    }
}