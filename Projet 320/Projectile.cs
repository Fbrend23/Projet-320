using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{///
    internal class Projectile
    {
        /// <summary>
        /// Gère la trajectoire,la position et les collisions du projectile
        /// </summary>

        public int _angle;
        public int _power;
        //*********** Propriétés ***********//
        private string _projectile;
        private Position _position;

        public int Angle
        {
            get { return _angle; }
        }

        public int Power
        {
            get { return _power; }
    }
}
