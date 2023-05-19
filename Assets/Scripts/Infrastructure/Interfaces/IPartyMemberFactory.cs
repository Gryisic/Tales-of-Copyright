using System.Collections.Generic;
using Common.Models.Units;
using Infrastructure.Utils;
using UnityEngine;

namespace Infrastructure.Interfaces
{
    public interface IPartyMemberFactory : IUnitFactory
    {
        void Load(IReadOnlyList<Enums.PartyMemberType> typesToLoad);
        void Create(Enums.PartyMemberType type, Vector2 at, out PartyMember partyMember);
    }
}