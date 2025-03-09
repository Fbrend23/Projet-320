////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Représente les joueurs avec leur nombre de vies, position et leur hitbox 
// Module: 320                                                
////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    /// <summary>
    /// Gère les informations et l'affichage des joueurs
    /// Stocke le nom, le nombre de vies, la position et la hitbox du joueur
    /// </summary>
    internal class Joueur
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Stocke le nom du joueur
        /// </summary>
        private string _nom;

        /// <summary>
        /// Indique si c'est actuellement le tour du joueur
        /// </summary>
        private bool _IsTurnActive;

        /// <summary>
        /// Stocke le nombre de vies restantes du joueur
        /// </summary>
        private int _vie;

        /// <summary>
        /// Stocke la position du joueur dans la console
        /// </summary>
        private Position _position;

        /// <summary>
        /// Stocke la hitbox du joueur pour la détection des collisions
        /// </summary>
        private Hitbox _hitbox;

        /// <summary>
        /// Contient la représentation graphique du joueur sous forme de tableau de chaînes
        /// </summary>
        private readonly string[] joueurDisplay =
        {
            @" o ",
            @"/|\",
            @"/ \",
        };

        //*********** Propriétés ***********//

        /// <summary>
        /// Retourne le nom du joueur
        /// </summary>
        public string Nom
        {
            get { return _nom; }
        }

        /// <summary>
        /// Retourne le nombre de vies restantes du joueur
        /// </summary>
        public int Vie
        {
            get { return _vie; }
        }

        /// <summary>
        /// Retourne ou modifie la hitbox du joueur
        /// </summary>
        public Hitbox HitBox
        {
            get { return _hitbox; }
            set { _hitbox = value; }
        }

        //*********** Constructeur ***********//

        /// <summary>
        /// Initialise un joueur avec un nom, un état de tour actif, un nombre de vies et une position
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="isTurnActive">Détermine si c'est son tour</param>
        /// <param name="vie">Nombre de vies initiales</param>
        /// <param name="position">Position initiale du joueur</param>
        public Joueur(string nom, bool isTurnActive, int vie, Position position)
        {
            _nom = nom;
            _IsTurnActive = isTurnActive;
            _vie = vie;
            _position = position;
            _hitbox = new Hitbox(3, 3, _position);
        }

        //*********** Méthodes ***********//

        /// <summary>
        /// Affiche le joueur à sa position actuelle dans la console
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

        /// <summary>
        /// Réduit le nombre de vies du joueur lorsqu'il subit des dégâts
        /// </summary>
        public int TakeDamage()
        {
            _vie -= 1;
            return _vie;
        }
    }
}
