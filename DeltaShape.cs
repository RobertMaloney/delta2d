#if !DELTA2D_DELTASHAPE
#define DELTA2D_DELTASHAPE

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace delta2d
{
    public abstract class DeltaShape
    {
        public virtual string ShapeName
        {
            get
            {
                return "DeltaShape";
            }
        }
        public virtual AABB AABB
        {
            get
            {
                return new AABB(Vector2.Zero, Vector2.Zero);
            }
        }

        public virtual BoxShape asBoxShape()
        {
            return null;
        }

        public virtual SphereShape asSphereShape()
        {
            return null;
        }
    }
}

#endif