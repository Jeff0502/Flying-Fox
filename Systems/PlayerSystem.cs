using System;
using FlyingFox.Components;
using FlyingFox.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FlyingFox.Systems
{
    internal class PlayerSystem : ECSSystem
    {
        private bool isOnGround;

        public PlayerSystem(Registry registry) : base(registry)
        {
            Position transform = new Position(new Vector2(50, 50));
            Sprite s = new Sprite(Flyingfox.textureAtlas.getTexture(new Rectangle(0, 12, 11, 13)), transform);

            Entity p = new Entity();

            registry.AddComponent(p, s);
            registry.AddComponent(p, transform);
            registry.AddComponent(p, new Input());
            registry.AddComponent(p, new Rigidbody(transform, 11, 14, 10));
        }

        public override void Update(Registry registry, float deltaTime)
        {
            var view = registry.View<Rigidbody>();

            foreach (var player in view)
            {
                Rigidbody rb = registry.GetComponent<Rigidbody>(player);

                if (Input.WasKeyPressed(Keys.Space) && isOnGround)
                    rb.ApplyForce(new Vector2(0, -9.0f * rb.mass));
                if ((Input.IsKeyPressed(Keys.A) || Input.IsKeyPressed(Keys.Left)) && rb.velocity.X > -Flyingfox.PLAYER_SPEED)
                    rb.ApplyForce(new Vector2(-10f, 0));
                if ((Input.IsKeyPressed(Keys.D) || Input.IsKeyPressed(Keys.Right)) && rb.velocity.X < Flyingfox.PLAYER_SPEED)
                    rb.ApplyForce(new Vector2(10f, 0));

                // Gravity
                rb.ApplyForce(new Vector2(0, rb.mass * Flyingfox.GRAVITY));

                if (rb.max.Y >= Flyingfox.MAP_HEIGHT)
                    isOnGround = true;

                else
                    isOnGround = false;
            }

        }
    }
}
