using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    internal class Joueur
    {
        //*********** Propriétés ***********//
        private readonly string[] joueurDisplay =
        {
            @" o ",
            @"/|\",
            @"/ \",
        };
        /// <summary>
        /// Affichage du joueur
        /// </summary>
        /// <param name="setPositionX">Position depuis la gauche de la fenêtre</param>
        public void AffichageJoueur(int setPositionX)
        {
            Console.SetCursorPosition(setPositionX, Config.SCREEN_HEIGHT);
            for (int i = 1; i <= joueurDisplay.Length; i++)
            { 
                Console.WriteLine(joueurDisplay[i-1]);
                Console.SetCursorPosition(setPositionX, Config.SCREEN_HEIGHT + i);

            }
        }
    }
}
