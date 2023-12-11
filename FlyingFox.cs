using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Jumble.TextureAtlas;
using Jumble.ECS;
using FlyingFox.Components;

namespace FlyingFox
{
    public class FlyingFox : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const int VIRTUAL_WIDTH = 320, VIRTUAL_HEIGHT = 180;

        private Registry registry;

        private Entity p;

        private RenderTarget2D renderTarget;

        private TextureAtlas textureAtlas;

        private PlayerSystem playerSystem;

        public FlyingFox()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            registry = new Registry(100);

            // Create the virtual 'display'
            renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, VIRTUAL_WIDTH, VIRTUAL_HEIGHT);
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 360;
            _graphics.ApplyChanges();

            playerSystem = new PlayerSystem(registry);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            textureAtlas = new TextureAtlas(Content.Load<Texture2D>("assets"), GraphicsDevice);
            // TODO: use this.Content to load your game content here
            Transform transform = new Transform(new Vector2(50, 50));
            Sprite s = new Sprite(Content.Load<Texture2D>("Neko"), transform, new Rectangle(18, 17, 11, 14));

            p = new Entity();

            registry.AddComponent<Sprite>(p, s);
            registry.AddComponent(p, transform);
            registry.AddComponent(p, new Input());

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerSystem.Update();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            View<Sprite> view = registry.View<Sprite>();

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (Entity e in view)
            {
                Sprite s = registry.GetComponent<Sprite>(e);

                _spriteBatch.Draw(s.texture, s.transform.position, s.sourceRectangle, Color.White);
            }

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, null);
            _spriteBatch.Draw(renderTarget, GraphicsDevice.Viewport.Bounds, Color.White);
            _spriteBatch.End();
     
            base.Draw(gameTime);
        }
    }

}