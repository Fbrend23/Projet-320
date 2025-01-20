using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Projet_320
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //Taille de la fenêtre imposée
        Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);


        Joueur joueur1 = new Joueur();
        Joueur joueur2 = new Joueur();
        Tour tour1 = new Tour();
        Tour tour2 = new Tour();

        //Affichage du jeu côté joueur 1
        joueur1.AffichageJoueur(10);
        tour1.AffichageTour(20);

        //Affichage du jeu côté joueur 2
        joueur2.AffichageJoueur(Config.SCREEN_WIDTH - 10);
        tour2.AffichageTour(Config.SCREEN_WIDTH - 20);
            


        Console.ReadLine(); //Maintient de la fenêtre pour tests


        }
    }
}
