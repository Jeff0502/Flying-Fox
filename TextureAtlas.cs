using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlyingFox
{
    public class TextureAtlas
    {
        private Texture2D atlas;

        private GraphicsDevice graphicsDevice;

        public TextureAtlas(Texture2D atlas, GraphicsDevice graphicsDevice)
        {
            this.atlas = atlas;
            this.graphicsDevice = graphicsDevice;
        }

        public Texture2D? getTexture(Rectangle bounds)
        {
            if (atlas == null || !atlas.Bounds.Contains(bounds))
                return null;

            else
            {
                Texture2D tex = new Texture2D(graphicsDevice, bounds.Width, bounds.Height);

                Color[] buf = new Color[bounds.Width * bounds.Height];

                atlas.GetData(0, bounds, buf, 0, bounds.Width * bounds.Height);

                tex.SetData(buf);

                return tex;
            }
        }
    }
}
