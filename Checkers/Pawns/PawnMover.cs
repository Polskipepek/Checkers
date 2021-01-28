using Checkers.Enums;
using Checkers.Game;
using System.Collections.Generic;
using System.Linq;

namespace Checkers.Pawns {
    public class PawnMover : IPawnMover {
        public IPawn Pawn => _pawn;
        private readonly IPawn _pawn;
        public int MaxTakeBreak => 1;
        public PawnMover (IPawn pawn) {
            _pawn = pawn;
        }

        public List<TakeDetails> GetPossibleTakes () {
            List<TakeDetails> takes = new List<TakeDetails> ();

            var rightUpperField = Pawn.MyField.RightUpperField (Pawn.MyColor);
            if (rightUpperField != null && rightUpperField.Pawn != null && rightUpperField.Pawn.MyColor != Pawn.MyColor) {
                var rightUpperRightUpper = rightUpperField.RightUpperField (Pawn.MyColor);
                if (rightUpperRightUpper != null && rightUpperRightUpper.Pawn == null) {
                    takes.Add (new TakeDetails (Pawn, rightUpperField.Pawn, rightUpperRightUpper));
                }
            }

            var leftUpperField = Pawn.MyField.LeftUpperField (Pawn.MyColor);
            if (leftUpperField != null && leftUpperField.Pawn != null && leftUpperField.Pawn.MyColor != Pawn.MyColor) {
                var leftUpperLeftUpper = leftUpperField.LeftUpperField (Pawn.MyColor);
                if (leftUpperLeftUpper != null && leftUpperLeftUpper.Pawn == null) {
                    takes.Add (new TakeDetails (Pawn, leftUpperField.Pawn, leftUpperLeftUpper));
                }
            }

            var rightLowerField = Pawn.MyField.RightLowerField (Pawn.MyColor);
            if (rightLowerField != null && rightLowerField.Pawn != null && rightLowerField.Pawn.MyColor != Pawn.MyColor) {
                var rightLowerRightLower = rightLowerField.RightLowerField (Pawn.MyColor);
                if (rightLowerRightLower != null && rightLowerRightLower.Pawn == null) {
                    takes.Add (new TakeDetails (Pawn, rightLowerField.Pawn, rightLowerRightLower));
                }
            }

            var leftLowerField = Pawn.MyField.LeftLowerField (Pawn.MyColor);
            if (leftLowerField != null && leftLowerField.Pawn != null && leftLowerField.Pawn.MyColor != Pawn.MyColor) {
                var leftLowerLeftLower = leftLowerField.LeftLowerField (Pawn.MyColor);
                if (leftLowerLeftLower != null && leftLowerLeftLower.Pawn == null) {
                    takes.Add (new TakeDetails (Pawn, leftLowerField.Pawn, leftLowerLeftLower));
                }
            }
            return takes.Any () ? takes : null;
        }

        public List<Fields> GetPossiblePositions () {
            List<Fields> fields = new List<Fields> ();
            var rightUpperField = Pawn.MyField.RightUpperField (Pawn.MyColor);
            var leftUpperField = Pawn.MyField.LeftUpperField (Pawn.MyColor);

            if (rightUpperField != null && rightUpperField.Pawn == null) {
                fields.Add (rightUpperField.FieldEnum);
            }
            if (leftUpperField != null && leftUpperField.Pawn == null) {
                fields.Add (leftUpperField.FieldEnum);
            }
            return fields.Any () ? fields : null;
        }
    }
}
