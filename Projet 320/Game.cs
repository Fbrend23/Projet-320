﻿////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Gère le moteur du jeu, initialise tous les objets et contrôle la partie
// Module: 320                                                
////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// Reprense le gagnant
        /// </summary>
        private string _winner;


        //*********** Propriétés ***********//

        /// <summary>
        /// Retourne le gagnant
        /// </summary>
        public string Winner
        {
            get { return _winner; }
            set { value = _winner; }
        }

        public bool IsPlayer1Turn
        {
            get { return _isPlayer1Turn; }
        }


        /// <summary>
        /// Initialise tous les objets nécessaires au jeu
        /// Configure les joueurs, les tours, les interfaces de tir et le score
        /// </summary>
        public Game()
        {
            //Création des objets
            _joueur1 = new Joueur("J1", true, 3, new Position(28, 10));
            _joueur2 = new Joueur("J2", false, 3, new Position(Config.SCREEN_WIDTH - 28, 10));
            _tour1 = new Tour(3, 5, new Position(38, Config.SCREEN_HEIGHT - 12));
            _tour2 = new Tour(3, 5, new Position(Config.SCREEN_WIDTH - 38, Config.SCREEN_HEIGHT - 12));
            _interfaceTirJ1 = new GestionnaireTir(new Position(28, Config.SCREEN_HEIGHT - 12), false);
            _interfaceTirJ2 = new GestionnaireTir(new Position(Config.SCREEN_WIDTH - 28, Config.SCREEN_HEIGHT - 12), true);
            _projectiles = new List<Projectile>();
            _scoreJ1 = new Score(new Position(10, 3), _joueur1);
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

            //Créer les tours
            _tour1.CréerTour();
            _tour2.CréerTour();

            while (_joueur1.Vie > 0 && _joueur2.Vie > 0)
            {
                // Afficher les éléments du jeu
                _joueur1.AffichageJoueur();
                _tour1.AffichageTour();
                _joueur2.AffichageJoueur();
                _tour2.AffichageTour();
                // Affiche les scores à chaque début de tour
                _scoreJ1.DisplayScore();
                _scoreJ2.DisplayScore();

                // Détermine quel joueur joue et gère son tir
                if (_isPlayer1Turn)
                {
                    int angle = _interfaceTirJ1.SelectAngle();
                    int power = _interfaceTirJ1.SelectPower();

                    Projectile projectile = new Projectile(angle, power, _interfaceTirJ1.Position, true, 0);
                    _projectiles.Add(projectile);
                }
                else
                {
                    int angle = _interfaceTirJ2.SelectAngle();
                    int power = _interfaceTirJ2.SelectPower();
                    Projectile projectile = new Projectile(angle, power, _interfaceTirJ2.Position, true, 0);
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
                            proj.UpdateProjectile(0.02);
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
                                }
                            }
                            else
                            {
                                // Si c'est le tour du joueur 2, le projectile vise le joueur 1
                                if (_joueur1.HitBox.isTouched(proj.Position.X, proj.Position.Y))
                                {
                                    _collisionDetected = true;
                                    _joueur1.TakeDamage();
                                    proj.IsActive = false;
                                }
                            }

                            //Détection si les tours sont touchées
                            if (_tour1.Hitbox.isTouched(proj.Position.X, proj.Position.Y))
                            {
                                _tour1.TourCollision();
                            }
                            if (_tour2.Hitbox.isTouched(proj.Position.X, proj.Position.Y))
                            {
                                _tour2.TourCollision();
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
            if(_joueur1.Vie == 0)
                {
                 _winner = $"{_joueur2.Nom}";
            
                }
                else
                {
                    _winner = $"{_joueur1.Nom}";
                }

        }

        /// <summary>
        /// Affiche l'écran de fin du jeu avec le message "Game Over" et le joueur gagnant.
        /// </summary>
        /// <param name="winner">Le joueur qui a gagné</param>
        public void AfficherEcranDeFin()
        {
            {
                Console.Clear(); // Efface l'écran
                Console.ForegroundColor = ConsoleColor.Red; // Couleur du texte en rouge

                string[] gameOver =
                {
                @"      ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ ",
                @"     ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗",
                @"     ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝",
                @"     ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗",
                @"     ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║",
                @"      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝"
                };

                int centerX = (Console.WindowWidth / 2) - (gameOver[0].Length / 2);
                int centerY = Console.WindowHeight / 3;

                for (int i = 0; i < gameOver.Length; i++)
                {
                    Console.SetCursorPosition(centerX, centerY + i);
                    Console.WriteLine(gameOver[i]);
                }

                Console.ResetColor(); // Réinitialise la couleur du texte
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, centerY + 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Le gagnant est : {_winner} !");

                Console.ResetColor();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 30, centerY + 12);
                Console.WriteLine("Appuie sur une touche pour quitter...");
                Console.ReadKey();
            }

        }
    }
}
