using System.Collections.Generic;
using Common.Models.Units;
using Infrastructure.Interfaces;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Factories
{
    public class PartyMemberFactory : UnitFactory, IPartyMemberFactory
    {
        private Dictionary<Enums.PartyMemberType, PartyMember> _prefabs = new Dictionary<Enums.PartyMemberType, PartyMember>();
        
        public void Load(IReadOnlyList<Enums.PartyMemberType> typesToLoad)
        {
            foreach (var type in typesToLoad)
            {
                PartyMember prefab = Resources.Load<PartyMember>($"{Constants.PathToBattlePartyMemberPrefabs}/{type}");
                
                _prefabs.Add(type, prefab);
            }
        }

        public void Create(Enums.PartyMemberType type, Vector2 at, out PartyMember partyMember) => 
            Create(_prefabs[type], at, out partyMember);
    }
}