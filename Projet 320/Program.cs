using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projet_320
{
    internal class Program
    {
        static void Main()
        {

        //Initialisation des objets
        Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
        Joueur joueur1 = new Joueur("J1", true, 3, new Position(10, Config.SCREEN_HEIGHT - 2));
        Joueur joueur2 = new Joueur("J2", false, 3, new Position(Config.SCREEN_WIDTH - 10, Config.SCREEN_HEIGHT - 2));
        Tour tour1 = new Tour(3,5,new Position(20, Config.SCREEN_HEIGHT - 2));
        Tour tour2 = new Tour(3,5,new Position(Config.SCREEN_WIDTH -20, Config.SCREEN_HEIGHT - 2));


        //Affichage du jeu côté joueur 1
        joueur1.AffichageJoueur();
        tour1.AffichageTour();

         //Affichage du jeu côté joueur 2
        joueur2.AffichageJoueur();
        tour2.AffichageTour();



            Console.ReadLine(); //Maintient de la fenêtre pour tests


        }
    }
}
