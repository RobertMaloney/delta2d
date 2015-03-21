#if !DELTA2D_SphereShape
#define DELTA2D_SphereShape

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace delta2d
{
    public class SphereShape : DeltaShape
    {
        private AABB m_AABB;
        private float m_radius;

        public override string ShapeName
        {
            get
            {
                return "SphereShape";
            }
        }
        public override AABB AABB
        {
            get
            {
                return m_AABB;
            }
        }

        public SphereShape(float r)
        {
            m_radius = r;
            m_AABB = new AABB(new Vector2(-r, -r), new Vector2(r, r));
        }

        public override SphereShape asSphereShape()
        {
            return this;
        }
    }
}

#endif