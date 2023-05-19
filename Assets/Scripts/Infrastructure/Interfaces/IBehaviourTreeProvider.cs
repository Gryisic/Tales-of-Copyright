using Common.Battle.BehaviourTree;

namespace Infrastructure.Interfaces
{
    public interface IBehaviourTreeProvider
    {
        BehaviourTree Tree { get; }
    }
}