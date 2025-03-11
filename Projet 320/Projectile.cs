////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Représente un projectile lancé par le joueur
// Contient les paramètres de tir (Puissance, angle) et calcul sa trajectoire
// Module: 320                                                
////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    /// <summary>
    /// Gère le déplacement et l'affichage d'un projectile dans la console
    /// Utilise une trajectoire parabolique pour simuler le tir
    /// </summary>
    internal class Projectile
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Constante représentant la gravité utilisée dans le calcul de la trajectoire
        /// </summary>
        private const double _gravity = 9.81;

        /// <summary>
        /// Angle de tir du projectile en degrés
        /// </summary>
        private int _angle;

        /// <summary>
        /// Puissance du tir utilisée pour déterminer la vitesse initiale
        /// </summary>
        private int _power;

        /// <summary>
        /// Position actuelle du projectile dans la console
        /// </summary>
        private Position _position;

        /// <summary>
        /// Caractère représentant visuellement le projectile dans la console
        /// </summary>
        private char _projectileChar;

        /// <summary>
        /// Temps écoulé depuis le lancement du projectile
        /// </summary>
        private double _time;

        /// <summary>
        /// Vitesse initiale du projectile en fonction de la puissance
        /// </summary>
        private double _initialVelocity;

        /// <summary>
        /// Position X précédente du projectile pour effacer l'ancien affichage
        /// </summary>
        private int _prevX = -1;

        /// <summary>
        /// Position Y précédente du projectile pour effacer l'ancien affichage
        /// </summary>
        private int _prevY = -1;

        /// <summary>
        /// Indique si le projectile est encore actif dans le jeu
        /// </summary>
        private bool _isActive;



        //*********** Propriétés ***********//

        /// <summary>
        /// Obtient l'angle du projectile
        /// </summary>
        public int Angle
        {
            get { return _angle; }
        }

        /// <summary>
        /// Obtient la puissance du projectile
        /// </summary>
        public int Power
        {
            get { return _power; }
        }

        /// <summary>
        /// Obtient ou définit la position du projectile
        /// </summary>
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Obtient ou définit si le projectile est actif
        /// </summary>
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        /// Obtient la dernière position X connue du projectile
        /// </summary>
        public int PrevX
        {
            get { return _prevX; }
        }

        /// <summary>
        /// Obtient la dernière position Y connue du projectile
        /// </summary>
        public int PrevY
        {
            get { return _prevY; }
        }

        //*********** Constructeur ***********//

        /// <summary>
        /// Initialise un projectile avec les paramètres de tir
        /// </summary>
        /// <param name="angle">Angle du tir en degrés</param>
        /// <param name="power">Puissance du tir</param>
        /// <param name="position">Position initiale du projectile</param>
        /// <param name="isActive">Indique si le projectile est actif</param>
        /// <param name="time">Temps écoulé depuis le tir</param>
        public Projectile(int angle, int power, Position position, bool isActive, double time)
        {
            _angle = angle;
            _power = power;
            _position = position;
            _isActive = isActive;
            _time = time;
            _initialVelocity = power / 6 ;
            _projectileChar = 'x';
        }

        //*********** Méthodes ***********//

        /// <summary>
        /// Met à jour la position du projectile en fonction du temps écoulé.
        /// Utilise les équations de mouvement parabolique :
        ///   x = x0 + v0 * cos(angle) * t
        ///   y = y0 - (v0 * sin(angle) * t - 0.5 * g * t^2)
        /// La soustraction pour "y" tient compte que dans la console, l'axe Y augmente vers le bas
        /// </summary>
        /// <param name="deltaTime">Temps écoulé depuis la dernière mise à jour (en secondes)</param>
        public void UpdateProjectile(double deltaTime)
        {
            _time += deltaTime;
            double rad = _angle * Math.PI / 180.0;
            int newX = _position.X + (int)(_initialVelocity * Math.Cos(rad) * _time);
            int newY = _position.Y - (int)((_initialVelocity * Math.Sin(rad) * _time) - (0.5 * _gravity * _time * _time));
            
            // Affichage de debogage temporaire
            Console.SetCursorPosition(80, 30);
            Console.Write($"X: {newX} Y: {newY}  ");

            _position = new Position(newX, newY);

            //Debug
            int windowWidth;
            int windowHeight;
            if (Environment.UserInteractive)
            {
                windowWidth = Console.WindowWidth;
                windowHeight = Console.WindowHeight;
            }
            else
            {
                // En environnement non interactif (tests unitaires), utiliser des valeurs par défaut
                windowWidth = Config.SCREEN_WIDTH;
                windowHeight = Config.SCREEN_HEIGHT;
            }
            //Fin debug

            // Si le projectile sort de la fenêtre ou "touche le sol", on le désactive.
            if (newY >= windowHeight || newX >= windowWidth || newX < 0)
            {
                _isActive = false;
            }
        }

        /// <summary>
        /// Affiche le projectile dans la console à sa position actuelle
        /// Efface également l'ancienne position pour simuler un déplacement
        /// </summary>
        public void DisplayProjectile()
        {
            if (_isActive)
            { 
            // Efface le point précédent, si existant
            if (_prevX != -1 && _prevY != -1)
                {
                    Console.SetCursorPosition(_prevX, _prevY);
                    Console.Write(" ");
                }
                try
                {
                    // Affiche le projectile à sa nouvelle position
                    Console.SetCursorPosition(_position.X, _position.Y);
                    Console.Write(_projectileChar);
                    // Mémorise la nouvelle position
                    _prevX = _position.X;
                    _prevY = _position.Y;
                }
                catch (ArgumentOutOfRangeException)
                {

                }
            }

            // Si le projectile n'est pas actif, efface la dernière position
            else if (_prevX != -1 && _prevY != -1)
            {
                Console.SetCursorPosition(_prevX, _prevY);
                Console.Write(" ");
            }
        }
     }
}


