using System;
using System.Collections.Generic;
using System.Text;

namespace AsteroidsWinForms
{
    class ShipDieEventArgs : EventArgs
    {
        private int _damage;

        public int Damage { get => _damage; }

        public ShipDieEventArgs(int damage)
        {
            _damage = damage;
        }
    }
}
