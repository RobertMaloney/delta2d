#if !DELTA2D_AABB
#define DELTA2D_AABB

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace delta2d
{
    public class AABB
    {
        private Vector2 m_topleft;
        private Vector2 m_botright;

        public AABB()
        {
            m_topleft = new Vector2(0,0);
            m_botright = new Vector2(0,0);
        }

        public AABB(Vector2 tl, Vector2 br)
        {
            m_topleft = tl;
            m_botright = br;
        }
    }
};

#endif