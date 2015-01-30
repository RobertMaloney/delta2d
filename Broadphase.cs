#if !DELTA2D_BROADPHASE
#define DELTA2D_BROADPHASE

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
    struct AABBTreeNode
    {
        AABB bound;
        AABBTreeNode left, right;
        RigidBody leaf;

        public void draw(ref SpriteBatch sb)
        {
            if (leaf != null) leaf.draw(ref sb);
            else
            {
                if (!left.Equals(null)) left.draw(ref sb);
                if (!right.Equals(null)) right.draw(ref sb);
            }
        }
    }
    public class Broadphase
    {
        private AABBTreeNode root;

        public Broadphase()
        {
            root = new AABBTreeNode();
        }

        public void addRigidBody(RigidBody rb)
        {

        }

        public void draw(ref SpriteBatch sb)
        {
            root.draw(ref sb);
        }

        public void stepTime(float elapsedTime)
        {

        }
    }
}

#endif