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
        private DeltaShape m_shape;
        private Vector2 m_position;
        private Vector2 m_drawoffset;
        private Vector2 m_linearvel;
        private Vector2 m_gravity;
        private float m_angularvel;
        private float m_rotation;
        private float m_scale;
        private float m_mass;
        private float m_restitution;
        private AABB m_aabb;

        public AABB AABB
        {
            get
            {
                // private AABB is [-1,1], so we must convert to world space
                AABB ret = new AABB();
                ret.Min = new Vector2(m_shape.Width * m_scale / 2 * m_aabb.Min.X + m_position.X, m_shape.Height * m_scale / 2 * m_aabb.Min.Y + m_position.Y);
                ret.Max = new Vector2(m_shape.Width * m_scale / 2 * m_aabb.Max.X + m_position.X, m_shape.Height * m_scale / 2 * m_aabb.Max.Y + m_position.Y);
                return ret;
            }
            set
            {
                m_aabb = value;
            }
        }
        public Vector2 Position
        {
            get
            {
                return m_position;
            }
            set
            {
                m_position = value;
            }
        }
        public Vector2 LinearVelocity
        {
            get
            {
                return m_linearvel;
            }
            set
            {
                m_linearvel = value;
            }
        }
        public Vector2 Gravity
        {
            get
            {
                return m_gravity;
            }
            set
            {
                m_gravity = value;
            }
        }
        public float AngularVelocity
        {
            get
            {
                return m_angularvel;
            }
            set
            {
                m_angularvel = value;
            }
        }
        public float Rotation
        {
            get
            {
                return m_rotation;
            }
            set
            {
                m_rotation = value;
            }
        }
        public float Scale
        {
            get
            {
                return m_scale;
            }
            set
            {
                m_scale = value;
            }
        }
        public float Mass
        {
            get
            {
                return m_mass;
            }
            set
            {
                m_mass = value;
            }
        }
        public float Restitution
        {
            get
            {
                return m_restitution;
            }
            set
            {
                m_restitution = value;
            }
        }
        

        public RigidBody(Texture2D tex)
        {
            m_shape = new DeltaShape(tex);
            m_position = new Vector2(0, 0);
            m_drawoffset = new Vector2(tex.Width / 2, tex.Height / 2);
            m_linearvel = new Vector2(0, 0);
            m_gravity = new Vector2(0, 0);
            m_angularvel = 0.0f;
            m_rotation = 0.0f;
            m_scale = 1.0f;
            m_mass = 1.0f;
            m_aabb = new AABB(new Vector2(-1, -1), new Vector2(1, 1));
        }

        public void stepTime(float elapsedTime)
        {
            if (m_mass != 0.0f)
            {
                Vector2 newpos = m_position + m_linearvel * elapsedTime + 0.5f * m_gravity * elapsedTime * elapsedTime;
                m_position = newpos;
                m_linearvel += m_gravity * elapsedTime;
            }
            if (m_angularvel != 0.0f)
            {
                m_rotation += m_angularvel;
                // Recalculate AABB

            }
        }

        public void draw(ref SpriteBatch sb)
        {
            sb.Draw(m_shape.Texture, m_position - m_drawoffset*m_scale, null, Color.White, m_rotation, Vector2.Zero, m_scale, SpriteEffects.None, 0);

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