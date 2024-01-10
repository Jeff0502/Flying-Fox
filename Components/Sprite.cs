using FlyingFox.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite
{
    public Position position;

    public Texture2D texture;

    public int width;

    public int height;

    public Vector2 origin;

    public Sprite(Texture2D texture, Position position)
    {
        this.texture = texture;
        this.position = position;
        width = texture.Width;
        height = texture.Height;

        origin = new Vector2(width / 2, height / 2);
    }

    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(texture, position.Transform, null, Color.White, 0.0f, origin, 1, SpriteEffects.None, 0);
    }
}