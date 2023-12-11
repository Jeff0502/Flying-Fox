using FlyingFox.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite
{
    public Transform transform;

    public Texture2D texture;

    public Rectangle sourceRectangle;

    public Sprite(Texture2D texture, Transform transform, Rectangle source)
    {
        this.texture = texture;
        this.transform = transform;
        this.sourceRectangle = source;
    }
}