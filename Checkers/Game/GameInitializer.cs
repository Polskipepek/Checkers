using Checkers.Enums;
using Checkers.Misc;
using Checkers.Pawns;
using System.Collections.Generic;

namespace Checkers.Game {
    public class GameInitializer : Singleton<GameInitializer> {
        public void InitializeGame () {
            Board.Instance.InitializeBoard (GetStartingPawns (), GetPlayableFields ());
        }
        private List<Field> GetPlayableFields () => new List<Field> () {
            new Field(Fields.a1),
            new Field(Fields.a3),
            new Field(Fields.a5),
            new Field(Fields.a7),

            new Field(Fields.b2),
            new Field(Fields.b4),
            new Field(Fields.b6),
            new Field(Fields.b8),

            new Field(Fields.c1),
            new Field(Fields.c3),
            new Field(Fields.c5),
            new Field(Fields.c7),

            new Field(Fields.d2),
            new Field(Fields.d4),
            new Field(Fields.d6),
            new Field(Fields.d8),

            new Field(Fields.e1),
            new Field(Fields.e3),
            new Field(Fields.e5),
            new Field(Fields.e7),

            new Field(Fields.f2),
            new Field(Fields.f6),
            new Field(Fields.f8),

            new Field(Fields.g1),
            new Field(Fields.g3),
            new Field(Fields.g5),
            new Field(Fields.g7),

            new Field(Fields.h2),
            new Field(Fields.h4),
            new Field(Fields.h6),
            new Field(Fields.f4),
            new Field(Fields.h8),
        };

        private List<IPawn> GetStartingPawns () => new List<IPawn> () {
            new Pawn("O", Color.white, Board.Instance[Fields.a1]),
            new Pawn("O", Color.white, Board.Instance[Fields.c1]),
            new Pawn("O", Color.white, Board.Instance[Fields.e1]),
            new Pawn("O", Color.white, Board.Instance[Fields.g1]),

            new Pawn("O", Color.white, Board.Instance[Fields.b2]),
            new Pawn("O", Color.white, Board.Instance[Fields.d2]),
            new Pawn("O", Color.white, Board.Instance[Fields.f2]),
            new Pawn("O", Color.white, Board.Instance[Fields.h2]),

            new Pawn("O", Color.white, Board.Instance[Fields.a3]),
            new Pawn("O", Color.white, Board.Instance[Fields.c3]),
            new Pawn("O", Color.white, Board.Instance[Fields.e3]),
            new Pawn("O", Color.white, Board.Instance[Fields.g3]),

            new Pawn("O", Color.black, Board.Instance[Fields.b6]),
            new Pawn("O", Color.black, Board.Instance[Fields.d6]),
            new Pawn("O", Color.black, Board.Instance[Fields.f6]),
            new Pawn("O", Color.black, Board.Instance[Fields.h6]),

            new Pawn("O", Color.black, Board.Instance[Fields.a7]),
            new Pawn("O", Color.black, Board.Instance[Fields.c7]),
            new Pawn("O", Color.black, Board.Instance[Fields.e7]),
            new Pawn("O", Color.black, Board.Instance[Fields.g7]),

            new Pawn("O", Color.black, Board.Instance[Fields.b8]),
            new Pawn("O", Color.black, Board.Instance[Fields.d8]),
            new Pawn("O", Color.black, Board.Instance[Fields.f8]),
            new Pawn("O", Color.black, Board.Instance[Fields.h8]),
        };
    }
}
