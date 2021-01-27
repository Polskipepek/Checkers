using Checkers.Enums;
using System.Collections.Generic;

namespace Checkers.Pawns {
    public interface IPawnMover {
        IPawn Pawn { get; }
        List<Fields> GetPossiblePositions ();
    }
}
