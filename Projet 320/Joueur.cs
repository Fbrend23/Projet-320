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
        private string _joueur1;
        private string _joueur2;

        private string[] joueurDisplay =
        {
            @" o",
            @"/|\",
            @"/ \",
        };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="setPositionX">Position depuis la gauche de la fenêtre</param>
        public void AffichageJoueur(int setPositionX)
        {
                Console.SetCursorPosition(setPositionX, Config.SCREEN_HEIGHT);
            for (int i = 0; i < joueurDisplay.Length; i++)
            {
                Console.WriteLine(joueurDisplay[i]);
            }
        }
    }
}
