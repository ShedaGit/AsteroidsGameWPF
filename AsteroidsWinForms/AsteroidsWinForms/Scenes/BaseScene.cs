﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AsteroidsWinForms.Scenes
{
    public abstract class BaseScene : IScene, IDisposable
    {
        protected BufferedGraphicsContext _context;
        protected Form _form;
        public static BufferedGraphics Buffer;


        public static int Width { get; set; }
        public static int Height { get; set; }

        public virtual void Init(Form form)
        {
            _form = form;
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = _form.CreateGraphics();
            Width = _form.ClientSize.Width;
            Height = _form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));

            _form.KeyDown += SceneKeyDown;
        }

        public virtual void SceneKeyDown(object sender, KeyEventArgs e) { }

        public virtual void Draw() { }

        public virtual void Dispose()
        {
            Buffer = null;
            _context = null;
            _form.KeyDown -= SceneKeyDown;
        }
    }
}
