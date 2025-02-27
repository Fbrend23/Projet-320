using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    internal class Projectile
    {
        /// <summary>
        /// Gère la trajectoire,la position et les collisions du projectile
        /// </summary>

        //*********** Propriétés ***********//
        public int _angle;
        public int _power;
        public Position _position;
        private string _projectile;
        private double _time;
        private double _initialVelocity;
        public bool _isActive;
        public Projectile(int angle, int power, Position position, bool isActive, double time)
        {
            _angle = angle;
            _power = power;
            _position = position;
           _isActive = isActive;
            _time = time;
            _initialVelocity = power;
        }

        public int Angle
        {
            get { return _angle; }
        }

        public int Power
        {
            get { return _power; }
        }

        /// <summary>
        /// Met à jour la position du projectile en fonction du temps écoulé.
        /// Utilise les équations de mouvement parabolique :
        ///   x = x0 + v0 * cos(angle) * t
        ///   y = y0 - (v0 * sin(angle) * t - 0.5 * g * t^2)
        /// La soustraction pour y tient compte que dans la console, l'axe Y augmente vers le bas.
        /// </summary>
        /// <param name="deltaTime">Temps écoulé depuis la dernière mise à jour (en secondes).</param>
        //public void Update(double deltaTime)
        //{
        //    _time += deltaTime;
        //    double rad = Angle * Math.PI / 180.0;
        //    int newX = _position.X + (int)(_initialVelocity * Math.Cos(rad) * _time);
        //    int newY = _position.Y - (int)((_initialVelocity * Math.Sin(rad) * _time) - (0.5 * Gravity * _time * _time));

        //    Position = new Position(newX, newY);

        //    // Si le projectile sort de la fenêtre ou "touche le sol", on le désactive.
        //    if (newY >= Console.WindowHeight || newX >= Console.WindowWidth || newX < 0)
        //    {
        //        IsActive = false;
        //    }
        //}
    }
}
