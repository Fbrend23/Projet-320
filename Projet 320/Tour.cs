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

        private string _bloc = "█";     //Block représentant la tour
        private int _positionX;         //Position par rapport à la largeur
        private int _positionY;         //Position par rapport à la hauteur
        private int _largeur;           //Largeur de la tour
        private int _hauteur;           //Hauteur de la tour
        private string[,] _tourArray;   //Tableau pour la tour



       /// <summary>
       /// Constructeur
       /// </summary>
       /// <param name="largeur"></param>
       /// <param name="hauteur"></param>
       /// <param name="positionX"></param>
       /// <param name="positionY"></param>
        public Tour( int largeur, int hauteur,int positionX, int positionY)
        {
            _largeur = largeur;
            _hauteur = hauteur;
            _positionX = positionX;
            _positionY = positionY;
            _tourArray = new string[hauteur, largeur];
        }
        
        /// <summary>
        /// Affichage de la tour
        /// </summary>
        public void AffichageTour()
        {
            //Remplissage du tableau avec un █
            for (int i = 0; i < _tourArray.GetLength(0); i++)
            {
                for(int j = 0; j < _tourArray.GetLength(1); j++)
                _tourArray[i,j] = _bloc;
            }

            //Affichage de la tour
            Console.SetCursorPosition(_positionX, _positionY);
            for (int i = 0; i < _hauteur; i++)
            {
                Console.SetCursorPosition(_positionX, _positionY + i);
                for (int j = 0; j < _largeur; j++)
                {
                    Console.Write(_tourArray[i, j]);
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Remplace les blocs de la tour s'ils sont touchés
        /// </summary>
        public void TourCollision()
        {

        }
    }
}
