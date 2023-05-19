using UnityEngine;

namespace Common.Models.Party
{
    [CreateAssetMenu(menuName = "Data / Placement / PartyFormation", fileName = "PartyFormation")]
    public class PartyFormationTemplate : ScriptableObject
    {
        [SerializeField] private Vector2 _positionOfFirstMember;
        [SerializeField] private Vector2 _positionOfSecondMember;
        [SerializeField] private Vector2 _positionOfThirdMember;
        [SerializeField] private Vector2 _positionOfFourthMember;
        
        public Vector2 PositionOfFirstMember => _positionOfFirstMember;
        public Vector2 PositionOfSecondMember => _positionOfSecondMember;
        public Vector2 PositionOfThirdMember => _positionOfThirdMember;
        public Vector2 PositionOfFourthMember => _positionOfFourthMember;
    }
}