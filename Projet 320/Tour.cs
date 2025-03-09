////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Représente une tour dans le jeu
// Définit ses dimensions, sa position et sa hitbox pour la détection des collisions
// Module: 320                                                
////////////////////////////////////////////////////////////////
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    /// <summary>
    /// Gère l'affichage et les propriétés des tours dans le jeu
    /// Les tours servent de protection et peuvent être détruites par les projectiles
    /// </summary>
    internal class Tour
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Bloc représentant la tour affichée dans la console.
        /// Utilisé pour construire visuellement la tour avec des caractères
        /// </summary>
        private string _bloc = "█";

        /// <summary>
        /// Position de la tour dans la console (coin supérieur gauche)
        /// </summary>
        private Position _position;

        /// <summary>
        /// Largeur de la tour en nombre de caractères
        /// </summary>
        private int _largeur;

        /// <summary>
        /// Hauteur de la tour en nombre de caractères
        /// </summary>
        private int _hauteur;

        /// <summary>
        /// Tableau 2D contenant la structure de la tour
        /// Utilisé pour stocker la représentation graphique de la tour avant affichage
        /// </summary>
        private string[,] _tourArray;

        /// <summary>
        /// Hitbox de la tour permettant la détection des collisions.
        /// </summary>
        private Hitbox _hitbox;


        //*********** Propriétés ***********//

        /// <summary>
        /// Propriété permettant d’accéder à la hitbox de la tour
        /// </summary>
        public Hitbox Hitbox
        {
            get { return _hitbox; }
            set { _hitbox = value; }
        }

        //*********** Constructeur ***********//

        /// <summary>
        /// Constructeur de la tour
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


        //*********** Méthodes ***********//

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
