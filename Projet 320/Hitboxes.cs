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
        /// Regarde si y a collision entre 2 hitbox
        /// </summary>
        /// <returns></returns>
        public bool Collided()
        {
            return (_position.X < other.Position.X + other.Width 
                && _position.X + _width > other.Position.X 
                && _position.Y < other.Position.Y + other.Height 
                && _position.Y + _height > other.Position.Y);
        }
    }
}
