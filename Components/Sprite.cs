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

    public SpriteEffects effects = SpriteEffects.None;

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
        _spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, width, height), null, Color.White, 0.0f, origin, effects, 0);
    }
}