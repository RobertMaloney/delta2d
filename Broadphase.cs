#if !DELTA2D_BROADPHASE
#define DELTA2D_BROADPHASE

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    struct Manifold
    {
        RigidBody A, B;
        float penetrationDepth;
        Vector2 normal;
    }

    public class Broadphase
    {
        private AABBTreeNode root;
        private List<RigidBody> m_rigids;

        public Broadphase()
        {
            root = new AABBTreeNode();
            m_rigids = new List<RigidBody>();
        }

        public void addRigidBody(RigidBody rb)
        {
            m_rigids.Add(rb);
        }

        public void draw(ref SpriteBatch sb)
        {
            //root.draw(ref sb);
            foreach (RigidBody rb in m_rigids)
            {
                rb.draw(ref sb);
            }
        }

        public void stepTime(float elapsedTime)
        {
            // Collision Detection!
            foreach (RigidBody rb in m_rigids) rb.stepTime(elapsedTime);

            // Detect collision pairs
            Dictionary<RigidBody,List<RigidBody>> collisions = new Dictionary<RigidBody,List<RigidBody>>();
            for (int i = 0; i < m_rigids.Count - 1; ++i)
            {
                for (int j = i + 1; j < m_rigids.Count; ++j)
                {
                    RigidBody one = m_rigids.ElementAt(i);
                    RigidBody two = m_rigids.ElementAt(j);
                    if (one.AABB.intersects(two.AABB))
                    {
                        if (!collisions.ContainsKey(one)) collisions[one] = new List<RigidBody>();
                        if (!collisions.ContainsKey(two)) collisions[two] = new List<RigidBody>();

                        collisions[one].Add(two);
                        collisions[two].Add(one);
                    }
                }
            }

            foreach (KeyValuePair<RigidBody,List<RigidBody>> pair in collisions) {
                if (pair.Key.Mass != 0.0f) pair.Key.LinearVelocity = new Vector2(0.0f, -100.0f);

            }
        }
    }
}

#endif