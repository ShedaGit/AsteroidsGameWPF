using AsteroidsWinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsWinForms
{
    class Star : Asteroid
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size) { }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(new Bitmap(Resources.star3, new Size(Size.Width, Size.Height)), Pos.X, Pos.Y);
        }
    }
}
