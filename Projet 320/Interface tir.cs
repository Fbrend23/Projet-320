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
            Console.WriteLine("→ Sélection de l'angle (Appuie sur [Espace] pour valider) : ");

            while (true)
            {
                Console.SetCursorPosition(0, 1);
                // Affichage de l'angle
                Console.Write($"Angle : {angle}° ");

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
            int arc = 3; // Arc du tir

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

      

        //public int SelectPower()
        //{
        //    return power;
        //}



    }
}
