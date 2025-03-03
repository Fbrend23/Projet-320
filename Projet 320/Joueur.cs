using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    internal class Joueur
    {
        /// <summary>
        /// 
        /// </summary>
        //*********** Propriétés ***********//
        private string _nom;
        private bool _IsTurnActive;
        private int _vie;
        private Position _position;
        private Hitbox _hitbox;
        private readonly string[] joueurDisplay =
        {
            @" o ",
            @"/|\",
            @"/ \",
        };
       
        public Hitbox HitBox
        {
            get { return _hitbox; }
            set { _hitbox = value; }
        }


        /// <summary>
        /// Cnstructeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="isTurnActive"></param>
        public Joueur(string nom, bool isTurnActive, int vie, Position position)
        {
            _nom = nom;
            _IsTurnActive = isTurnActive;
            _vie = vie;
            _position = position;
            _hitbox = new Hitbox(3, 3, _position);
        }



        /// <summary>
        /// Affichage des joueurs
        /// </summary>
        public void AffichageJoueur()
        {
            Console.SetCursorPosition(_position.X, Config.SCREEN_HEIGHT - _position.Y);
            
            for (int i = 1; i <= joueurDisplay.Length; i++)
            { 
                Console.WriteLine(joueurDisplay[i-1]);
                Console.SetCursorPosition(_position.X, Config.SCREEN_HEIGHT - _position.Y + i);
            }
        }
    }
}
