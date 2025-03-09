////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Gère le moteur du jeu, initialise tous les objets et contrôle la partie
// Module: 320                                                
////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projet_320
{
    /// <summary>
    /// Gère l'initialisation des objets du jeu et orchestre la boucle principale
    /// Assure la gestion des tours des joueurs, des tirs et des collisions
    /// </summary>
    internal class Game
    {
        //*********** Attributs ***********//

        /// <summary>
        /// Représente le premier joueur
        /// </summary>
        private Joueur _joueur1;

        /// <summary>
        /// Représente le deuxième joueur
        /// </summary>
        private Joueur _joueur2;

        /// <summary>
        /// Représente la tour du premier joueur
        /// </summary>
        private Tour _tour1;

        /// <summary>
        /// Représente la tour du deuxième joueur
        /// </summary>
        private Tour _tour2;

        /// <summary>
        /// Gère l'interface de tir pour le premier joueur
        /// </summary>
        private GestionnaireTir _interfaceTirJ1;

        /// <summary>
        /// Gère l'interface de tir pour le deuxième joueur
        /// </summary>
        private GestionnaireTir _interfaceTirJ2;

        /// <summary>
        /// Contient les projectiles actuellement en jeu
        /// </summary>
        private List<Projectile> _projectiles;

        /// <summary>
        /// Indique si une collision a été détectée
        /// </summary>
        private bool _collisionDetected;

        /// <summary>
        /// Détermine quel joueur est en train de jouer
        /// </summary>
        private bool _isPlayer1Turn = true;

        /// <summary>
        /// Représente le score du premier joueur
        /// </summary>
        private Score _scoreJ1;

        /// <summary>
        /// Représente le score du deuxième joueur
        /// </summary>
        private Score _scoreJ2;

        /// <summary>
        /// Initialise tous les objets nécessaires au jeu
        /// Configure les joueurs, les tours, les interfaces de tir et le score
        /// </summary>
        public Game() 
        { 
            //Création des objets
            _joueur1 = new Joueur("J1", true, 3, new Position(10, 10));
            _joueur2 = new Joueur("J2", false, 3, new Position(Config.SCREEN_WIDTH - 10, 10));
            _tour1 = new Tour(3, 5, new Position(20, Config.SCREEN_HEIGHT - 12));
            _tour2 = new Tour(3, 5, new Position(Config.SCREEN_WIDTH - 20, Config.SCREEN_HEIGHT - 12));
            _interfaceTirJ1 = new GestionnaireTir(new Position(12, Config.SCREEN_HEIGHT - 12), false);
            _interfaceTirJ2 = new GestionnaireTir(new Position(Config.SCREEN_WIDTH - 10, Config.SCREEN_HEIGHT - 12),true);
            _projectiles = new List<Projectile>();
            _scoreJ1 = new Score(new Position(10,3),_joueur1);
            _scoreJ2 = new Score(new Position(Config.SCREEN_WIDTH - 50, 3), _joueur2);
        }

        /// <summary>
        /// Démarre la boucle du jeu et gère l'enchaînement des tours
        /// Affiche les éléments du jeu, gère les tirs et détecte les collisions
        /// </summary>
        public void RunGame()
        {
            // Configure la console pour le jeu
            Config.ConfigJeu();

            // Afficher les éléments du jeu
            _joueur1.AffichageJoueur();
            _tour1.AffichageTour();
            _joueur2.AffichageJoueur();
            _tour2.AffichageTour();

            while (true)
            {
                // Affiche les scores à chaque début de tour
                _scoreJ1.DisplayScore();
                _scoreJ2.DisplayScore();

                // Détermine quel joueur joue et gère son tir
                if (_isPlayer1Turn)
                {
                    int angle = _interfaceTirJ1.SelectAngle();
                    int power = _interfaceTirJ1.SelectPower();
                    Projectile projectile = new Projectile(angle, power, new Position(12, Config.SCREEN_HEIGHT - 12), true, 0);
                    _projectiles.Add(projectile);
                }
                else
                {
                    int angle = _interfaceTirJ2.SelectAngle();
                    int power = _interfaceTirJ2.SelectPower();
                    Projectile projectile = new Projectile(angle, power, new Position(Config.SCREEN_WIDTH - 12, Config.SCREEN_HEIGHT - 12), true, 0);
                    _projectiles.Add(projectile);
                }

                // Anime le projectile jusqu'à sa fin de vie
                while (_projectiles.Count > 0)
                {
                    // Parcourir une copie de la liste pour éviter de modifier la liste pendant l'itération
                    foreach (var proj in new List<Projectile>(_projectiles))
                    {
                        if (proj.IsActive)
                        {
                            proj.UpdateProjectile(0.05); // Simule 0,05 seconde d'écoulement
                            proj.DisplayProjectile();

                            // Vérifier la collision avec le joueur adverse selon le tour actuel
                            _collisionDetected = false;
                            if (_isPlayer1Turn)
                            {
                                // Si c'est le tour du joueur 1, le projectile vise le joueur 2
                                if (_joueur2.HitBox.isTouched(proj.Position.X, proj.Position.Y))
                                {
                                    _collisionDetected = true;
                                    _joueur2.TakeDamage();
                                    proj.IsActive = false;


                                    // Efface l'affichage du projectile
                                    Console.SetCursorPosition(proj.Position.X, proj.Position.Y);
                                    Console.Write(" ");
                                }
                            }
                            else
                            {
                                // Si c'est le tour du joueur 2, le projectile vise le joueur 1
                                if (_joueur1.HitBox.isTouched(proj.Position.X, proj.Position.Y))
                                {
                                    _collisionDetected = true;
                                    _joueur2.TakeDamage();
                                    proj.IsActive = false;


                                    // Effacer l'affichage du projectile
                                    Console.SetCursorPosition(proj.Position.X, proj.Position.Y);
                                    Console.Write(" ");
                                }
                            }

                            // Si le projectile n'est plus actif (collision ou hors écran) on le supprime de la liste
                            if (!proj.IsActive)
                            {
                                _projectiles.Remove(proj);
                            }
                        }
                    }
                    Thread.Sleep(100); // Attend pour permettre l'animation
                }
                // Changement de joueur
                _isPlayer1Turn = !_isPlayer1Turn;

            }
        }  
    }
}
