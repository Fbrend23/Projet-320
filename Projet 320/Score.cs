////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Permet l'affichage du score selon les joueurs touchés
// Module: 320                                                
////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    internal class Score
    {
		private int _vie;
		private Position _position;
        private string[] _score;
        private Joueur _joueur;
        private string _nomJoueur;
		public int Vie
		{
			get { return _vie; }
			set { _vie = value; }
		}

        public Score(Position position, Joueur joueur)
        {
            _vie = joueur.Vie;
            _position = position;
            _joueur = joueur;
            _nomJoueur = joueur.Nom;
        }

       public void DisplayScore()
        {
            _nomJoueur = _joueur.Nom.PadRight(20);
            string _coeur = new string('♥', _vie).PadRight(20);
            _score = new string[]
            {
               "╔══════════════════════╗",
              $"║ {_nomJoueur} ║",
              $"║ {_coeur} ║",
               "╚══════════════════════╝"
            };

            //Affiche le score
            for (int i = 0; i < _score.Length; i++)
            {
                Console.SetCursorPosition(_position.X, _position.Y + i);
                Console.WriteLine(_score[i]);
            }
        }


    }
}
