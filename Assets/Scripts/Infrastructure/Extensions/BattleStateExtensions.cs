using Common.Battle.States;
using Infrastructure.Interfaces;

namespace Infrastructure.Extensions
{
    public static class BattleStateExtensions
    {
        public static void SelectLeft(this BattleState state)
        {
            if (state is IUINavigatable navigatable)
                navigatable.SelectLeft();
        }

        public static void SelectRight(this BattleState state)
        {
            if (state is IUINavigatable navigatable)
                navigatable.SelectRight();
        }

        public static void Select(this BattleState state)
        {
            if (state is IUINavigatable navigatable)
                navigatable.Select();
        }

        public static void UndoSelection(this BattleState state)
        {
            if (state is IUINavigatable navigatable)
                navigatable.UndoSelection();
        }
    }
}