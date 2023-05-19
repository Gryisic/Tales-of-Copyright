namespace Common.Models.StatSystem
{
    public class Stat
    {
        private readonly int _baseValue;

        public int Value => _baseValue;
        
        public Stat(int baseValue)
        {
            _baseValue = baseValue;
        }
    }
}