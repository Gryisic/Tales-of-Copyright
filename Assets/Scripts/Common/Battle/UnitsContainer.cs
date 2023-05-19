using System;
using System.Collections.Generic;
using Common.Models.Units;

namespace Common.Battle
{
    public class UnitsContainer
    {
        public event Action<IReadOnlyList<Unit>> ContainerModified;
        public event Action PartyMembersDead;
        public event Action EnemiesDead;
        
        public List<PartyMember> PartyMembers { get; } = new List<PartyMember>();
        public List<Enemy> Enemies { get; } = new List<Enemy>();

        public List<Unit> All { get; } = new List<Unit>();

        public void AddUnit(Unit unit)
        {
            switch (unit)
            {
                case PartyMember partyMember when PartyMembers.Contains(partyMember) == false:
                    PartyMembers.Add(partyMember);
                    All.Add(partyMember);
                    break;
                
                case Enemy enemy when Enemies.Contains(enemy) == false:
                    Enemies.Add(enemy);
                    All.Add(enemy);
                    break;
            }
            
            ContainerModified?.Invoke(All);
        }

        public void Remove(Unit unit)
        {
            switch (unit)
            {
                case PartyMember partyMember when PartyMembers.Contains(partyMember):
                    PartyMembers.Remove(partyMember);
                    All.Remove(partyMember);
                    
                    partyMember.Dispose();
                    
                    if (PartyMembers.Count <= 0)
                        PartyMembersDead?.Invoke();
                    break;
                
                case Enemy enemy when Enemies.Contains(enemy):
                    Enemies.Remove(enemy);
                    All.Remove(enemy);
                    
                    enemy.Dispose();
                    
                    if (Enemies.Count <= 0)
                        EnemiesDead?.Invoke();
                    break;
            }
            
            ContainerModified?.Invoke(All);
        }
    }
}