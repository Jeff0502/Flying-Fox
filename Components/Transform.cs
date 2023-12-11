using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace FlyingFox.Components
{
    public class Transform
    {
        public Vector2 position;

        public Transform(Vector2 position)
        {
            this.position = position;
        }
    }
}
