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

        public Field RightField () {
            var letter = FieldEnum.ToString ()[0];
            var number = int.Parse (FieldEnum.ToString ()[1].ToString ());

            var newFieldId = $"{(char) ++letter}{number}";

            if (Enum.TryParse<Fields> (newFieldId, out Fields newField)) {
                return Board.Instance[newField];
            }

            return null;
        }
    }
}
