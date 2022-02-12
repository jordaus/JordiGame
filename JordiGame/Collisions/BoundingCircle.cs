using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace JordiGame.Collisions
{
        public struct BoundingCircle
        {
            /// <summary>
            /// Center of the bounding
            /// </summary>
            public Vector2 Center;

            /// <summary>
            /// Radius of the bounding
            /// </summary>
            public float Radius;

            /// <summary>
            /// Constructs a new bounding circle
            /// </summary>
            /// <param name="center"></param>
            /// <param name="radius"></param>
            public BoundingCircle(Vector2 center, float radius)
            {
                Center = center;
                Radius = radius;
            }

            /// <summary>
            /// Checks if collision is good
            /// </summary>
            /// <param name="other"></param>
            /// <returns></returns>
            public bool CollidesWith(BoundingCircle other)
            {
                return CollisionHelper.Collides(this, other);
            }

            public bool CollidesWith(BoundingRectangle other)
            {
                return CollisionHelper.Collides(this, other);
            }
        }
}
