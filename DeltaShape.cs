#if !DELTA2D_DELTASHAPE
#define DELTA2D_DELTASHAPE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace delta2d
{
    class DeltaShape
    {
        private AABB m_aabb;
        private List<Vector2> m_extents;
        private Texture2D m_texture;

        public int Width
        {
            get
            {
                return m_texture.Width;
            }
        }
        public int Height
        {
            get
            {
                return m_texture.Height;
            }
        }
        public Texture2D Texture
        {
            get
            {
                return m_texture;
            }
        }

        public DeltaShape(Texture2D tex)
        {
            m_texture = tex;
            Color[] c = new Color[tex.Width * tex.Height];
            tex.GetData<Color>(c);

            for (int i = 0; i < tex.Width; i += 2)
            {
                for (int j = 0; j < tex.Height; ++j)
                {
                    if (c[i * tex.Width + j].A != 0)
                    {
                        // log extents
                    }
                }
            }

            m_texture.SetData<Color>(c);
            m_aabb = new AABB(new Vector2(-1, -1), new Vector2(1, 1));
        }

        public AABB getAABB(float rotation)
        {
            return m_aabb;
        }
    }
}

#endif