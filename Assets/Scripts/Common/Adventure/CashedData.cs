using UnityEngine;

namespace Common.Adventure
{
    public class CashedData
    {
        public Vector2 PlayerPosition { get; private set; }

        public void UpdateData(Vector2 playerPosition)
        {
            PlayerPosition = playerPosition;
        }
    }
}