using System;
using FlyingFox.Components;
using FlyingFox.ECS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlyingFox.Systems
{
    internal class PlayerSystem : ECSSystem
    {
        private bool isOnGround;

        // Variables for quick access to components:
        private Rigidbody _playerRB;

        private Sprite _playerSprite;


        public PlayerSystem(Registry registry) : base(registry)
        {
            Position transform = new Position(new Vector2(50, 50));
            _playerSprite = new Sprite(Flyingfox.textureAtlas.getTexture(new Rectangle(0, 12, 11, 13)), transform);
            _playerRB = new Rigidbody(transform, 11, 14, 10);

            Entity p = new Entity();

            registry.AddComponent(p, _playerSprite);
            registry.AddComponent(p, transform);
            registry.AddComponent(p, new Input());
            registry.AddComponent(p, _playerRB);
        }

        public override void Update(Registry registry, float deltaTime)
        {
            if (Input.WasKeyPressed(Keys.Space) && isOnGround)
                _playerRB.ApplyForce(new Vector2(0, -20.0f * _playerRB.mass));
            if ((Input.IsKeyPressed(Keys.A) || Input.IsKeyPressed(Keys.Left)) && _playerRB.velocity.X > -Flyingfox.PLAYER_SPEED)
                _playerRB.ApplyForce(new Vector2(-10f, 0));
            if ((Input.IsKeyPressed(Keys.D) || Input.IsKeyPressed(Keys.Right)) && _playerRB.velocity.X < Flyingfox.PLAYER_SPEED)
                _playerRB.ApplyForce(new Vector2(10f, 0));

            // Flip the sprite when going different directions
            if (_playerRB.velocity.X < 0 && _playerSprite.effects != SpriteEffects.FlipHorizontally)
                _playerSprite.effects = SpriteEffects.FlipHorizontally;
            else if (_playerRB.velocity.X > 0 && _playerSprite.effects == SpriteEffects.FlipHorizontally)
                _playerSprite.effects = SpriteEffects.None;

            // Gravity
            _playerRB.ApplyForce(new Vector2(0, _playerRB.mass * Flyingfox.GRAVITY));

            if (_playerRB.max.Y >= Flyingfox.MAP_HEIGHT)
                isOnGround = true;

            else
                isOnGround = false;
        }
    }
}
