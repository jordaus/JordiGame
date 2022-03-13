using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using JordiGame.Collisions;

namespace JordiGame
{
    public class LanderSprite
    {
        Texture2D texture;
        public Vector2 position;
        Vector2 velocity;

        private BoundingRectangle bounds = new BoundingRectangle(new Vector2(200 - 16, 200 - 16), 32, 32);

        /// <summary>
        /// lambda syntax bounding of the sprite (make sure if you wanna swicth to a circle use Bounding Circle
        /// </summary>
        public BoundingRectangle Bounds => bounds;

        public Color Color { get; set; } = Color.White;

        public float rotation = 0f;

        /// <summary>
        /// Constructs a new lander sprite 
        /// </summary>
        public LanderSprite()
        {
            position = new Vector2(300, 300);
            velocity = new Vector2(10, 0);
        }

        /// <summary>
        /// Loads the content for the sprite
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("lander");
        }

        /// <summary>
        /// Updates the sprite
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //F = ma
            Vector2 acceleration = new Vector2(0, 30);
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                acceleration += new Vector2(0, -80);
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                rotation += 0.25f;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                rotation -= 0.25f;
            }

            velocity += acceleration * t;
            position += velocity * t;
            bounds.X = position.X - 20;
            bounds.Y = position.Y - 20;
        }

        public void BounceX()
        {
            velocity.X *= -1;
        }

        public void BounceY()
        {
            velocity.Y *= -1;
        }

        /// <summary>
        /// Draws the sprite on-screen
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color, rotation, new Vector2(56.5f,51.5f), 0.5f, SpriteEffects.None, 0f);
        }
    }
}
