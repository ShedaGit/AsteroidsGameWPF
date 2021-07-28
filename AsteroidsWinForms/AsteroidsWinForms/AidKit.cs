using AsteroidsWinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsteroidsWinForms
{
    class AidKit : BaseObject
    {
        private readonly Bitmap _bitmap;

        public AidKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _bitmap = Resources.AidKit;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_bitmap, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
