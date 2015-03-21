#if !DELTA2D_BROADPHASE
#define DELTA2D_BROADPHASE

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace delta2d
{
    struct Manifold
    {
        public Rigidbody A, B;
        public float penetration;
        public Vector2 normal;
    };

    public class Broadphase
    {
        private AABBTreeNode root;
        private List<Rigidbody> m_rigids;

        public Broadphase()
        {
            root = new AABBTreeNode();
            m_rigids = new List<Rigidbody>();
        }

        public void addRigidBody(Rigidbody rb)
        {
            m_rigids.Add(rb);
        }

        //public void draw(ref SpriteBatch sb)
        //{
        //    //root.draw(ref sb);
        //    foreach (Rigidbody rb in m_rigids)
        //    {
        //        rb.draw(ref sb);
        //    }
        //}

        public void stepTime(float elapsedTime)
        {
            // Collision Detection!
            foreach (Rigidbody rb in m_rigids) rb.stepTime(elapsedTime);

            // Detect collision pairs
            Dictionary<Rigidbody,List<Rigidbody>> collisions = new Dictionary<Rigidbody,List<Rigidbody>>();
            for (int i = 0; i < m_rigids.Count - 1; ++i)
            {
                for (int j = i + 1; j < m_rigids.Count; ++j)
                {
                    Rigidbody one = m_rigids.ElementAt(i);
                    Rigidbody two = m_rigids.ElementAt(j);
                    if (one.AABB.intersects(two.AABB))
                    {
                        if (!collisions.ContainsKey(one)) collisions[one] = new List<Rigidbody>();

                        if (!collisions.ContainsKey(two) || !collisions[two].Contains(one)) collisions[one].Add(two);
                        //Console.WriteLine("Hit: ({0},{1}) and ({2},{3})", one.AABB.Min, one.AABB.Max, two.AABB.Min, two.AABB.Max);
                    }
                }
            }

            foreach (KeyValuePair<Rigidbody,List<Rigidbody>> pair in collisions) {
                foreach (Rigidbody rb in pair.Value)
                {
                    Manifold man = perpixelCheck(pair.Key, rb);
                    
                    if (pair.Key.Mass == 0.0f)
                    {
                        rb.LinearVelocity = Vector2.Zero;
                        continue;
                    }
                    else if (rb.Mass == 0.0f)
                    {
                        pair.Key.LinearVelocity = Vector2.Zero;
                        continue;
                    }
                }
            }
        }

        static Manifold perpixelCheck(Rigidbody a, Rigidbody b)
        {
            Manifold m = new Manifold();
            m.A = a;
            m.B = b;
            return m;
        }
    }
}

#endif