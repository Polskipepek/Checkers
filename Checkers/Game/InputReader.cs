using Checkers.Misc;

namespace Checkers.Game {
    public class InputReader : Singleton<InputReader> {
        public bool ReadGameLoopInput (string input, out Field cur, out Field target) {
            cur = null;
            target = null;

            if (input.Length != 5)
                return false;

            var parse1Result = int.TryParse (input[1].ToString (), out int input1);
            var parse4Result = int.TryParse (input[4].ToString (), out int input4);
            if (!parse1Result || !parse4Result) {
                return false;
            }

            Field curField = Board.Instance[(input[0], input1)];
            Field targetField = Board.Instance[(input[3], input4)];

            if (curField == null || targetField == null) return false;
            cur = curField;
            target = targetField;
            return true;
        }
    }
}
