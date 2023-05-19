using System.Collections.Generic;
using System.Threading;
using Common.Models.Units;
using Cysharp.Threading.Tasks;
using Infrastructure.Extensions;
using Infrastructure.Utils;
using UnityEngine;
using PartyMemberType = Infrastructure.Utils.Enums.PartyMemberType;

namespace Common.Models.Party
{
    public class PartyPlacement
    {
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();

        private PartyFormation[] _formations;
        private PartyFormation _currentFormation;

        private Vector2 _partyPosition;

        public Dictionary<PartyMemberType, Vector2> UnitPlacementMap { get; private set; } =
            new Dictionary<PartyMemberType, Vector2>();

        public PartyPlacement(IReadOnlyList<PartyMemberType> activeMembers, PartyFormationsTemplate formations)
        {
            _formations = new PartyFormation[]
            {
                new PartyFormation(formations.First),
                new PartyFormation(formations.Second),
                new PartyFormation(formations.Third)
            };

            _currentFormation = _formations[0];
            
            SetPlacementMap(activeMembers);
        }
        
        public void SetInitialPartyPosition(Enums.PartyPlacementSide side)
        {
            _partyPosition = this.GetInitialPosition(side);

            Dictionary<PartyMemberType, Vector2> temporary = new Dictionary<PartyMemberType, Vector2>(UnitPlacementMap);
            
            foreach (var unitPlacement in temporary)
            {
                Vector2 newPosition = new Vector2(unitPlacement.Value.x + _partyPosition.x, Constants.VerticalPartyCenter);

                UpdatePartyMemberPosition(unitPlacement.Key, newPosition);
            }
        }

        public bool TryGetPartyMemberPosition(PartyMemberType member, out Vector2 position)
        {
            if (UnitPlacementMap.TryGetValue(member, out position) == false) 
                return false;
            
            position.x += _partyPosition.x;
            return true;

        }

        public void UpdatePartyMemberPosition(PartyMemberType member, Vector2 position)
        {
            if (UnitPlacementMap.ContainsKey(member))
                UnitPlacementMap[member] = position;
        }

        public void UpdatePartyPosition(Transform relativelyTo) => UpdatePartyPositionAsync(relativelyTo).Forget();

        public void StopUpdatingPosition() => _tokenSource.Cancel();

        private void SetPlacementMap(IReadOnlyList<PartyMemberType> activeMembers)
        {
            for (int i = 0; i < activeMembers.Count; i++)
                UnitPlacementMap.Add(activeMembers[i], _currentFormation.Positions[i]);
        }

        private async UniTask UpdatePartyPositionAsync(Transform relativelyTo)
        {
            while (_tokenSource.IsCancellationRequested == false)
            {
                await UniTask.WaitForFixedUpdate();
                
                float rightCorner = _partyPosition.x + Constants.PartyPlacementCorner;
                float leftCorner = _partyPosition.x - Constants.PartyPlacementCorner;
                float newPosition = relativelyTo.position.x;

                if (newPosition > leftCorner && newPosition < rightCorner)
                    continue;

                if (newPosition < leftCorner)
                {
                    leftCorner = newPosition < Constants.LeftBattleAreaCorner 
                        ? Constants.LeftBattleAreaCorner 
                        : newPosition;
                }
                else if (newPosition > rightCorner)
                {
                    rightCorner = newPosition > Constants.RightBattleAreaCorner 
                        ? Constants.RightBattleAreaCorner 
                        : newPosition;
                }

                _partyPosition.x = (leftCorner + rightCorner) / 2;
            }
            
            _tokenSource = _tokenSource.CancelAndRefresh();
        }
    }
}