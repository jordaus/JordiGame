using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace JordiGame.Collisions
{
    /// <summary>
    /// A bounding rectangle for collision
    /// </summary>
    public struct BoundingRectangle
    {
        public float X;

        public float Y;

        public float Height;

        public float Width;

        public float Right => X + Width;

        public float Left => X;

        public float Top => Y;

        public float Bottom => Y + Height;

        public BoundingRectangle(float x, float y, float height, float width)
        {
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public BoundingRectangle(Vector2 position, float width, float height)
        {
            X = position.X;
            Y = position.Y;
            Height = height;
            Width = width;
        }

        public bool CollidesWith(BoundingRectangle other)
        {
            return CollisionHelper.Collides(this, other);
        }

        public bool CollidesWith(BoundingCircle other)
        {
            return CollisionHelper.Collides(other, this);
        }
    }
}
