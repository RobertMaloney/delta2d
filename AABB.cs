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
    /**
     * Axis-Aligned Bounding Box
     */
    public class AABB
    {
        private Vector2 m_topleft;
        private Vector2 m_botright;
        
        public AABB()
        {
            m_topleft = new Vector2(0, 0);
            m_botright = new Vector2(0,0);
        }

        public AABB(Vector2 tl, Vector2 br)
        {
            m_topleft = tl;
            m_botright = br;
        }

        public Vector2 getTopLeft()
        {
            return m_topleft;
        }

        public Vector2 getBotRight()
        {
            return m_botright;
        }

        public bool contains(Vector2 p)
        {
            return (p.X >= m_topleft.X && p.X <= m_botright.X &&
                    p.Y <= m_topleft.Y && p.Y >= m_botright.Y);
        }

        public bool intersects(AABB other)
        {
            Vector2 tl = other.getTopLeft(), br = other.getBotRight();
            if (tl.X > m_botright.X || br.X < m_topleft.X) return false;
            if (tl.Y < m_botright.Y || br.Y > m_topleft.Y) return false;

            return true;
        }
    }
};

#endif