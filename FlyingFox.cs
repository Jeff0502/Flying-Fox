using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Jumble.TextureAtlas;
using Jumble.ECS;
using FlyingFox.Components;
using FlyingFox.Systems;

namespace FlyingFox
{
    public class Flyingfox : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The bounds of the map
        public readonly static int MAP_WIDTH = 600, MAP_HEIGHT = 400;

        // The bounds of the virtual game window 
        private const int VIRTUAL_WIDTH = 320, VIRTUAL_HEIGHT = 180;

        // The bounds of the screen
        private int SCREEN_WIDTH, SCREEN_HEIGHT;

        public const int REFRESH_RATE = 60;

        private Registry registry;

        private RenderTarget2D renderTarget;

        public static TextureAtlas textureAtlas;

        private SystemManager systemManager = new SystemManager();

        private Matrix scale;

        public Flyingfox()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            registry = new Registry(100);

            // Create the virtual 'display'
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 400;
            _graphics.ApplyChanges();

            SCREEN_WIDTH = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            SCREEN_HEIGHT = _graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height;

            renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, SCREEN_WIDTH, SCREEN_HEIGHT);

            scale = Matrix.CreateScale((float)SCREEN_WIDTH / VIRTUAL_WIDTH, (float)SCREEN_HEIGHT / VIRTUAL_HEIGHT, 1.0f);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            textureAtlas = new TextureAtlas(Content.Load<Texture2D>("assets"), GraphicsDevice);
            // TODO: use this.Content to load your game content here
            systemManager.AddSystem(new PlayerSystem(registry));
            systemManager.AddSystem(new RigidbodySystem(registry));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            systemManager.Update(registry, deltaTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Draw to rendertarget 'backbuffer'
            _spriteBatch.GraphicsDevice.SetRenderTarget(renderTarget);
            _spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);


            View<Sprite> view = registry.View<Sprite>();

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            foreach (Entity e in view)
            {
                Sprite s = registry.GetComponent<Sprite>(e);

                s.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            // Draw to screen

            _spriteBatch.GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, null, null, null, scale);
            _spriteBatch.Draw(renderTarget, Vector2.Zero, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}