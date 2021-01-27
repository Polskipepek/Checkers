using Checkers.Enums;
using Checkers.Misc;
using Checkers.Pawns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers.Game {
    public class GameLoop : Singleton<GameLoop> {
        public List<(Field, Field)> Moves { get; private set; }

        public Color ColorToMove => Moves?.Count % 2 == 0 ? Color.black : Color.white;
        public IEnumerable<IPawn> BlackPawns => Board.Instance.OnboardPawns.Where (pawn => pawn.MyColor == Color.black);
        public IEnumerable<IPawn> WhitePawns => Board.Instance.OnboardPawns.Where (pawn => pawn.MyColor == Color.white);
        public bool GameOver => BlackPawns.Count () == 0 || WhitePawns.Count () == 0 ||
            BlackPawns.Count (pawn => pawn.PossibleMoves.Count () == 0) == BlackPawns.Count () ||
            WhitePawns.Count (pawn => pawn.PossibleMoves.Count () == 0) == WhitePawns.Count ();

        public void StartGame () {
            Moves = new List<(Field, Field)> ();
            MainLoopGame ();
        }

        void MainLoopGame () {
            Console.WriteLine ("The Game has just started.");
            Console.WriteLine ("Expected Input: i.e. for white a3-b4");
            while (!GameOver) {
                Console.WriteLine ("To move:" + ColorToMove);
                string input = Console.ReadLine ();
                if (InputReader.Instance.ReadGameLoopInput (input, ColorToMove, out Field curField, out Field targetField) == false) {
                    Console.WriteLine ($"Incorrect input format. Try i.e. {(ColorToMove == Color.white ? "b4-c5" : "c5-b4")}");
                } else if (!curField.Pawn.PossibleMoves.Contains (targetField.FieldEnum)) {
                    Console.WriteLine ("You can't move like that!");
                } else {
                    curField.Pawn.Move (targetField.FieldEnum);
                    Console.WriteLine ($"Pawn {targetField.Pawn.Name} has been moved.");
                    Drawer.Instance.Draw ();
                }
            }
        }
    }
}
