﻿using AsteroidsWinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidsWinForms
{
    static class Game
    {
        static BaseObject[] _asteroids;
        static BaseObject[] _stars;
        static Bullet _bullet;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 60 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(new Bitmap(Resources.background, new Size(800, 500)), 0, 0);

            foreach (BaseObject star in _stars)
                star.Draw();

            Buffer.Graphics.DrawImage(new Bitmap(Resources.planet, new Size(200, 200)), 100, 100);

            foreach (BaseObject asteroid in _asteroids)
                asteroid.Draw();

            _bullet.Draw();

            Buffer.Render();
        }

        public static void Update()
        {

            foreach (BaseObject star in _stars)
                star.Update();

            foreach (BaseObject asteroid in _asteroids)
            {
                asteroid.Update();
                if (asteroid.Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _bullet.Explosion();
                }
            }

            _bullet.Update();
        }

        public static void Load()
        {
            var random = new Random();

            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(54, 9));

            _asteroids = new BaseObject[10];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(10, 50);
                var posX = random.Next(0, Width);
                var posY = random.Next(0, Height);
                var dirX = random.Next(5, 15);
                var dirY = random.Next(5, 15);
                _asteroids[i] = new Asteroid(new Point(posX, posY), new Point(dirX, dirY), new Size(size, size));
            }
            _stars = new BaseObject[20];
            for (int i = 0; i < _stars.Length; i++)
            {
                var size = random.Next(5, 15);
                var posX = random.Next(0, Width);
                var posY = random.Next(0, Height);
                var dirX = random.Next(5, 10);
                var dirY = random.Next(5, 10);
                _stars[i] = new Star(new Point(posX, posY), new Point(dirX, dirY), new Size(size, size));
            }
        }
    }
}