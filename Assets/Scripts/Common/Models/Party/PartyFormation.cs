using UnityEngine;

namespace Common.Models.Party
{
    public class PartyFormation
    {
        public Vector2[] Positions { get; private set; }

        public PartyFormation(PartyFormationTemplate template)
        {
            Positions = new Vector2[]
            {
                template.PositionOfFirstMember,
                template.PositionOfSecondMember,
                template.PositionOfThirdMember,
                template.PositionOfFourthMember
            };
        }
    }
}