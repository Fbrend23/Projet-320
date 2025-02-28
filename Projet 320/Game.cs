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
        private Interface_tir _interfaceTirJ1;
        private Interface_tir _interfaceTirJ2;
        private List<Projectile> _projectiles;

        private bool _isPlayer1Turn = true;

        public Game() 
        { 
        _joueur1 = new Joueur("J1", true, 3, new Position(10, 10));
        _joueur2 = new Joueur("J2", false, 3, new Position(Config.SCREEN_WIDTH - 10, 10));
        _tour1 = new Tour(3, 5, new Position(20, Config.SCREEN_HEIGHT - 12));
        _tour2 = new Tour(3, 5, new Position(Config.SCREEN_WIDTH - 20, Config.SCREEN_HEIGHT - 12));
        _interfaceTirJ1 = new Interface_tir(new Position(12, Config.SCREEN_HEIGHT - 12), false);
        _interfaceTirJ2 = new Interface_tir(new Position(Config.SCREEN_WIDTH - 10, Config.SCREEN_HEIGHT - 12),true);
        _projectiles = new List<Projectile>();       
        }
        public void RunGame()
        {
            // Afficher les éléments du jeu
            _joueur1.AffichageJoueur();
            _tour1.AffichageTour();
            _joueur2.AffichageJoueur();
            _tour2.AffichageTour();

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
                    // Pour éviter les modifications de la liste pendant l'itération, on parcourt une copie
                    foreach (var proj in new List<Projectile>(_projectiles))
                    {
                        if (proj._isActive)
                        {
                            proj.UpdateProjectile(0.1); // On simule 0,1 seconde d'écoulement
                            proj.DisplayProjectile();
                        }
                        else
                        {
                            _projectiles.Remove(proj);
                        }
                    }
                    Thread.Sleep(100); // Pause pour l'animation
                }
                // Alterner le tour
                _isPlayer1Turn = !_isPlayer1Turn;
            }
        }  
    }
}
