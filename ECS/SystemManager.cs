using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace FlyingFox.ECS
{
    public class SystemManager
    {
        public List<ECSSystem> systems = new List<ECSSystem>();

        public List<ECSSystem> systemsToRemove = new List<ECSSystem>();

        public void Update(Registry registry, float deltaTime)
        {
            foreach (ECSSystem system in systems)
            {
                system.Update(registry, deltaTime);
            }

            Flush();
        }

        public void Draw(Registry registry, SpriteBatch spriteBatch)
        {
            foreach (ECSSystem system in systems)
            {
                system.Draw(registry, spriteBatch);
            }
        }

        public void AddSystem(ECSSystem system)
        {
            systems.Add(system);
        }

        public void RemoveSystem(ECSSystem system)
        {
            systemsToRemove.Add(system);
        }

        public ECSSystem? GetSystem<T>() where T : ECSSystem
        {
            foreach (ECSSystem system in systems)
            {
                if (system.GetType() == typeof(T))
                    return system;
            }

            return null;
        }

        public void Flush()
        {
            foreach (var system in systemsToRemove)
            {
                systems.Remove(system);
            }

            systemsToRemove.Clear();
        }
    }
}
