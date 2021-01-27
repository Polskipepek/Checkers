using Checkers.Enums;
using Checkers.Game;
using System.Collections.Generic;

namespace Checkers.Pawns {
    public class Pawn : IPawn {
        public Color MyColor { get; private set; }
        public Field MyField { get; private set; }

        public List<Fields> PossibleMoves => PawnMover.GetPossiblePositions ();

        public IPawnMover PawnMover { get; private set; }

        public string Name { get; }

        public Pawn (string name, Color color, Field position) {
            MyColor = color;
            MyField = position;
            Name = name;
            PawnMover = name.ToLower () == "p" ? new PawnMover (this) : null;
        }

        public void Move (Fields position) {
            var possiblePositions = PawnMover.GetPossiblePositions ();
            if (possiblePositions.Contains (position)) {
                MyField = Board.Instance[position];
            }
        }
    }
}
