using Checkers.Game;
using Checkers.Misc;
using System;

namespace Checkers {
    class Program {
        static void Main () {
            GameInitializer.Instance.InitializeGame ();
            Drawer.Instance.Draw ();
            GameLoop.Instance.StartGame ();
            Console.ReadLine ();
        }
    }
}
