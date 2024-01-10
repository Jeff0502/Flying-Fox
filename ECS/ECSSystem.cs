using Microsoft.Xna.Framework.Graphics;

namespace FlyingFox.ECS
{
    public abstract class ECSSystem
    {
        public ECSSystem(Registry registry)
        { }

        public abstract void Update(Registry registry, float deltaTime);

        public virtual void Draw(Registry registry, SpriteBatch spriteBatch)
        { }
    }
}
