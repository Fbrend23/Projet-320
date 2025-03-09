////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description:Permet de gérer les collisions en représentant un rectangle depuis une position. 
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
     /// Définit une zone rectangulaire utilisée pour la détection des collisions
     /// Permet de savoir si un point donné se trouve à l'intérieur de la hitbox (rectangle)
     /// </summary>
    internal class Hitbox
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Stocke la hauteur de la hitbox
        /// </summary>
        private int _height;

        /// <summary>
        /// Stocke la largeur de la hitbox
        /// </summary>
        private int _width;

        /// <summary>
        /// Stocke la position de la hitbox (coin supérieur gauche)
        /// </summary>
        private Position _position;


        //*********** Propriétés ***********//

        /// <summary>
        /// Obtient ou modifie la hauteur de la hitbox
        /// </summary>
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// Obtient ou modifie la largeur de la hitbox
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// Obtient ou modifie la position de la hitbox
        /// </summary>
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        //*********** Constructeur ***********//
        /// <summary>
        /// Initialise une hitbox avec une hauteur, une largeur et une position
        /// </summary>
        /// <param name="height">Hauteur de la hitbox</param>
        /// <param name="width">Largeur de la hitbox</param>
        /// <param name="position">Position de la hitbox dans la console</param>
        public Hitbox(int height, int width, Position position)
        {
            _height = height;
            _width = width;
            _position = position;
        }

        //*********** Méthodes ***********//

        /// <summary>
        /// Vérifie si une coordonnée se trouve à l'intérieur de la hitbox
        /// </summary>
        /// <param name="x">Coordonnée X du point à tester</param>
        /// <param name="y">Coordonnée Y du point à tester</param>
        /// <returns>Retourne true si la coordonnée est dans la hitbox, sinon false</returns>

        public bool isTouched(int x, int y)
        {
            return (x >= Position.X && x < Position.X + Width &&
                    y >= Position.Y && y < Position.Y + Height);
        }
    }
}
