////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Gère l'affichage du score en fonction des joueurs et de leurs vies restantes
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
    /// Affiche et met à jour le score des joueurs
    /// Utilise la position du joueur et affiche visuellement le nombre de vies restantes
    /// </summary>
    internal class Score
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Stocke le nombre de vies restantes du joueur
        /// </summary>
        private int _vie;

        /// <summary>
        /// Stocke la position de l'affichage du score dans la console
        /// </summary>
        private Position _position;

        /// <summary>
        /// Contient les lignes du tableau de score
        /// </summary>
        private string[] _score;

        /// <summary>
        /// Stocke la référence vers le joueur concerné
        /// </summary>
        private Joueur _joueur;

        /// <summary>
        /// Stocke le nom du joueur pour l'affichage
        /// </summary>
        private string _nomJoueur;


        //*********** Propriétés ***********//

        /// <summary>
        /// Retourne ou modifie le nombre de vies du joueur affiché dans le score
        /// </summary>
        public int Vie
        {
            set { _vie = value; }
        }


        //*********** Constructeur ***********//

        /// <summary>
        /// Initialise l'affichage du score pour un joueur donné
        /// </summary>
        /// <param name="position">Position où le score doit être affiché</param>
        /// <param name="joueur">Joueur associé au score</param>
        public Score(Position position, Joueur joueur)
        {
            _vie = joueur.Vie;
            _position = position;
            _joueur = joueur;
            _nomJoueur = joueur.Nom;
        }

        //*********** Méthodes ***********//

        /// <summary>
        /// Affiche le score du joueur en mettant à jour le nombre de vies restantes
        /// </summary>
        public void DisplayScore()
        {
            // Formate le nom et les cœurs pour assurer un bon alignement
            _nomJoueur = _joueur.Nom.PadRight(20);
            string _coeur = new string('♥', _joueur.Vie).PadRight(20);

            // Crée le tableau de score
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
