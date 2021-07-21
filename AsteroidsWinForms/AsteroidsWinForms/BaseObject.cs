using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsteroidsWinForms
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public Rectangle Rect => new Rectangle(Pos, Size);

        public bool Collision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        public abstract void Draw();

        public abstract void Update();
    }
}
