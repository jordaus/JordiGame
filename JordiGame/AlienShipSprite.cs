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
    public enum Look
    {
        Left = 0,
        SlightLeft = 1,
        Front = 2,
        SlightRight = 3,
        Right = 4
    }
    public class AlienShipSprite
    {
        private Texture2D texture;

        private double directionTimer;

        private double animationTimer;

        private short animationFrame = 1;

        public Look Look;   

        public Vector2 position;

        public Vector2 velocity;

        private BoundingCircle bounds;

        public bool Collected { get; set; } = false;

        /// <summary>
        /// lambda syntax bounding of the sprite
        /// </summary>
        public BoundingCircle Bounds => bounds;

        public AlienShipSprite(Vector2 position)
        {
            this.position = position;
            this.bounds = new BoundingCircle(position - new Vector2(-8,-8), 8);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ship");
        }

        public void Update(GameTime gameTime)
        {
            //updates the direction timer
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //switches direction every two seconds
            if (directionTimer > 2.0)
            {
                switch (Look)
                {
                    case Look.Left:
                        Look = Look.SlightLeft;
                        break;
                    case Look.SlightLeft:
                        Look = Look.Front;
                        break;
                    case Look.Front:
                        Look = Look.SlightRight;
                        break;
                    case Look.SlightRight:
                        Look = Look.Right;
                        break;
                    case Look.Right:
                        Look = Look.Left;
                        break;
                }
                directionTimer -= 2.0;
            }

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Collected) return;
            //Update the animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //Update animation frame
            if (animationTimer > 0.3)
            {
                animationFrame++;
                if (animationFrame > 3)
                {
                    animationFrame = 1;
                }
                animationTimer -= 0.3;
            }

            //draws the sprite
            var source = new Rectangle(animationFrame * 16, 0, 16, 24);
            spriteBatch.Draw(texture, position, source, Color.White, 0f, new Vector2(0,0), 2, SpriteEffects.None, 0);
        }

    }
}
