////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Moteur du jeu, initialise tous les objets et gère la partie.
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
    internal class Game
    {
        // Objets du jeu
        private Joueur _joueur1;
        private Joueur _joueur2;
        private Tour _tour1;
        private Tour _tour2;
        private GestionnaireTir _interfaceTirJ1;
        private GestionnaireTir _interfaceTirJ2;
        private List<Projectile> _projectiles;
        private bool _collisionDetected;
        private bool _isPlayer1Turn = true;
        private Score _scoreJ1;
        private Score _scoreJ2;

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
        public void RunGame()
        {
            Config.ConfigJeu();

            // Afficher les éléments du jeu
            _joueur1.AffichageJoueur();
            _tour1.AffichageTour();
            _scoreJ1.DisplayScore();
            _joueur2.AffichageJoueur();
            _tour2.AffichageTour();
            _scoreJ2.DisplayScore();

            while (true)
            {
                // Selon le tour, afficher l'interface de tir correspondante
                if (_isPlayer1Turn)
                {
                    int angle = _interfaceTirJ1.SelectAngle();
                    int power = _interfaceTirJ1.SelectPower();
                    // Créer le projectile à partir de la position de départ 
                    Projectile projectile = new Projectile(angle, power, new Position(12, Config.SCREEN_HEIGHT - 12), true, 0);
                    _projectiles.Add(projectile);
                }
                else
                {
                    int angle = _interfaceTirJ2.SelectAngle();
                    int power = _interfaceTirJ2.SelectPower();
                    // Position de départ pour le projectile du joueur 2 (en miroir)
                    Projectile projectile = new Projectile(angle, power, new Position(Config.SCREEN_WIDTH - 12, Config.SCREEN_HEIGHT - 12), true, 0);
                    _projectiles.Add(projectile);
                }

                // Animation du tir : mettre à jour et afficher les projectiles
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


                                    // Effacer l'affichage du projectile
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

                            // Si le projectile n'est plus actif (collision ou hors écran), on le retire de la liste
                            if (!proj.IsActive)
                            {
                                _projectiles.Remove(proj);
                            }
                        }
                        else
                        {
                            _projectiles.Remove(proj);
                        }
                    }
                    Thread.Sleep(100); // Pause pour laisser le temps à l'animation de se dérouler
                }
                // Changement de joueur
                _isPlayer1Turn = !_isPlayer1Turn;

            }
        }  
    }
}
