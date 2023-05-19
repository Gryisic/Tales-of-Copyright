using System.Collections.Generic;
using Common.Models.BattleActions;

namespace Common.Data
{
    public class MemberData
    {
        private List<Action> _actions;

        public IReadOnlyList<Action> Actions => _actions;
    }
}