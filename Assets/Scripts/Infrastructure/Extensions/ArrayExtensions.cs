namespace Infrastructure.Extensions
{
    public static class ArrayExtensions
    {
        public static T Random<T>(this T[] array)
        {
            int index = UnityEngine.Random.Range(0, array.Length);

            return array[index];
        }
    }
}