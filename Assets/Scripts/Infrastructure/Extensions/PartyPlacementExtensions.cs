using System;
using Common.Models.Party;
using Infrastructure.Utils;
using UnityEngine;

namespace Infrastructure.Extensions
{
    public static class PartyPlacementExtensions
    {
        public static Vector2 GetInitialPosition(this PartyPlacement placement, Enums.PartyPlacementSide side)
        {
            switch (side)
            {
                case Enums.PartyPlacementSide.Center:
                    return new Vector2(Constants.DefaultHorizontalPartyCenter, Constants.VerticalPartyCenter);
                
                case Enums.PartyPlacementSide.Left:
                    return new Vector2(Constants.LeftBattleAreaCorner + Constants.PartyPlacementCorner, Constants.VerticalPartyCenter);

                case Enums.PartyPlacementSide.Right:
                    return new Vector2(Constants.RightBattleAreaCorner - Constants.PartyPlacementCorner, Constants.VerticalPartyCenter);
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}