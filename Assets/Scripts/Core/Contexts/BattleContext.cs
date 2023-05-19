using Common.Battle;
using UnityEngine;

namespace Core.Contexts
{
    public class BattleContext : SceneContext
    {
        [SerializeField] private BattleMock _mock;

        public override void Construct()
        {
            base.Construct();
            
            RegisterInstance(_mock);
        }
    }
}