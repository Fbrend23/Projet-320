using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    internal class Hitbox
    {
        private int _height;
        private int _width;
        private Position _position;

        public Hitbox(int height, int width, Position position)
        {
            _height = height;
            _width = width;
            _position = position;
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }
        /// <summary>
        /// Regarde si une coordonée est à l'intérieur une hitbox
        /// </summary>
        /// <param name="x">position x</param>
        /// <param name="y">position y</param>
        /// <returns>True si y a collision</returns>

        public bool isTouched(int x, int y)
        {
            return (x >= Position.X && x < Position.X + Width &&
                    y >= Position.Y && y < Position.Y + Height);
        }
    }
}
