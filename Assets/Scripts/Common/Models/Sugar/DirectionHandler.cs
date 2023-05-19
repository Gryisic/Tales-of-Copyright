using UnityEngine;

namespace Common.Models.Sugar
{
    public class DirectionHandler
    {
        public Vector2 Direction { get; private set; }

        public Vector2 HorizontalDirection => new Vector2(Direction.x, 0);

        public Vector2 VerticalDirection => new Vector2(0, Direction.y);

        public void Update(Vector2 direction) => Direction = direction;
    }
}