using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_320
{
    internal class Tour
    {
        private string[] tourDisplay =
        {
            @"███",
            @"███",
            @"███",
            @"███",
            @"███",
        };
        /// <summary>
        /// Affiche la tour
        /// </summary>
        /// <param name="setPositionX"></param>
        public void AffichageTour(int setPositionX)
        {
            Console.SetCursorPosition(setPositionX, Config.SCREEN_HEIGHT - 2);
            for (int i = 1; i <= tourDisplay.Length; i++)
            {
                Console.WriteLine(tourDisplay[i - 1]);
                Console.SetCursorPosition(setPositionX, Config.SCREEN_HEIGHT - 2 + i);

            }
        }
    }
}
