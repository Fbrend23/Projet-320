////////////////////////////////////////////////////////////////
// ETML                                                       
// Auteur: Brendan Fleurdelys                                
// Date: 17.01.2025                                           
// Description: Configuration des paramêtres du jeu tels que la résolution de la console
// Définit la hauteur et la largeur de la fenêtre ainsi que d'autres paramètres généraux du jeu
// Module: 320                                                
////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_320
{
    /// <summary>
    /// Contient les paramètres globaux du jeu
    /// Définit la taille de la fenêtre de la console et d'autres réglages
    static internal class Config
    {
        //*********** Constantes ***********//

        /// <summary>
        /// Hauteur de la fenêtre de la console
        /// </summary>
        public const int SCREEN_HEIGHT = 40;

        /// <summary>
        /// Largeur de la fenêtre de la console
        /// </summary>
        public const int SCREEN_WIDTH = 150;

        /// <summary>
        /// Configure les paramètres de la console au démarrage du jeu
        /// Définit la taille de la fenêtre et masque le curseur
        /// </summary>
        static public void ConfigJeu()
        {
            if (!Console.IsOutputRedirected)
            {
                Console.SetWindowSize(Config.SCREEN_WIDTH, Config.SCREEN_HEIGHT);
                Console.CursorVisible = false;
            }
        }

        /// <summary>
        /// Retourne la largeur de la fenêtre, ajouté pour un test unitaire
        /// </summary>
        /// <returns></returns>
        public static int GetWindowWidth()
        {
            try
            {
                return Console.WindowWidth;
            }
            catch (System.IO.IOException)
            {
                return SCREEN_WIDTH;
            }
        }

        /// <summary>
        /// Retourne la hauteur de la fenêtre, ajouté pour un test unitaire
        /// </summary>
        /// <returns></returns>
        public static int GetWindowHeight()
        {
            try
            {
                return Console.WindowHeight;
            }
            catch (System.IO.IOException)
            {
                return SCREEN_HEIGHT;
            }
        }
    }

   
}
