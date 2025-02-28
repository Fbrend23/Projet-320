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
        private double _gravity = 9.81;
        private int _prevX = -1;
        private int _prevY = -1;


        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="power"></param>
        /// <param name="position"></param>
        /// <param name="isActive"></param>
        /// <param name="time"></param>
        public Projectile(int angle, int power, Position position, bool isActive, double time)
        {
            _angle = angle;
            _power = power;
            _position = position;
           _isActive = isActive;
            _time = time;
            _initialVelocity = power / 6 ;
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
        public void UpdateProjectile(double deltaTime)
        {
            
            _time += deltaTime;
            double rad = _angle * Math.PI / 180.0;
            int newX = _position.X + (int)(_initialVelocity * Math.Cos(rad) * _time);
            int newY = _position.Y - (int)((_initialVelocity * Math.Sin(rad) * _time) - (0.5 * _gravity * _time * _time));

            _position = new Position(newX, newY);

            // Si le projectile sort de la fenêtre ou "touche le sol", on le désactive.
            if (newY >= Console.WindowHeight || newX >= Console.WindowWidth || newX < 0)
            {
                _isActive = false;
            }
        }

        /// <summary>
        /// Affiche le projectile dans la console à sa position actuelle.
        /// </summary>
        public void DisplayProjectile()
        {
            if (_isActive)
            {

                // Effacer le point précédent, si existant
                if (_prevX != -1 && _prevY != -1)
                {
                    Console.SetCursorPosition(_prevX, _prevY);
                    Console.Write(" ");
                }
                try
                {
                    Console.SetCursorPosition(_position.X, _position.Y);
                    Console.Write("x");
                    _prevX = _position.X;
                    _prevY = _position.Y;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Si la position est hors écran, on peut ignorer l'affichage.
                    _isActive = false;
                }
            }
        }
    }

}
