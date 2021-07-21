using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AsteroidsWinForms
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
