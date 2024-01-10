using FlyingFox.ECS;
using System;

namespace FlyingFox.Systems
{
    internal class SpriteSystem : ECSSystem
    {
        public SpriteSystem(Registry registry) : base(registry)
        {
        }

        public override void Update(Registry registry, float deltaTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(Registry registry)
        {
            var view = registry.View<Sprite>();

            foreach (var e in view)
            {
                Sprite s = registry.GetComponent<Sprite>(e);
            }
        }
    }
}
