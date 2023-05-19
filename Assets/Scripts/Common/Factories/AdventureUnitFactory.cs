using Common.Models.Units;
using Infrastructure.Utils;
using UnityEngine;

namespace Common.Factories
{
    public class AdventureUnitFactory
    {
        private AdventureUnit _prefab;
        
        public void Load(Enums.PartyMemberType partyMemberType) => _prefab = Resources.Load<AdventureUnit>($"{Constants.PathToAdventurePartyMemberPrefab}/{partyMemberType}");

        public void Create(Vector2 at, out AdventureUnit unit) => unit = GameObject.Instantiate(_prefab, at, Quaternion.identity);
    }
}