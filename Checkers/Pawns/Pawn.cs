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
        public List<TakeDetails> PossibleTakes => PawnMover.GetPossibleTakes ();

        public Pawn (string name, Color color, Field position) {
            MyColor = color;
            MyField = position;
            Name = name;
            PawnMover = name.ToLower () == "o" ? new PawnMover (this) : null;
        }

        public void Move (Fields position) {
            MyField = Board.Instance[position];
        }

        public void Dispose () {
            MyField = null;
            PawnMover = null;
        }
    }
}
