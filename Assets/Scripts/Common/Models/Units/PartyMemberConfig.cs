using Infrastructure.Utils;
using UnityEngine;

namespace Common.Models.Units
{
    [CreateAssetMenu(menuName = "Data / Units / PartyMemberConfig", fileName = "PartyMemberConfig")]
    public class PartyMemberConfig : UnitConfig
    {
        [SerializeField] private Enums.PartyMemberType _type;
        [SerializeField] private SoundsContainer _soundsContainer;

        public Enums.PartyMemberType Type => _type;
        public SoundsContainer SoundsContainer => _soundsContainer;
    }
}