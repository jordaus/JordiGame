using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JordiGame
{
    public class JordiGame : Game, IParticleEmitter
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private Vector2 spriteVelocity;
        private Vector2 imgPosition;
        private Vector2 imgPosition2;
        private Vector2 imgPosition3;
        private Vector2 imgVelocity;
        private Vector2 imgVelocity2;
        private Vector2 imgVelocity3;
        private Texture2D mainTitle;
        private Texture2D smallTitle;
        private Texture2D star;
        private Texture2D cloud9;
        private SpriteFont impact;
        private SpriteFont uno;
        private CPUSprite computer;
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }


        private StateManagement.ScreenManager screenManager;

        public Viewport Viewport { get { return GraphicsDevice.Viewport; } }


        public JordiGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Jordi's Game";
            screenManager = new StateManagement.ScreenManager(this);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenManager.Initialize();
            PixieParticleSystem pixie = new PixieParticleSystem(this, this);
            Components.Add(pixie);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            StateManagement.GameScreen titleScreen = new Screens.TitleScreen();
            screenManager.AddScreen(titleScreen, PlayerIndex.One);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            screenManager.Update(gameTime);
            MouseState currentMouse = Mouse.GetState();
            Vector2 mousePosition = new Vector2(currentMouse.X, currentMouse.Y);
            Velocity = mousePosition - Position;
            Position = mousePosition;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            screenManager.Draw(gameTime);
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
