using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Projet_320
{

    ////////////////////////////////////////////////////////////////
    // ETML                                                       //
    // Auteur: Brendan Fleurdelys                                 //
    // Date: 17.01.2025                                           //
    // Description: Projet 320                                    //
    // Module: 320                                                //
    ////////////////////////////////////////////////////////////////
    internal class Program
    {
        static void Main()
        {
        //Initilialisation de la configuration
        Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
        Console.CursorVisible = false;
        int angle;
        int power;
        int projectileX; // Position du projectile en X
        int projectileY; // Position du projectile en Y

        //Initialisation des objets
        Joueur joueur1 = new Joueur("J1", true, 3, new Position(10, 10));
        Joueur joueur2 = new Joueur("J2", false, 3, new Position(Config.SCREEN_WIDTH - 10, 10));
        Tour tour1 = new Tour(3,5,new Position(20, Config.SCREEN_HEIGHT - 12));
        Tour tour2 = new Tour(3,5,new Position(Config.SCREEN_WIDTH -20, Config.SCREEN_HEIGHT - 12));

        Interface_tir interface1 = new Interface_tir(new Position(12, Config.SCREEN_HEIGHT -10));


        //Affichage du jeu côté joueur 1
        joueur1.AffichageJoueur();
        tour1.AffichageTour();

         //Affichage du jeu côté joueur 2
        joueur2.AffichageJoueur();
        tour2.AffichageTour();
        
        //Interface de tir
        
        angle = interface1.SelectAngle();
        power = interface1.SelectPower();
        Projectile projectile1 = new Projectile(angle, power, new Position(12, Config.SCREEN_HEIGHT - 12), true, 0);
            while (projectile1._isActive)
            {
                projectile1.UpdateProjectile(0.1);
                projectile1.DisplayProjectile();
                Thread.Sleep(100);
            }
       
        Console.ReadLine(); //Maintient de la fenêtre pour tests


        }
    }
}
