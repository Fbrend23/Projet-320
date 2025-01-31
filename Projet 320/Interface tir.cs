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

        public Interface_tir(Position position)
        {

            _position = position;
        }

        public void DisplayShoot()
        {
           
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
            Console.WriteLine("→ Sélection de l'angle (Appuie sur [Espace] pour valider) :");

            while (true)
            {
                Console.SetCursorPosition(0, 1);
                // Affichage de l'angle
                Console.Write($"Angle : {angle}° ");

                // Attendre un peu pour le mouvement fluide
                Thread.Sleep(100);

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
            return angle;
        }

        //public int SelectPower()
        //{
        //    return power;
        //}

        //public int TirDisplay()
        //{

        //}


    }
}
