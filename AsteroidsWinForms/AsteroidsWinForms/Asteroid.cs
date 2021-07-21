using AsteroidsWinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsWinForms
{
    class Asteroid : BaseObject
    {
        private int index;
        static Random r = new Random();
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            index = r.Next(1, 4);
        }

        override public void Draw()
        {
            switch (index)
            {
                case 1:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid1, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 2:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid2, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 3:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid3, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
                case 4:
                    Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.asteroid4, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
                    break;
            }
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}
