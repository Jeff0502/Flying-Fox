using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Jumble.TextureAtlas;
using Jumble.ECS;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private const int VIRTUAL_WIDTH = 1280, VIRTUAL_HEIGHT = 720;

    private Registry registry;

    private Entity p;

    private TextureAtlas textureAtlas;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        registry = new Registry(100);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        textureAtlas = new TextureAtlas(Content.Load<Texture2D>("assets"), GraphicsDevice);
        // TODO: use this.Content to load your game content here
        Sprite s = new Sprite(Content.Load<Texture2D>("Neko"), new Rectangle(50, 50, 11, 14), new Rectangle(18, 17, 11, 14));

        p = new Entity();

        registry.AddComponent<Sprite>(p, s);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        View<Sprite> view = registry.View<Sprite>();

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        foreach(Entity e in view)
        {
            Sprite s = registry.GetComponent<Sprite>(e);

            _spriteBatch.Draw(s.texture, s.hitbox, s.sourceRectangle, Color.White);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
