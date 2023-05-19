namespace Infrastructure.Interfaces
{
    public interface IUINavigatable
    {
        public void SelectLeft();
        
        public void SelectRight();
        
        public void Select();

        public void UndoSelection();
    }
}