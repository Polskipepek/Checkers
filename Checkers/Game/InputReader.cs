using Checkers.Enums;
using Checkers.Misc;
using System.Linq;

namespace Checkers.Game {
    public class InputReader : Singleton<InputReader> {

        public bool ReadGameLoopInput (string input, Color movingColor, out Field cur, out Field target) {
            Field curField = Board.Instance[(input.First (), int.Parse (input[1].ToString ()))];
            Field targetField = Board.Instance[(input[3], int.Parse (input[4].ToString ()))];

            cur = null;
            target = null;

            if (curField == null || targetField == null) return false;
            cur = curField;
            target = targetField;
            return curField.Pawn?.MyColor == movingColor && Board.Instance.PlayableFields.Contains (targetField);
        }
    }
}
