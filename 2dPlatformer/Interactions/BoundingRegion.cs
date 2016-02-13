using _2dPlatformer.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPlatformer.Interactions
{
    abstract class BoundingRegion
    {
        public abstract Vector2 Center { get; }

        public abstract bool Overlaps(BoundingRegion b);
        public abstract bool Intersects(Vector2 p);
    }

    abstract class StaticBoundingRegion : BoundingRegion
    {
        private Vector2 m_center;
        public override Vector2 Center {
            get
            {
                return m_center;
            }
        }

        public StaticBoundingRegion(Vector2 center)
        {
            m_center = center;
        }
    }

    class StaticRectangularRegion : StaticBoundingRegion
    {
        public Vector2 Extents { get; private set; }

        public StaticRectangularRegion(Vector2 center, Vector2 extents)
            : base(center)
        {
            Extents = extents;
        }

        public override bool Intersects(Vector2 p)
        {
            return
                p.X > (Center.X - Extents.X) && p.X < (Center.X + Extents.X) &&
                p.Y > (Center.Y - Extents.Y) && p.Y < (Center.Y + Extents.Y);
        }

        public override bool Overlaps(BoundingRegion b)
        {
            var delta = b.Center - Center;
            var edgePoint = PointOnEdge(delta);
            if (edgePoint == Vector2.Zero)
                return true;
            
            return b.Intersects(edgePoint + Center);
        }

        /// <summary>
        /// Gets the point on vector that is at the boundry of this region
        /// </summary>
        /// <param name="vector"></param>
        /// <remarks>Since this is static, caching could be used</remarks>
        /// <returns></returns>
        private Vector2 PointOnEdge(Vector2 vector)
        {
            bool xSmall = vector.X.Abs() <= Extents.X,
                ySmall = vector.Y.Abs() <= Extents.Y;

            if (xSmall)
            {
                if (ySmall)
                    return Vector2.Zero;
                else
                    return vector * (Extents.Y / vector.Y.Abs());
            }
            else if(ySmall)
            {
                return vector * (Extents.X / vector.X.Abs());
            }
            else
            {
                var a = vector * (Extents.Y / vector.Y.Abs());
                var b = vector * (Extents.X / vector.X.Abs());

                return a.LengthSquared() < b.LengthSquared() ?
                    a : b;
            }
        }
    }

    class DynamicRectnagleRegion : BoundingRegion
    {
        public Vector2 Center { get; set; }

    }
}
