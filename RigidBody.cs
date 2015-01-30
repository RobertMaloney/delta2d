#if !DELTA2D_RIGIDBODY
#define DELTA2D_RIGIDBODY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace delta2d
{
    public class RigidBody
    {
        private Texture2D m_texture;
        private Vector2 m_position;
        private Vector2 m_drawoffset;
        private Vector2 m_linearvel;
        private Vector2 m_gravity;
        private float m_rotation;
        private float m_scale;
        private float m_mass;
        private AABB m_aabb;
        private DeltaWorld m_deltaworld;

        public RigidBody(Texture2D tex)
        {
            m_texture = tex;
            m_position = new Vector2(0, 0);
            m_drawoffset = new Vector2(tex.Width / 2, tex.Height / 2);
            m_linearvel = new Vector2(0, 0);
            m_gravity = new Vector2(0, 0);
            m_rotation = 0.0f;
            m_scale = 1.0f;
            m_mass = 1.0f;
            m_aabb = new AABB(new Vector2(-1, -1), new Vector2(1, 1));
        }

        public void setGravity(Vector2 grav)
        {
            m_gravity = grav;
        }

        public void setPosition(Vector2 pos)
        {
            m_position = pos;
        }

        public Vector2 getPosition()
        {
            return m_position;
        }

        public void setScale(float scale)
        {
            m_scale = scale;
        }

        public float getScale()
        {
            return m_scale;
        }

        public void setMass(float mass)
        {
            m_mass = mass;
        }

        public float getMass()
        {
            return m_mass;
        }

        public void stepTime(float elapsedTime)
        {
            if (m_mass != 0.0f)
            {
                Vector2 newpos = m_position + m_linearvel * elapsedTime + 0.5f * m_gravity * elapsedTime * elapsedTime;
                m_position = newpos;
                m_linearvel += m_gravity * elapsedTime;
            }
        }

        public void draw(ref SpriteBatch sb)
        {
            sb.Draw(m_texture, m_position - m_drawoffset*m_scale, null, Color.White, m_rotation, Vector2.Zero, m_scale, SpriteEffects.None, 0);

            Texture2D pixel = new Texture2D(sb.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new Color[] { Color.White });

            sb.Draw(pixel, new Rectangle((int)(m_position.X - m_drawoffset.X * m_scale), (int)(m_position.Y - m_drawoffset.Y * m_scale), 1, (int)(m_drawoffset.Y * 2 * m_scale)), Color.Red);
            sb.Draw(pixel, new Rectangle((int)(m_position.X - m_drawoffset.X * m_scale), (int)(m_position.Y - m_drawoffset.Y * m_scale), (int)(m_drawoffset.X * 2 * m_scale), 1), Color.Red);
            sb.Draw(pixel, new Rectangle((int)(m_position.X + m_drawoffset.X * m_scale), (int)(m_position.Y - m_drawoffset.Y * m_scale), 1, (int)(m_drawoffset.Y * 2 * m_scale)), Color.Red);
            sb.Draw(pixel, new Rectangle((int)(m_position.X - m_drawoffset.X * m_scale), (int)(m_position.Y + m_drawoffset.Y * m_scale), (int)(m_drawoffset.X * 2 * m_scale), 1), Color.Red);
        }
    }
}

#endif