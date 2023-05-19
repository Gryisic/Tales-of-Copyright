using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Adventure.Triggers
{
    [Serializable]
    public class TriggersContainer
    {
        [SerializeField] private Trigger[] _triggers;

        public IReadOnlyList<Trigger> Triggers => _triggers;
    }
}