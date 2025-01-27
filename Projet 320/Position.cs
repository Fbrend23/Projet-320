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
        public int _x; //todo
        public int _y;

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
        /// Calcule la distance entre deux positions
        /// </summary>
        //private double Distance()
        //{
        //    //todo
        //}

    }
}
