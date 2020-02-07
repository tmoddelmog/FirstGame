using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameWindowsStarter
{
    public struct BoundingRectangle
    {
        /*
            distance of circles collision check
            (a.r + b.r) ^ 2 <= (a.center.x - b.center.x) ^ 2 + (a.center.y - b.center.y) ^ 2

             r.x <= p.x <= r.x + r.width
             r.y <= p.y <= r.y + r.width
             r ^ 2 >= (r.x - p.x) ^ 2 + (r.y - p.y) ^ 2
             nearstx = clamp(c.x, r.x, r.x + r.width)
             nearsty = clamp(c.y, r.y, r.y + r.height)
             clamp() if outside of range clamp to that edge else keep in spot
         */

        public float X, 
                     Y,
                     Width,
                     Height;

        public BoundingRectangle(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public static implicit operator Rectangle(BoundingRectangle br)
        {
            return new Rectangle(
                (int)br.X,
                (int)br.Y, 
                (int)br.Width, 
                (int)br.Height
           );
        }
    }
}
