#if !DELTA2D_DeltaUtil
#define DELTA2D_DeltaUtil

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace delta2d
{
    public class DeltaUtil
    {
        public static Vector2 Delta2XNA(Rigidbody rbody, Texture2D tex)
        {
            return new Vector2(rbody.Position.X - rbody.Scale * tex.Width / 2, rbody.Position.Y - rbody.Scale * tex.Height / 2);
        }
    }
}

#endif