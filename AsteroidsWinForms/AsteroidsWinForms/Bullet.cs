using AsteroidsWinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsWinForms
{
    class Bullet : BaseObject
    {
        private Bitmap _bitmap;

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _bitmap = Resources.laserRed1;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_bitmap, Pos.X, Pos.Y);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
        }

        public void Explosion()
        {
            var rand = new Random();
            Pos.X = 0;
            //Поправка на Size чтобы пуля нормально отображалась
            Pos.Y = rand.Next(0 + Size.Height, Game.Height - Size.Height);
        }
    }
}
