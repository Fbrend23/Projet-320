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
        //*********** Propriétés ***********//
        private int _angleMin = 0;
        private int _angleMax = 90;
        private int _powerMin = 0;
        private int _powerMax = 100;
        private string _shootPoint = "·";
        private Position _position;
        private int _angle;

        private int _prevX = -1;
        private int _prevY = -1;

        public Interface_tir(Position position)
        {

            _position = position;
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
            Console.WriteLine("Sélection de l'angle (Appuie sur [Espace] pour valider) : ");


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



        public int SelectPower()
        {
            int barWidth = 20;
            int power = _powerMin;
            // Affichage de l'instruction sur une ligne dédiée
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Sélection de la puissance (Appuie sur [Espace] pour valider) : ");

            while (true)
            {

                // Positionner le curseur sur la ligne d'affichage de la barre 
                Console.SetCursorPosition(2, 4);
                // Calculer le nombre de caractères à remplir en fonction de la puissance actuelle
                int filled = (int)((double)power / _powerMax * barWidth);
                // Construire la barre : encadrée par [ et ], remplie par '#' et des espaces pour le reste
                string bar = "[" + new string('█', filled) + new string(' ', barWidth - filled) + "]";
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
