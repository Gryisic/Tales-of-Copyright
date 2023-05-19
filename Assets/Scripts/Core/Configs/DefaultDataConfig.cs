using Common.Models.Party;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Configs
{
    [CreateAssetMenu(menuName = "Configs / DefaultData", fileName = "DefaultData")]
    public class DefaultDataConfig : ScriptableObject
    {
        [FormerlySerializedAs("_partyPositions")] [SerializeField] private PartyFormationsTemplate partyFormations;

        public PartyFormationsTemplate PartyFormations => partyFormations;
    }
}