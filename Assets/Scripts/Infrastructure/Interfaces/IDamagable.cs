using System;

namespace Infrastructure.Interfaces
{
    public interface IDamagable
    {
        event Action<IDamagable, int> DamageTaken; 
        
        bool IsAlive { get; }

        void TakeDamage(IUnitData from);
    }
}