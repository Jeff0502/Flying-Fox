using Jumble.ECS;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingFox.Components
{
    internal class PlayerSystem
    {
        private Registry registry;

        public PlayerSystem(Registry registry) 
        {
            this.registry = registry;
        }

        public void Update()
        {
            var view = registry.View<Transform, Input>();

            foreach(var player in view)
            {
                registry.GetComponent<Transform>(player).position.X += 0.1f;
            }
                
        }
    }
}
