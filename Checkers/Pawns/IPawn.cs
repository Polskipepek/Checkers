using Checkers.Enums;
using Checkers.Game;
using System.Collections.Generic;

namespace Checkers.Pawns {
    public interface IPawn {
        string Name { get; }
        Color MyColor { get; }
        Field MyField { get; }
        void Move (Fields field);
        IPawnMover PawnMover { get; }
        List<Fields> PossibleMoves { get; }
    }
}
