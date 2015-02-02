#if !DELTA2D_DELTAWORLD
#define DELTA2D_DELTAWORLD

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
    public class DeltaWorld
    {
        private Vector2 m_gravity;
        private List<RigidBody> m_rigids;
        private Broadphase m_broadphase;

        public DeltaWorld()
        {
            m_gravity = new Vector2(0.0f, 98.1f);
            m_rigids = new List<RigidBody>();
            m_broadphase = new Broadphase();
        }

        public void setGravity(Vector2 grav)
        {
            m_gravity = grav;
        }

        public Vector2 getGravity()
        {
            return m_gravity;
        }

        public void stepTime(float timeElapsed)
        {
            m_broadphase.stepTime(timeElapsed);
        }

        public void addRigidBody(RigidBody rb)
        {
            rb.Gravity = m_gravity;
            m_broadphase.addRigidBody(rb);
        }

        public void draw(ref SpriteBatch sb)
        {
            m_broadphase.draw(ref sb);
        }
    }
}

#endif