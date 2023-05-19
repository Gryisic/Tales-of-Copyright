using System.Collections.Generic;
using Common.Models.Party;
using Common.Models.Units;
using Infrastructure.Utils;

namespace Common.Data
{
    public class PartyData
    {
        public PartyPlacement Placement { get; private set; }

        public List<Enums.PartyMemberType> Party { get; private set; } = new List<Enums.PartyMemberType>();
        public List<Enums.PartyMemberType> ActiveMembers { get; private set; } = new List<Enums.PartyMemberType>();
        public List<Enums.PartyMemberType> BackupMembers { get; private set; } = new List<Enums.PartyMemberType>();
        
        public PartyMember PlayerUnit { get; private set; }

        public PartyData(PartyFormationsTemplate formationsTemplate)
        {
            ActiveMembers.Add(Enums.PartyMemberType.Swordsman);
            ActiveMembers.Add(Enums.PartyMemberType.MartialArtist);
            ActiveMembers.Add(Enums.PartyMemberType.Archer);
            
            Placement = new PartyPlacement(ActiveMembers, formationsTemplate);
        }

        public void UpdatePlayerUnit(PartyMember member) => PlayerUnit = member;
    }
}