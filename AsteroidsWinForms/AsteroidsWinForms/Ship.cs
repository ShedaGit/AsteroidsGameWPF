using AsteroidsWinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsteroidsWinForms
{
    class Ship : BaseObject
    {
        private readonly Bitmap _ship;
        private int _energy = 100;
        public event EventHandler<ShipDieEventArgs> Die;
        public event Action Damaged;

        public int Energy { get => _energy; }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _ship = Resources.ship;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_ship, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
        }

        public void DecreaseEnergy(int damage)
        {
            _energy -= damage;
            //Решил немного переработать логику вызова события смерти корабля
            if (_energy < 0)
            {
                ShipDeath(damage);
            }
        }

        public void IncreaseEnergy(int heal)
        {
            _energy += heal;
        }

        //Попробовал другой способ вызова события
        public void ShipDamaged()
        {
            Damaged?.Invoke();
        }

        //Вынес вызов события смерти в отдельный метод, что отделить смерть и уменьшение энергии
        private void ShipDeath(int damage)
        {
            if (Die != null)
            {
                Die?.Invoke(this, new ShipDieEventArgs(damage));
            }
        }

        public void MoveUp()
        {
            if (Pos.Y > Dir.Y) Pos.Y -= Dir.Y;
        }

        public void MoveDown()
        {
            //Поправка на Dir.Y чтобы не выйти за границы рабочей области
            if (Pos.Y < Game.Height - Dir.Y) Pos.Y += Dir.Y;
        }
    }
}
