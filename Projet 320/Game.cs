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
        private Joueur joueur1;
        private Joueur joueur2;
        private Tour tour1;
        private Tour tour2;
        private Interface_tir interfaceTir;

        public Game()
        {
            // Initialise les objets 
            joueur1 = new Joueur("J1", true, 3, new Position(10, 10));
            joueur2 = new Joueur("J2", false, 3, new Position(Config.SCREEN_WIDTH - 10, 10));
            tour1 = new Tour(3, 5, new Position(20, Config.SCREEN_HEIGHT - 12));
            tour2 = new Tour(3, 5, new Position(Config.SCREEN_WIDTH - 20, Config.SCREEN_HEIGHT - 12));
            interfaceTir = new Interface_tir(new Position(12, Config.SCREEN_HEIGHT - 12));
        }

        public void Run()
        {
            // Afficher les éléments du jeu
            joueur1.AffichageJoueur();
            tour1.AffichageTour();
            joueur2.AffichageJoueur();
            tour2.AffichageTour();

            // Interface de tir
            int angle = interfaceTir.SelectAngle();
            int power = interfaceTir.SelectPower();

            // Créer et animer le projectile
            Projectile projectile = new Projectile(angle, power, new Position(10, Config.SCREEN_HEIGHT - 12), true, 0);
            while (projectile._isActive)
            {
                projectile.UpdateProjectile(0.1);
                projectile.DisplayProjectile();
                Thread.Sleep(100);
            }

            Console.ReadLine(); // Maintient la fenêtre pour tests
        }
    }
}
