using Checkers.Enums;
using System.Collections.Generic;

namespace Checkers.Pawns {
    public class PawnMover : IPawnMover {
        public IPawn Pawn => _pawn;
        private IPawn _pawn;

        public PawnMover (IPawn pawn) {
            _pawn = pawn;
        }

        public List<Fields> GetPossiblePositions () {
            List<Fields> fields = new List<Fields> ();

            if (IsOnTheLastLine)
                return null;

            if (IsPawnBlack) {
                if (IsOnLeftSide) {
                    //TODO
                }
            }
            return fields;
        }



        private char Letter => Pawn.MyField.FieldEnum.ToString ()[0];
        private char Number => Pawn.MyField.FieldEnum.ToString ()[1];
        private bool IsPawnBlack => Pawn.MyColor == Color.black;
        private bool IsOnLeftSide => Letter == 'a';
        private bool IsOnRightSide => Letter == 'h';

        private bool IsOnTheLastLine => IsPawnBlack && Number == '1' || !IsPawnBlack && Number == '8';
    }
}
