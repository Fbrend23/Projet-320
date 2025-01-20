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

            joueur1.AffichageJoueur(10);
            tour1.AffichageTour(15);
            joueur2.AffichageJoueur(Config.SCREEN_WIDTH - 13);
            tour2.AffichageTour(Config.SCREEN_WIDTH - 13);
            


            Console.ReadLine(); //Maintient de la fenêtre pour tests


        }
    }
}
