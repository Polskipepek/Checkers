using Checkers.Enums;
using Checkers.Game;
using System.Collections.Generic;

namespace Checkers.Pawns {
    public interface IPawnMover {
        IPawn Pawn { get; }
        List<Fields> GetPossiblePositions ();
        List<TakeDetails> GetPossibleTakes ();
        int MaxTakeBreak { get; }
    }
}
