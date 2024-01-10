using Microsoft.Xna.Framework;

namespace FlyingFox.Components
{
    public class Position
    {
        public float X, Y;

        public Vector2 Transform
        {
            get
            {
                return new Vector2(X, Y);
            }

            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Position(Vector2 position)
        {
            this.X = position.X;
            this.Y = position.Y;
        }
    }
}
