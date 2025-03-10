/////////////////////////////////////////////////////
// ETML                                                                  
// Auteur: Brendan Fleurdelys                                            
// Date: 17.01.2025                                                      
// Description: Gère le point d'entrée du programme et démarre le jeu    
// Module: 320                                                           
////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Projet_320_Tests")]

namespace Projet_320
{
    /// <summary>
    /// Point d'entrée principal du programme
    /// Initialise une instance du jeu et lance son exécution
    /// </summary>
    internal class Program
    {
        static void Main()
        {
            // Crée une instance du jeu
            Game game = new Game();

            // Lance la boucle du jeu
            game.RunGame();
        }
    }
}
