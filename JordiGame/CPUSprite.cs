using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace JordiGame
{
    public enum Face
    {
        Writing = 0,
        Thinking = 1,
        Normal = 2,
        Virus = 3,
    }
    public class CPUSprite
    {
        private Texture2D texture;
        private double faceTimer;
        private double animationTimer;
        private short animationFrame = 1;
        public Face face;
        public Vector2 position;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("PC");
        }

        public void Update(GameTime gameTime)
        {
            faceTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(faceTimer > 2.0)
            {
                switch (face)
                {
                    case Face.Writing:
                        face = Face.Thinking;
                        break;
                    case Face.Thinking:
                        face = Face.Normal;
                        break;
                    case Face.Normal:
                        face = Face.Virus;
                        break;
                    case Face.Virus:
                        face = Face.Writing;
                        break;
                }
                faceTimer -= 2.0;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if(animationTimer > 0.3)
            {
                animationFrame++;
                if (animationFrame > 3) animationFrame = 1;
                animationTimer -= 0.3;
            }
            var source = new Rectangle(0, (int)face * 32, 20, 18);
            spriteBatch.Draw(texture, position, source, Color.White, 0f, new Vector2(64,64), 2, SpriteEffects.None, 0);
        }
    }
}
