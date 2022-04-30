using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JordiGame.Screens
{
    public class TitleScreen : StateManagement.GameScreen
    {

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
        private ContentManager _content;

        public override void Activate()
        {
            JordiGame game = ScreenManager.Game as JordiGame;
            // TODO: Add your initialization logic here
            computer = new CPUSprite() { position = new Vector2(150, 150), face = Face.Writing };
            //initializes img position
            imgPosition = new Vector2(
                game.Viewport.Width / 2,
                game.Viewport.Height / 2
                );
            imgPosition2 = new Vector2(
                game.Viewport.Width / 2,
                game.Viewport.Height / 2
                );
            imgPosition3 = new Vector2(
                game.Viewport.Width / 2,
                game.Viewport.Height / 2
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
            
            LoadContent();
            
        }

        protected void LoadContent()
        {
            _content = new ContentManager(ScreenManager.Game.Services, "Content");
            // TODO: use this.Content to load your game content here
            smallTitle = _content.Load<Texture2D>("pixil-frame-0");
            mainTitle = _content.Load<Texture2D>("jg");
            star = _content.Load<Texture2D>("star");
            cloud9 = _content.Load<Texture2D>("cloud9");
            impact = _content.Load<SpriteFont>("font");
            uno = _content.Load<SpriteFont>("uno");
            computer.LoadContent(_content);
        }

        public override void HandleInput(GameTime gameTime, StateManagement.InputState input) 
        {
            PlayerIndex player;
            if(input.IsKeyPressed(Keys.Enter, null, out player) || input.IsMouseClicked())
            {
                LiftOffGameplayScreen liftOffGameplay = new LiftOffGameplayScreen();
                ScreenManager.AddScreen(liftOffGameplay, player);
            }
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            JordiGame game = ScreenManager.Game as JordiGame;
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit();
            computer.Update(gameTime);

            // TODO: Add your update logic here
            imgPosition += (float)gameTime.ElapsedGameTime.TotalSeconds * imgVelocity;
            imgPosition2 += (float)gameTime.ElapsedGameTime.TotalSeconds * imgVelocity2;
            imgPosition3 += (float)gameTime.ElapsedGameTime.TotalSeconds * imgVelocity3;

            if (imgPosition.X < game.Viewport.X || imgPosition.X > game.Viewport.Width - 64)
            {
                imgVelocity.X *= -1;
            }

            if (imgPosition.Y < game.Viewport.Y || imgPosition.Y > game.Viewport.Height - 64)
            {
                imgVelocity.Y *= -1;
            }

            if (imgPosition2.X < game.Viewport.X || imgPosition2.X > game.Viewport.Width - 64)
            {
                imgVelocity2.X *= -1;
            }

            if (imgPosition2.Y < game.Viewport.Y || imgPosition2.Y > game.Viewport.Height - 64)
            {
                imgVelocity2.Y *= -1;
            }
            if (imgPosition3.X < game.Viewport.X || imgPosition3.X > game.Viewport.Width - 64)
            {
                imgVelocity3.X *= -1;
            }

            if (imgPosition3.Y < game.Viewport.Y || imgPosition3.Y > game.Viewport.Height - 64)
            {
                imgVelocity3.Y *= -1;
            }

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw(smallTitle, imgPosition, Color.White);
            ScreenManager.SpriteBatch.Draw(star, imgPosition2, Color.White);
            ScreenManager.SpriteBatch.Draw(cloud9, imgPosition3, Color.White);
            ScreenManager.SpriteBatch.Draw(mainTitle, new Vector2(300, 100), Color.White);
            computer.Draw(gameTime, ScreenManager.SpriteBatch);
            ScreenManager.SpriteBatch.DrawString(impact, "Press Enter to Start! | Press ESC To Exit the Game!", new Vector2(50, 350), Color.White);
            //spriteBatch.DrawString(uno, "Hello", new Vector2(100, 100), Color.White);
            ScreenManager.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
