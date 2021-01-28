using Checkers.Pawns;

namespace Checkers.Game {
    public class TakeDetails {
        public IPawn Taker { get; }
        public IPawn Taken { get; }
        public Field EndPos { get; }

        public TakeDetails (IPawn taker, IPawn taken, Field endPos) {
            Taker = taker;
            Taken = taken;
            EndPos = endPos;
        }
    }
}
