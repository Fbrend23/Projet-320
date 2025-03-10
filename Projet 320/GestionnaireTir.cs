////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Gère le système de tir, y compris la sélection de l'angle et de la puissance
// Module: 320                                                
////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet_320
{
    /// <summary>
    /// Gère le système de tir du jeu
    /// Permet aux joueurs de choisir un angle et une puissance via une interface en console
    /// Affiche graphiquement l'arc de visée et la barre de puissance
    /// </summary>
    internal class GestionnaireTir
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Angle minimum sélectionnable pour le tir
        /// </summary>
        private int _angleMin;

        /// <summary>
        /// Angle maximum sélectionnable pour le tir
        /// </summary>
        private int _angleMax;

        /// <summary>
        /// Puissance minimale du tir
        /// </summary>
        private int _powerMin = 0;

        /// <summary>
        /// Puissance maximale du tir
        /// </summary>
        private int _powerMax = 100;

        /// <summary>
        /// Caractère représentant le point de visée sur l'arc
        /// </summary>
        private string _shootPoint = "·";

        /// <summary>
        /// Position de l'interface de tir dans la console
        /// </summary>
        private Position _position;

        /// <summary>
        /// Angle actuellement sélectionné pour le tir
        /// </summary>
        private int _angle;

        /// <summary>
        /// Puissance actuellement sélectionnée pour le tir
        /// </summary>
        private int _power;

        /// <summary>
        /// Position X précédente du point de visée pour effacer son ancien affichage
        /// </summary>
        private int _prevX = -1;

        /// <summary>
        /// Position Y précédente du point de visée pour effacer son ancien affichage
        /// </summary>
        private int _prevY = -1;

        /// <summary>
        /// Indique si l'interface doit être en mode miroir pour le joueur 2
        /// </summary>
        private bool _mirror;


        //*********** Propriétés ***********//

        /// <summary>
        /// Retourne l'angle actuellement sélectionné
        /// </summary>
        public int Angle
        {
            get
            {
                return _angle;
            }
        }

        /// <summary>
        /// Retourne la puissance actuellement sélectionnée
        /// </summary>
        public int Power
        {
            get
            {
                return _power;
            }
        }
        /// <summary>
        /// Retourne la position de l'interface
        /// </summary>
        public Position Position
        {
            get 
            {
                return _position;   
            } 
        }
        //*********** Constructeur ***********//

        /// <summary>
        /// Constructeur du gestionnaire de tir
        /// Initialise l'interface et ajuste les angles en fonction du joueur
        /// </summary>
        /// <param name="position">Position de l'interface dans la console</param>
        /// <param name="mirror">Indique si l'interface doit être inversée pour le joueur 2</param>
        public GestionnaireTir(Position position, bool mirror)
        {
            _position = position;
            _mirror = mirror;

            //Activation du mode mirroir si c'est le joueur 2
            if (_mirror == true)
            {
                _angleMin = 110;
                _angleMax = 150;
            }
            else
            {
                _angleMin = 30;
                _angleMax = 70;
            }
        }

        //*********** Méthodes ***********//

        /// <summary>
        /// Gère la sélection de l'angle de tir par le joueur
        /// Le joueur doit appuyer sur [Espace] pour valider son choix
        /// </summary>
        /// <returns>L'angle de tir sélectionné</returns>
        public int SelectAngle() 
        {
            int angle = _angleMin;
            int direction = 1; // 1 = droite, -1 = gauche
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Sélection de l'angle (Appuie sur [Espace] pour valider) :               "); // Beaucoup d'espace pour effacer le message de puissance
            while (true)
            {
                //debug
                Console.SetCursorPosition(0,1);
                Console.WriteLine(angle);

                Console.SetCursorPosition(0, 1);
                // Affichage de l'arc avec l'angle courant passé en paramètre
                TirDisplay(angle);

                // Attendre un peu pour un mouvement fluide
                Thread.Sleep(150);

                // Modifier l'angle dans la direction actuelle
                angle = angle + (direction * 5);

                // Change la direction si on atteint les limites
                if (angle >= _angleMax || angle <= _angleMin) 
                {
                    direction = direction * (-1);
                }

                // Lis la touche de l'utilisateur pour valider l'angle
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Spacebar)
                    {
                        break;
                    }
                }
            }
            return angle ;
        }


        /// <summary>
        /// Affiche l'arc de sélection de l'angle en console
        /// Efface également l'affichage précédent pour éviter un effet de traînée
        /// </summary>
        /// <param name="currentAngle">Angle actuellement sélectionné</param>
        public void TirDisplay(int currentAngle)
        {
            _angle = currentAngle;
            int arc = 4; // Arc du tir

            // Conversion de l'angle en radians
            double rad = currentAngle * Math.PI / 180.0;
            // Calcul des coordonnées du point sur l'arc
            int x = _position.X + (int)(arc * Math.Cos(rad));
            int y = _position.Y - (int)(arc * Math.Sin(rad));

            // Effacer le point précédent, si existant
            if (_prevX != -1 && _prevY != -1)
            {
                Console.SetCursorPosition(_prevX, _prevY);
                Console.Write(" ");
            }

            // Affiche le nouveau point en rouge
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(_shootPoint);
            Console.ResetColor();

            //Mémorise la position actuelle
            _prevX = x;
            _prevY = y;
        }


        /// <summary>
        /// Gère la sélection de la puissance de tir du joueur
        /// Affiche une barre de progression qui se remplit automatiquement
        /// Le joueur doit appuyer sur [Espace] pour valider son choix
        /// </summary>
        /// <returns>La puissance de tir sélectionnée</returns>
        public int SelectPower()
        {
            int barWidth = 20; // Largeur de la barre de progression
            _power = _powerMin; // Puissance de départ

            // Affichage de l'instruction
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Sélection de la puissance (Appuie sur [Espace] pour valider) : ");

            while (true)
            {

                // Positionner le curseur sur la ligne d'affichage de la barre 
                Console.SetCursorPosition(10, 8);

                // Construis la barre de progression
                int filled = (int)((double)_power / _powerMax * barWidth);
                string bar = "[" + new string('■', filled) + new string(' ', barWidth - filled) + "]";

                // Afficher la barre et le pourcentage de puissance
                Console.Write(bar + " " + _power + "%   ");
                Thread.Sleep(100);                 // Pause pour l'animation

                // Augmente la puissance progressivement
                _power += 5;
                if (_power > _powerMax)
                {
                    _power = _powerMax;
                }

                //Retourne à 0 si le joueur n'a pas appuyer sur espace
                if (_power == _powerMax) 
                {
                  _power = _powerMin;
                }

                // Vérifier si l'utilisateur appuie sur Espace
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Spacebar)
                    {
                        break;
                    }
                }
            }
            return _power;
        }
    }
}
