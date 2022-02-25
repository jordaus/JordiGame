using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using JordiGame.Collisions;

namespace JordiGame.Screens
{
    public class LiftOffGameplayScreen : StateManagement.GameScreen
    {
        private Texture2D ball;
        private LanderSprite lander;
        private AlienShipSprite[] alien;
        private ContentManager _content;
        private BoundingCircle bounds;
        private SoundEffect alienPickup;
        private Song backgroundMusic;
        private SpriteFont font;
        public bool Hit { get; set; } = false;
        private int alienCount;

        /// <summary>
        /// Initializes the game
        /// </summary>
        public override void Activate()
        {
            JordiGame game = ScreenManager.Game as JordiGame;
            // TODO: Add your initialization logic here
            lander = new LanderSprite();
            alien = new AlienShipSprite []
            {
                new AlienShipSprite(new Vector2(400,100)){Look = Look.Left},
                new AlienShipSprite(new Vector2(470,200)){Look = Look.Front},
                new AlienShipSprite(new Vector2(360,300)){Look = Look.Right}
            };
            alienCount = alien.Length;
            LoadContent();
        }

        /// <summary>
        /// Loads content for the game
        /// </summary>
        protected void LoadContent()
        {
            _content = new ContentManager(ScreenManager.Game.Services, "Content");
            // TODO: use this.Content to load your game content here
            lander.LoadContent(_content);
            foreach (var a in alien) a.LoadContent(_content);
            ball = _content.Load<Texture2D>("ball");
            alienPickup = _content.Load<SoundEffect>("Pickup_Coin10");
            backgroundMusic = _content.Load<Song>("G O L D snippet");
            font = _content.Load<SpriteFont>("font");
            MediaPlayer.Play(backgroundMusic);
        }

        /// <summary>
        /// Updates the game
        /// </summary>
        /// <param name="gameTime">An object representing game time</param>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
              //  Exit();

            // TODO: Add your update logic here
            lander.Update(gameTime);
            foreach (var a in alien)
            {
                a.Position += new Vector2(1, 0) * 3 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //a.Update(gameTime);
                if (!a.Collected && a.Bounds.CollidesWith(lander.Bounds))
                {
                    lander.Color = Color.Red;
                    a.Collected = true;
                    alienPickup.Play();
                    alienCount--;
                    if(alienCount == 0)
                    {
                        LiftOffInfoScreen liftOffInfo = new LiftOffInfoScreen();
                        ScreenManager.AddScreen(liftOffInfo, ControllingPlayer);
                    }
                }
            }
            
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }

        /// <summary>
        /// Draws the game
        /// </summary>
        /// <param name="gameTime">An object representing game time</param>
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.DrawString(font, "Welcome To The Alien Catcher Mini-Game", new Vector2(100, 350), Color.White);
            ScreenManager.SpriteBatch.DrawString(font, "Press The Space Bar to move the Lander", new Vector2(100, 400), Color.White);
            lander.Draw(gameTime, ScreenManager.SpriteBatch);
            foreach (var a in alien) 
            {
                a.Draw(gameTime, ScreenManager.SpriteBatch);
                //var rect = new Rectangle((int)(a.Bounds.Center.X - a.Bounds.Radius), (int)(a.Bounds.Center.Y - a.Bounds.Radius), (int)a.Bounds.Radius, (int)a.Bounds.Radius);
                //ScreenManager.SpriteBatch.Draw(ball, rect, Color.White);
            } 
            ScreenManager.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
