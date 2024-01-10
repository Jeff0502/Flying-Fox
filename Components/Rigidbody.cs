using Microsoft.Xna.Framework;

namespace FlyingFox.Components
{
    internal class Rigidbody
    {
        public Vector2 resultantForce;

        public Position position;

        public Vector2 oldPosition, velocity;

        public Vector2 min
        {
            get
            {
                return new Vector2(position.X - width / 2, position.Y - height / 2);
            }
        }

        public Vector2 max
        {
            get
            {
                return new Vector2(position.X + width / 2, position.Y + height / 2);
            }
        }

        public float width, height;

        public Rigidbody(Position position, int width, int height)
        {
            this.position = position;
            this.oldPosition = position.Transform;
            this.width = width;
            this.height = height;
        }

        public void Update(float deltaTime)
        {
            velocity = (position.Transform - oldPosition);

            oldPosition = position.Transform;

            // Make the refresh rate dynamic
            position.Transform = position.Transform + velocity + resultantForce * deltaTime * deltaTime * Flyingfox.REFRESH_RATE;

            resultantForce = Vector2.Zero;

            ApplyConstraints();
        }

        public void ApplyForce(Vector2 force)
        {
            resultantForce += force;
        }

        public void ApplyConstraints()
        {
            // TODO: Perfect the reflection
            if (max.X > Flyingfox.MAP_WIDTH)
                position.X = Flyingfox.MAP_WIDTH - width / 2;
            else if (min.X < 0)
                position.X = width / 2;

            if (max.Y > Flyingfox.MAP_HEIGHT)
                position.Y = Flyingfox.MAP_HEIGHT - height / 2;
            else if (min.Y < 0)
                position.Y = height / 2;
        }
    }
}
