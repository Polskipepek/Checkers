using Checkers.Game;
using System;

namespace Checkers.Misc {
    public class Drawer : Singleton<Drawer> {

        public void Draw () {
            for (int y = -1; y < 9; y++) {
                for (int x = -1; x < 9; x++) {
                    if ((x == -1 || x == 8)) {
                        Console.Write ((char) (y + 1 + 96) + " ");
                        continue;
                    } else if (y == -1 || y == 8) {
                        Console.Write (x + 1 + " ");
                        continue;
                    }
                    Field field = Board.Instance.AllFields[(y) * 8 + (x)];
                    Console.Write (field.Pawn != null ? "P " : "  ");
                }
                Console.WriteLine ();
            }
        }
    }
}
