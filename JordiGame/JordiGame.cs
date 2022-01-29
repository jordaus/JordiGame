using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JordiGame
{
    public class JordiGame : Game
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


        public JordiGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Jordi's Game";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            computer = new CPUSprite() { position = new Vector2(150, 150), face = Face.Writing };
            //initializes img position
            imgPosition = new Vector2(
                GraphicsDevice.Viewport.Width/2,
                GraphicsDevice.Viewport.Height/2
                );
            imgPosition2 = new Vector2(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2
                );
            imgPosition3 = new Vector2(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2
                );
            System.Random random = new System.Random();
            System.Random random2 = new System.Random();
            System.Random random3 = new System.Random();
            imgVelocity = new Vector2(
                (float)random.NextDouble(),
                (float)random.NextDouble()
                );
            imgVelocity2 = new Vector2(
                (float)random2.NextDouble(),
                (float)random2.NextDouble()
                );
            imgVelocity3 = new Vector2(
                (float)random3.NextDouble(),
                (float)random3.NextDouble()
                );

            imgVelocity.Normalize();
            imgVelocity2.Normalize();
            imgVelocity3.Normalize();
            imgVelocity *= 100;
            imgVelocity2 *= 200;
            imgVelocity3 *= 50;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            smallTitle = Content.Load<Texture2D>("pixil-frame-0");
            mainTitle = Content.Load<Texture2D>("jg");
            star = Content.Load<Texture2D>("star");
            cloud9 = Content.Load<Texture2D>("cloud9");
            impact = Content.Load<SpriteFont>("font");
            uno = Content.Load<SpriteFont>("uno");
            computer.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            computer.Update(gameTime);

            // TODO: Add your update logic here
            imgPosition += (float)gameTime.ElapsedGameTime.TotalSeconds * imgVelocity;
            imgPosition2 += (float)gameTime.ElapsedGameTime.TotalSeconds * imgVelocity2;
            imgPosition3 += (float)gameTime.ElapsedGameTime.TotalSeconds * imgVelocity3;

            if (imgPosition.X < GraphicsDevice.Viewport.X || imgPosition.X > GraphicsDevice.Viewport.Width - 64)
            {
                imgVelocity.X *= -1;
            }

            if (imgPosition.Y < GraphicsDevice.Viewport.Y || imgPosition.Y > GraphicsDevice.Viewport.Height - 64)
            {
                imgVelocity.Y *= -1;
            }

            if (imgPosition2.X < GraphicsDevice.Viewport.X || imgPosition2.X > GraphicsDevice.Viewport.Width - 64)
            {
                imgVelocity2.X *= -1;
            }

            if (imgPosition2.Y < GraphicsDevice.Viewport.Y || imgPosition2.Y > GraphicsDevice.Viewport.Height - 64)
            {
                imgVelocity2.Y *= -1;
            }
            if (imgPosition3.X < GraphicsDevice.Viewport.X || imgPosition3.X > GraphicsDevice.Viewport.Width - 64)
            {
                imgVelocity3.X *= -1;
            }

            if (imgPosition3.Y < GraphicsDevice.Viewport.Y || imgPosition3.Y > GraphicsDevice.Viewport.Height - 64)
            {
                imgVelocity3.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(smallTitle, imgPosition, Color.White);
            spriteBatch.Draw(star, imgPosition2, Color.White);
            spriteBatch.Draw(cloud9, imgPosition3, Color.White);
            spriteBatch.Draw(mainTitle, new Vector2(300, 100), Color.White);
            computer.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(impact, "Press ESC To Exit the Game!", new Vector2(220, 350), Color.White);
            //spriteBatch.DrawString(uno, "Hello", new Vector2(100, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
