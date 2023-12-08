using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public struct Sprite
{
    public Texture2D texture;

    public Rectangle hitbox, sourceRectangle;

    public Sprite(Texture2D texture, Rectangle hitbox, Rectangle source)
    {
        this.texture = texture;
        this.hitbox = hitbox;
        this.sourceRectangle = source;
    }
}