using AsteroidsWinForms.Properties;
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
        private static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer;
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Asteroid[] asteroids;
        static Asteroid[] stars;

        public static void Init(Form form)
        {
            context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Load();

            Timer timer = new Timer();
            timer.Interval = 60;
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            //Добавляем в отрисовку фон и планету
            Buffer.Graphics.DrawImage(Resources.background, new Rectangle(0, 0, 800, 500));
            Buffer.Graphics.DrawImage(Resources.planet, new Rectangle(100, 100, 200, 200));
            
            
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw();
            }

            foreach (var star in stars)
            {
                star.Draw();
            }
            
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (var asteroid in asteroids)
            {
                asteroid.Update();
            }

            foreach (var star in stars)
            {
                star.Update();
            }
        }

        public static void Load()
        {
            var random = new Random();
            asteroids = new Asteroid[15];
            for (int i = 0; i < asteroids.Length; i++)
            {
                var size = random.Next(10, 40);
                asteroids[i] = new Asteroid(new Point(600, i * 20 + 5), new Point(-i, -i), new Size(size, size));
            }

            stars = new Asteroid[20];
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star(new Point(600, i * 40 + 5), new Point(-i, -i), new Size(5, 5));
            }
        }
    }
}
