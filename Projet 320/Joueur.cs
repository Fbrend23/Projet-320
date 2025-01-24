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
        private string _nom;
        private bool _IsTurnActive;
        private int _vie;
        private int _positionX;
        private int _positionY;
        private readonly string[] joueurDisplay =
        {
            @" o ",
            @"/|\",
            @"/ \",
        };
        /// <summary>
        /// Cnstructeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="isTurnActive"></param>
        public Joueur(string nom, bool isTurnActive, int vie, int positionX, int positionY)
        {
            _nom = nom;
            _IsTurnActive = isTurnActive;
            _vie = vie;
            _positionX = positionX;
            _positionY = positionY;
        }



        /// <summary>
        /// Affichage des joueurs
        /// </summary>
        public void AffichageJoueur()
        {
            Console.SetCursorPosition(_positionX, Config.SCREEN_HEIGHT + 3);
            Console.WriteLine(_nom);    
            Console.SetCursorPosition(_positionX, Config.SCREEN_HEIGHT);
            
            for (int i = 1; i <= joueurDisplay.Length; i++)
            { 
                Console.WriteLine(joueurDisplay[i-1]);
                Console.SetCursorPosition(_positionX, Config.SCREEN_HEIGHT + i);
            }
        }
    }
}
