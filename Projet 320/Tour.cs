////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Représente les tours avec leur position, leur hitbox et les dégats
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
    internal class Tour
    {
        //*********** Propriétés ***********//

        private string _bloc = "█";     //Block représentant la tour
        private Position _position;
        private int _largeur;           //Largeur de la tour
        private int _hauteur;           //Hauteur de la tour
        private string[,] _tourArray;   //Tableau pour la tour
        private Hitbox _hitbox;

        public Hitbox Hitbox
        {
            get { return _hitbox; }
            set { _hitbox = value; }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="largeur"></param>
        /// <param name="hauteur"></param>
        /// <param name="position"></param>
        public Tour(int largeur, int hauteur, Position position)
        {
            _largeur = largeur;
            _hauteur = hauteur;
            _position = position;
            _tourArray = new string[hauteur, largeur];
            _hitbox = new Hitbox(_hauteur, _largeur, _position);
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
            Console.SetCursorPosition(_position.X,_position.Y);
            for (int i = 0; i < _hauteur; i++)
            {
                Console.SetCursorPosition(_position.X, _position.Y + i);
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
            //todo
        }
    }
}
