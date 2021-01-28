using Checkers.Enums;
using Checkers.Misc;
using Checkers.Pawns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkers.Game {
    public class GameLoop : Singleton<GameLoop> {
        public List<(Field, Field)> Moves { get; private set; }

        public Color ColorToMove => Moves?.Count % 2 == 0 ? Color.white : Color.black;
        public IEnumerable<IPawn> BlackPawns => Board.Instance.OnboardPawns.Where (pawn => pawn.MyColor == Color.black);
        public IEnumerable<IPawn> WhitePawns => Board.Instance.OnboardPawns.Where (pawn => pawn.MyColor == Color.white);
        public bool IsGameOver => !BlackPawns.Any () || !WhitePawns.Any () ||
            BlackPawns.Count (pawn => pawn.PossibleMoves?.Count () == 0) == BlackPawns.Count () ||
            WhitePawns.Count (pawn => pawn.PossibleMoves?.Count () == 0) == WhitePawns.Count ();

        public void StartGame () {
            Moves = new List<(Field, Field)> ();
            MainLoopGame ();
        }

        void MainLoopGame () {
            Console.WriteLine ("The Game has just started.");
            Console.WriteLine ("Expected Input: i.e. for white a3-b4");
            while (!IsGameOver) {
                Console.WriteLine ("To move: " + ColorToMove);
                var possibleTakes = GetPossibleTakes ();
                WriteMovementInfo (possibleTakes);

                string input = Console.ReadLine ();
                var feedback = InputReader.Instance.ReadGameLoopInput (input, out Field curField, out Field targetField);

                if (feedback == false) {
                    Console.WriteLine ($"Incorrect input format. Try i.e. {(ColorToMove == Color.white ? "b4-c5" : "c5-b4")}");
                } else if (IsTakingPossible (possibleTakes)) {
                    var takeInfo = possibleTakes.FirstOrDefault (take => take.Taker == curField.Pawn && take.EndPos == targetField);
                    if (takeInfo != null) {
                        MakeMove (curField, targetField);
                        Board.Instance.TakePawn (takeInfo.Taken);
                        Drawer.Instance.Draw ();
                    }
                } else if (IsMovementIllegal (curField, targetField)) {
                    Console.WriteLine ("You can't move like that!");
                } else {
                    MakeMove (curField, targetField);
                    Drawer.Instance.Draw ();
                }
            }
            GameOver ();
        }

        private void GameOver () {
            Console.WriteLine ("Game over");

            if (WhitePawns.FirstOrDefault () == null) {
                Console.WriteLine ("Black won!");
            } else if (BlackPawns.FirstOrDefault () == null) {
                Console.WriteLine ("White won!");
            } else {
                Console.WriteLine ("Draw! :(");
            }
        }

        private List<TakeDetails> GetPossibleTakes () {
            return Board.Instance.OnboardPawns.Where (pawn => pawn.MyColor == ColorToMove && pawn.PossibleTakes?.Any () == true).SelectMany (pawn => pawn.PossibleTakes).ToList ();
        }

        private static bool IsTakingPossible (List<TakeDetails> possibleTakes) {
            return possibleTakes?.Any () == true;
        }

        private static bool IsMovementIllegal (Field curField, Field targetField) {
            return curField.Pawn?.PossibleMoves?.Contains (targetField.FieldEnum) != true;
        }

        private void MakeMove (Field curField, Field targetField) {
            Moves.Add ((curField, targetField));
            curField.Pawn.Move (targetField.FieldEnum);
            Console.WriteLine ($"Pawn {targetField.Pawn.Name} has been moved.");
        }
        private void WriteMovementInfo (List<TakeDetails> possibleTakes) {
            if (possibleTakes?.Any () == true) {
                Console.Write ("Possible takes: ");
                Console.WriteLine (string.Join ("; ", possibleTakes.Select (pawnTake => string.Join (",", $"{pawnTake.Taken.MyField.FieldEnum} on {pawnTake.EndPos.FieldEnum}"))));
            } else {
                Console.Write ("Possible moves: ");
                Console.WriteLine (string.Join ("; ", Board.Instance.OnboardPawns.Where (pawn => pawn.PossibleMoves?.Count > 0 && pawn.MyColor == ColorToMove).Select (pawn => string.Join (", ", pawn.PossibleMoves.Select (field => $"{pawn.MyField.FieldEnum}-{field}")))));
            }
        }
    }
}
