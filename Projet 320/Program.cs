using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        interface1.SelectAngle();
       
        Console.ReadLine(); //Maintient de la fenêtre pour tests


        }
    }
}
