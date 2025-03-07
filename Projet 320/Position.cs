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
    internal class Position
    {
        //*********** Propriétés ***********//
        private int _x;
        private int _y;

        public int X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }



        /// <summary>
        /// Calcule la distance entre deux positions.
        /// </summary>
        /// <param name="other">L'autre position</param>
        /// <returns>La distance sous forme de double</returns>
        public double DistanceTo(Position other)
        {
            int deltaX = other.X - this.X;
            int deltaY = other.Y - this.Y;
            return Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
        }

    }
}
