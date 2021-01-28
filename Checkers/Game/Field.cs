using Checkers.Enums;
using Checkers.Pawns;
using System;
using System.Linq;

namespace Checkers.Game {
    public class Field {
        public Fields FieldEnum { get; }
        public Field (Fields field) {
            FieldEnum = field;
        }

        public IPawn Pawn => Board.Instance.OnboardPawns.FirstOrDefault (p => p.MyField == this);

        public (char letter, int number) GetFieldCoordinates () {
            var letter = FieldEnum.ToString ()[0];
            var number = int.Parse (FieldEnum.ToString ()[1].ToString ());
            return (letter, number);
        }

        Field TryParseStringToField (string coord) {
            if (Enum.TryParse<Fields> (coord, out Fields newField)) {
                return Board.Instance[newField];
            }
            return null;
        }

        public Field RightUpperField (Color color) {
            if (color == Color.black)
                return LeftLowerField (Color.white);
            var (letter, number) = GetFieldCoordinates ();
            var newFieldCoords = $"{Convert.ToChar ((char) letter + 1)}{number + 1}";
            return TryParseStringToField (newFieldCoords);
        }

        public Field LeftUpperField (Color color) {
            if (color == Color.black)
                return RightLowerField (Color.white);
            var (letter, number) = GetFieldCoordinates ();
            var newFieldCoords = $"{Convert.ToChar ((char) letter - 1)}{number + 1}";
            return TryParseStringToField (newFieldCoords);
        }
        public Field RightLowerField (Color color) {
            if (color == Color.black)
                return LeftUpperField (Color.white);
            var (letter, number) = GetFieldCoordinates ();
            var newFieldCoords = $"{Convert.ToChar ((char) letter + 1)}{number - 1}";
            return TryParseStringToField (newFieldCoords);
        }

        public Field LeftLowerField (Color color) {
            if (color == Color.black)
                return RightUpperField (Color.white);
            var (letter, number) = GetFieldCoordinates ();
            var newFieldCoord = $"{Convert.ToChar ((char) letter - 1)}{number - 1}";
            return TryParseStringToField (newFieldCoord);
        }

    }
}
