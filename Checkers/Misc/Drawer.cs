using Checkers.Enums;
using Checkers.Game;
using System;
using System.Linq;

namespace Checkers.Misc {
    public class Drawer : Singleton<Drawer> {
        bool IsCorner (int x, int y) => x == -1 && y == -1 || x == 8 && y == -1 || x == 8 && y == 8 || x == -1 && y == 8;
        bool IsHorizontalBound (int x) => x == -1 || x == 8;
        bool IsVerticalBound (int y) => y == -1 || y == 8;

        public void Draw () {
            Console.Clear ();
            for (int y = 8; y >= -1; y--) {
                for (int x = -1; x < 9; x++) {
                    Console.ResetColor ();
                    if (IsCorner (x, y)) {
                        Console.Write ("* ");
                        continue;
                    } else {
                        if (IsVerticalBound (y)) {
                            Console.Write ((char) (x + 'a') + " ");
                            continue;
                        } else if (IsHorizontalBound (x)) {
                            Console.Write (y + 1 + " ");
                            continue;
                        }
                    }
                    Console.BackgroundColor = (x + y) % 2 == 0 ? ConsoleColor.DarkGray : ConsoleColor.Gray;
                    Field field = Board.Instance.AllFields[(x) * 8 + (y)];
                    Console.ForegroundColor = field.Pawn?.MyColor == Color.black ? ConsoleColor.Black : ConsoleColor.White;
                    Console.Write (field.Pawn != null ? $"{field.Pawn.Name} " : "  ");
                }
                Console.WriteLine ();
            }
            if (GameLoop.Instance.Moves?.Any () == true)
                Console.WriteLine (string.Join (", ", GameLoop.Instance.Moves.Select (move => $"{move.Item1.FieldEnum} to {move.Item2.FieldEnum}")));
        }
    }
}
