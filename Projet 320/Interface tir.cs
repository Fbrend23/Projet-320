﻿////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Représente l'interface de tir du jeu.
// Permet d'intéragir et d'afficher graphiquement l'arc pour l'angle de tir ainsi que la barre de puissance
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
    internal class Interface_tir
    {
        //*********** Attributs ***********//
        private int _angleMin;              //Angle de tir min
        private int _angleMax;              //Angle de tir max
        private int _powerMin = 0;          //Puissance de tir min
        private int _powerMax = 100;        //Puissance de tir max
        private string _shootPoint = "·";   //Caractère de l'interface
        private Position _position;         //Position de l'interface
        private int _angle;                 //Angle de tir
        private int power;                  //Puissance de tir
        private int _prevX = -1;            //Position X précédente
        private int _prevY = -1;            //Position Y précédente
        private bool _mirror;


        //*********** Propriétés ***********//
        public int Angle
        {
            get
            {
                return _angle;
            }
        }

        public int Power
        {
            get
            {
                return power;
            }
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="position"></param>
        public Interface_tir(Position position, bool mirror)
        {
            _position = position;
            _mirror = mirror;

            //Activation du mode mirroir si c'est le joueur 2
            if (_mirror == true)
            {
                _angleMin = 90;
                _angleMax = 180;
            }
            else
            {
                _angleMin = 0;
                _angleMax = 90;
            }
        }
   

        /// <summary>
        /// Calcul de l'angle de tir
        /// </summary>
        /// <returns>int angle</returns>
        public int SelectAngle() 
        {
            int angle = _angleMin;
            int direction = 1; // 1 = droite, -1 = gauche
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Sélection de l'angle (Appuie sur [Espace] pour valider) :               "); // Beaucoup d'espace pour effacer le message de puissance


            while (true)
            {
                Console.SetCursorPosition(0, 1);
                // Affichage de l'angle pour test
                //Console.Write($"Angle : {angle}° ");

                // Affichage de l'arc avec l'angle courant passé en paramètre
                
                TirDisplay(angle);

                // Attendre un peu pour un mouvement fluide
                Thread.Sleep(150);

                // Changer l'angle
                angle = angle + (direction * 5);

                // Changer la direction si on atteint les limites
                if (angle >= _angleMax || angle <= _angleMin) 
                {
                    direction = direction * (-1);
                }

                // Lire la touche de l'utilisateur
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
        /// Affiche les points pour les angles
        /// </summary>
        /// <param name="currentAngle"></param>
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

            // Affiche le nouveau point en surbrillance
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(_shootPoint);
            Console.ResetColor();

            //Mémorise la position actuelle
            _prevX = x;
            _prevY = y;

        
            
        }


        /// <summary>
        /// Gère la puissance de tir et de son affichage
        /// </summary>
        /// <returns></returns>
        public int SelectPower()
        {
            int barWidth = 20;
            power = _powerMin;
            // Affichage de l'instruction sur une ligne dédiée
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Sélection de la puissance (Appuie sur [Espace] pour valider) : ");

            while (true)
            {

                // Positionner le curseur sur la ligne d'affichage de la barre 
                Console.SetCursorPosition(2, 4);
                // Calculer le nombre de caractères à remplir en fonction de la puissance actuelle
                int filled = (int)((double)power / _powerMax * barWidth);
                // Construire la barre : encadrée par [ et ], remplie par '■' et des espaces pour le reste
                string bar = "[" + new string('■', filled) + new string(' ', barWidth - filled) + "]";
                // Afficher la barre et le pourcentage de puissance
                Console.Write(bar + " " + power + "%   ");
                // Petite pause pour animer le remplissage
                Thread.Sleep(100);
                // Augmenter la puissance progressivement
                power += 5;

                if (power > _powerMax)
                {
                    power = _powerMax;
                }
                //Retourne à 0 si le joueur n'a pas appuyer sur espace
                if (power == _powerMax) 
                {
                  power = _powerMin;
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
            return power;
        }
    }
}
