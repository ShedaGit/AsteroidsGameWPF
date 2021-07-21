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
        private readonly Bitmap _bitmap;
        private int index;
        static Random r = new Random();
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            index = r.Next(1, 5);
            switch (index)
            {
                case 1:
                    _bitmap = Resources.asteroid1;
                    break;
                case 2:
                    _bitmap = Resources.asteroid2;
                    break;
                case 3:
                    _bitmap = Resources.asteroid3;
                    break;
                case 4:
                    _bitmap = Resources.asteroid4;
                    break;
            }
        }

        override public void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_bitmap, Pos.X, Pos.Y, Size.Width, Size.Height);
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
