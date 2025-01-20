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

            joueur1.AffichageJoueur(10);



            Console.ReadLine(); //Maintient de la fenêtre pour tests

        }
    }
}
