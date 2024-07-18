using Microsoft.Xna.Framework;

namespace FlyingFox.Components
{
    internal class Rigidbody
    {
        public int mass = 1;
        public Position position;

        public Vector2 oldPosition, velocity, acceleration;

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

        public Rigidbody(Position position, int width, int height, int mass)
        {
            acceleration = Vector2.Zero;
            this.position = position;
            this.oldPosition = position.Transform;
            this.width = width;
            this.height = height;
            this.mass = mass;
        }

        public void Update(float deltaTime)
        {
            velocity = position.Transform - oldPosition;
            velocity *= 0.9f;

            oldPosition = position.Transform;

            // Make the refresh rate dynamic
            position.Transform = position.Transform + velocity + acceleration;
            
            acceleration = Vector2.Zero;

            ApplyConstraints();
        }

        // Fnet = ma
        public void ApplyForce(Vector2 force)
        {
            acceleration += force / mass;
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
