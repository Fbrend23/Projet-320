using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    internal class Tour
    {
        //*********** Propriétés ***********//

        private string _bloc; //Block représentant la tour
        private string[] _tourDisplay = new string[15];

        public Tour(string bloc)
        {
            _bloc = bloc;
        }

        /// <summary>
        /// Affiche la tour
        /// </summary>
        /// <param name="setPositionX"></param>
        public void AffichageTour(int setPositionX)
        {
            //Remplissage du tableau avec un █
            for (int i = 0; i < _tourDisplay.GetLength(0); i++)
            {
                _tourDisplay[i] = _bloc;
            }

            //Affichage de la tour
            Console.SetCursorPosition(setPositionX, Config.SCREEN_HEIGHT - 2);
            for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(setPositionX, Config.SCREEN_HEIGHT - 2 +i);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_tourDisplay[i]);
                }
                Console.WriteLine();
            }
        }

        public void 
    }
}
