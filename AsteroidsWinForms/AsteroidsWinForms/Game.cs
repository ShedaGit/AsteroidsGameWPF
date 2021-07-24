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
        static BaseObject[] _asteroids;
        static BaseObject[] _stars;
        static Bullet _bullet;
        static Ship _ship;
        static Timer timer;
        static Random random = new Random();
        private static int _score = 0;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Bitmap _backgroundBitmap;
        private static Bitmap _planetBitmap;

        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game() { }

        public static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            if (form.ClientSize.Width < 1000 & form.ClientSize.Width > 0 || 
                form.ClientSize.Height < 1000 & form.ClientSize.Height > 0)
            {
                Width = form.ClientSize.Width;
                Height = form.ClientSize.Height;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Client window size doesn't match requirements: Width and Height should be in range from 0 to 1000");
            }
            
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            form.KeyDown += OnFormKeyDown;

            timer = new Timer { Interval = 60 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) _ship.MoveUp();
            if (e.KeyCode == Keys.Down) _ship.MoveDown();
            if (e.KeyCode == Keys.ControlKey)
            {
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 21), new Point(25, 0), new Size(54, 9));
            }
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(_backgroundBitmap, 0, 0, 800, 500);

            foreach (BaseObject star in _stars)
                star.Draw();

            Buffer.Graphics.DrawImage(_planetBitmap, 100, 100, 200, 200);

            foreach (BaseObject asteroid in _asteroids)
                if (asteroid != null) asteroid.Draw();

            if (_bullet != null)
            {
                _bullet.Draw();
            }

            _ship.Draw();
            Buffer.Graphics.DrawString($"Energy: {_ship.Energy}", SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Graphics.DrawString($"Score: {_score}", SystemFonts.DefaultFont, Brushes.White, 0, 20);

            Buffer.Render();
        }

        public static void Update()
        {

            foreach (BaseObject star in _stars)
                star.Update();

            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;

                _asteroids[i].Update();

                //Столкновение пули с астероидом
                if (_bullet != null && _asteroids[i].Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    //Можно ли как то занулить класс в методе?
                    //_bullet.Explosion();
                    _asteroids[i] = null;
                    _bullet = null;
                    _score++;
                    continue;
                }

                //Столкновение корабля с астероидом
                if (_ship.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    _ship.DecreaseEnergy(random.Next(15, 25));
                    //Чтобы астероид не "ел" энергию на каждом кадре, он разрушается о корабль
                    _asteroids[i] = null;
                }
            }

            if (_bullet != null)
            {
                _bullet.Update();
            }
        }

        public static void Load()
        {
            _backgroundBitmap = Resources.background;
            _planetBitmap = Resources.planet;

            _ship = new Ship(new Point(10, Height / 2), new Point(0, 5), new Size(45, 50));
            _ship.Die += OnShipDie;

            _asteroids = new BaseObject[10];
            for (int i = 0; i < _asteroids.Length; i++)
            {
                var size = random.Next(25, 50);
                var posX = random.Next(0, Width);
                var posY = random.Next(0, Height);
                var dirX = random.Next(5, 10);
                var dirY = random.Next(5, 10);
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

        private static void OnShipDie(object sender, ShipDieEventArgs e)
        {
            timer.Stop();
            Buffer.Graphics.DrawString("Game over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), Brushes.White, 190, 100);
            Buffer.Graphics.DrawString($"Last damage: {e.Damage}", new Font(FontFamily.GenericSansSerif, 30, FontStyle.Bold), Brushes.White, 250, 200);
            Buffer.Render();
        }
    }
}
