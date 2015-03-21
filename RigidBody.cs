#if !DELTA2D_RIGIDBODY
#define DELTA2D_RIGIDBODY

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace delta2d
{
    public class Rigidbody
    {
        private DeltaShape m_shape;
        private Vector2 m_position;
        private Vector2 m_linearvel;
        private Vector2 m_gravity;
        private float m_angularvel;
        private float m_rotation;
        private float m_scale;
        private float m_mass;
        private float m_restitution;

        public AABB AABB
        {
            get
            {
                AABB shapeBounds = m_shape.AABB * m_scale;
                return new AABB(m_position + shapeBounds.Min, m_position + shapeBounds.Max);
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
        

        public Rigidbody(DeltaShape collisionShape)
        {
            m_shape = collisionShape;
            m_position = new Vector2(0, 0);
            m_linearvel = new Vector2(0, 0);
            m_gravity = new Vector2(0, 0);
            m_angularvel = 0.0f;
            m_rotation = 0.0f;
            m_scale = 1.0f;
            m_mass = 1.0f;
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
            }
        }

        //public void draw(ref SpriteBatch sb)
        //{
        //    sb.Draw(m_shape.Texture, m_position - m_drawoffset*m_scale, null, Color.White, m_rotation, Vector2.Zero, m_scale, SpriteEffects.None, 0);

        //    Texture2D pixel = new Texture2D(sb.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
        //    pixel.SetData(new Color[] { Color.White });

        //    sb.Draw(pixel, new Rectangle((int)(m_position.X - m_drawoffset.X * m_scale), (int)(m_position.Y - m_drawoffset.Y * m_scale), 1, (int)(m_drawoffset.Y * 2 * m_scale)), Color.Red);
        //    sb.Draw(pixel, new Rectangle((int)(m_position.X - m_drawoffset.X * m_scale), (int)(m_position.Y - m_drawoffset.Y * m_scale), (int)(m_drawoffset.X * 2 * m_scale), 1), Color.Red);
        //    sb.Draw(pixel, new Rectangle((int)(m_position.X + m_drawoffset.X * m_scale), (int)(m_position.Y - m_drawoffset.Y * m_scale), 1, (int)(m_drawoffset.Y * 2 * m_scale)), Color.Red);
        //    sb.Draw(pixel, new Rectangle((int)(m_position.X - m_drawoffset.X * m_scale), (int)(m_position.Y + m_drawoffset.Y * m_scale), (int)(m_drawoffset.X * 2 * m_scale), 1), Color.Red);
        //}
    }
}

#endif