using UnityEngine;

namespace Common.Models.Party
{
    [CreateAssetMenu(menuName = "Data / Placement / PartyFormations", fileName = "PartyFormations")]
    public class PartyFormationsTemplate : ScriptableObject
    {
        [SerializeField] private PartyFormationTemplate _first;
        [SerializeField] private PartyFormationTemplate _second;
        [SerializeField] private PartyFormationTemplate _third;
        
        public PartyFormationTemplate First => _first;
        public PartyFormationTemplate Second => _second;
        public PartyFormationTemplate Third => _third;
    }
}