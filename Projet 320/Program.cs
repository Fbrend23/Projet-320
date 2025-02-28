using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
       
        Game game = new Game();

        game.Run();

        }
    }
}
