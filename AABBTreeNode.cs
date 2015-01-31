#if !DELTA2D_AABBTREE
#define DELTA2D_AABBTREE

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
    public class AABBTreeNode
    {
        enum NodeType
        {
            MID,
            LEAF
        };

        protected AABB bounds;
        protected AABBTreeNode left;
        protected AABBTreeNode right;
        private RigidBody leaf;
        private NodeType nodetype;
        private int children;

        public AABBTreeNode()
        {
            bounds = new AABB();
            nodetype = NodeType.MID;
            children = 0;
        }

        public AABBTreeNode(RigidBody rb)
        {
            leaf = rb;
            bounds = rb.AABB;
            nodetype = NodeType.LEAF;
            children = 0;
        }

        public void draw(ref SpriteBatch sb)
        {
            if (nodetype == NodeType.MID)
            {
                if (left != null) left.draw(ref sb);
                if (right != null) right.draw(ref sb);
            }
            else
            {
                leaf.draw(ref sb);
            }
        }
    }
}

#endif