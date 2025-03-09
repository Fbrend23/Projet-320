////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Définis la localisation des objets (joueurs, tours, projectiles, etc.) 
// Module: 320                                                
////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    /// <summary>
    /// Représente une position en coordonnées X et Y dans l'espace de jeu
    /// Permet de stocker la position d'un objet et de calculer la distance entre deux positions
    /// </summary>
    internal class Position
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Stocke la coordonnée X de la position (largeur)
        /// </summary>
        private int _x;

        /// <summary>
        /// Stocke la coordonnée Y de la position (hauteur)
        /// </summary>
        private int _y;

        //*********** Propriétés ***********//

        /// <summary>
        /// Obtient ou modifie la coordonnée X de la position
        /// </summary>
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Obtient ou modifie la coordonnée Y de la position
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        //*********** Constructeur ***********//

        /// <summary>
        /// Initialise une position avec des coordonnées X et Y
        /// </summary>
        /// <param name="x">Coordonnée X</param>
        /// <param name="y">Coordonnée Y</param>
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        //*********** Méthodes ***********//

        /// <summary>
        /// Calcule la distance entre cette position et une autre position
        /// Utilise le théorème de Pythagore pour obtenir la distance euclidienne
        /// </summary>
        /// <param name="other">Position cible</param>
        /// <returns>Distance entre les deux positions sous forme de double</returns>
        public double DistanceTo(Position other)
        {
            int deltaX = other.X - this.X;
            int deltaY = other.Y - this.Y;
            return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
        }
    }
}
