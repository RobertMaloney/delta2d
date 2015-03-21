#if !DELTA2D_BoxShape
#define DELTA2D_BoxShape

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace delta2d
{
    public class BoxShape : DeltaShape
    {
        private AABB m_AABB;
        private Vector2 m_halfLengths;

        public override string ShapeName
        {
            get
            {
                return "BoxShape";
            }
        }
        public override AABB AABB
        {
            get
            {
                return m_AABB;
            }
        }

        public override BoxShape asBoxShape()
        {
            return this;
        }

        // Square
        public BoxShape(float l)
        {
            m_halfLengths = new Vector2(l, l);
            m_AABB = new AABB(new Vector2(-l, -l), new Vector2(l, l));
        }

        // Rect
        public BoxShape(float w, float l)
        {
            m_halfLengths = new Vector2(w, l);
            m_AABB = new AABB(new Vector2(-w, -l), new Vector2(w, l));
        }

        // Rect 2
        public BoxShape(Vector2 halfLengths)
        {
            m_halfLengths = halfLengths;
            m_AABB = new AABB(new Vector2(-halfLengths.X, -halfLengths.Y), new Vector2(halfLengths.X, halfLengths.Y));
        }
    }
}

#endif