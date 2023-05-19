using System.Collections.Generic;
using System.Linq;
using Common.Models.Units;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.UI.Battle
{
    public class PartyStatus : UIElement
    {
        [SerializeField] private PartyMemberStatus[] _partyMemberStatuses;
        [SerializeField] private CanvasGroup _canvasGroup;

        public override void Activate()
        {
            animator.FadeIn(_canvasGroup, Constants.BattleInitiationTime);
        }

        public override void Deactivate()
        {
            animator.FadeIn(_canvasGroup, Constants.BattleInitiationTime);
        }

        public void Initialize(IReadOnlyList<PartyMember> partyMembers)
        {
            for (int i = 0; i < partyMembers.Count; i++)
            {
                PartyMember partyMember = partyMembers[i];
                int maxHealth = partyMember.Stats.GetStat(Enums.StatType.MaxHealth).Value;
                int health = partyMember.Stats.GetStat(Enums.StatType.Health).Value;
                int maxEnergy = partyMember.Stats.GetStat(Enums.StatType.MaxEnergy).Value;
                int energy = partyMember.Stats.GetStat(Enums.StatType.Energy).Value;
                
                _partyMemberStatuses[i].SetInitialData(partyMember.Type, maxHealth, health, maxEnergy, energy);
                _partyMemberStatuses[i].Activate();
            }
        }

        public void UpdateHealth(Unit unit, int health)
        {
            PartyMemberStatus status = ConcreteStatus(unit);
            
            status.UpdateHealth(health);
        }
        
        public void UpdateEnergy(Unit unit, int energy)
        {
            PartyMemberStatus status = ConcreteStatus(unit);
            
            status.UpdateEnergy(energy);
        }

        public void ShakeStatus(Unit unit)
        {
            PartyMemberStatus status = ConcreteStatus(unit);
            
            status.Shake();
        }

        private PartyMemberStatus ConcreteStatus(Unit unit)
        {
            PartyMember partyMember = unit as PartyMember;
            
            if (partyMember == null)
                return null;

            return _partyMemberStatuses.FirstOrDefault(status => status.PartyMemberType == partyMember.Type);
        }
    }
}