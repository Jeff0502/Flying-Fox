using Jumble.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach(var e in view)
            {
                Sprite s = registry.GetComponent<Sprite>(e);
            }
        }
    }
}
