using Checkers.Enums;
using Checkers.Game;
using Checkers.Misc;
using Checkers.Pawns;
using System.Collections.Generic;
using System.Linq;

namespace Checkers {
    public class Board : Singleton<Board> {
        public List<IPawn> OnboardPawns { get; private set; }
        public List<Field> PlayableFields { get; private set; }
        public List<Field> AllFields { get; private set; }

        public Board () {
            SetAllFields ();
        }

        public void InitializeBoard (List<IPawn> startingPawns, List<Field> legalFields) {
            OnboardPawns = startingPawns;
            PlayableFields = legalFields;
        }

        public void ResetBoard () {
            OnboardPawns = null;
            PlayableFields = null;
        }
        public void TakePawn (IPawn pawn) {
            pawn.Dispose ();
            OnboardPawns.Remove (pawn);
        }

        public Field this[Fields field] {
            get {
                return AllFields[(int) field];
            }
        }

        public Field this[int fieldId] {
            get {
                if (fieldId < (int) Fields.a1 || fieldId > (int) Fields.h8)
                    return null;

                return AllFields[fieldId];
            }
        }

        public Field this[(char letter, int number) pos] {
            get => AllFields.FirstOrDefault (field => (field.FieldEnum.ToString () == pos.letter + pos.number.ToString ()));
        }


        private void SetAllFields () => AllFields = new List<Field> () {
            new Field(Fields.a1),
            new Field(Fields.a2),
            new Field(Fields.a3),
            new Field(Fields.a4),
            new Field(Fields.a5),
            new Field(Fields.a6),
            new Field(Fields.a7),
            new Field(Fields.a8),

            new Field(Fields.b1),
            new Field(Fields.b2),
            new Field(Fields.b3),
            new Field(Fields.b4),
            new Field(Fields.b5),
            new Field(Fields.b6),
            new Field(Fields.b7),
            new Field(Fields.b8),

            new Field(Fields.c1),
            new Field(Fields.c2),
            new Field(Fields.c3),
            new Field(Fields.c4),
            new Field(Fields.c5),
            new Field(Fields.c6),
            new Field(Fields.c7),
            new Field(Fields.c8),

            new Field(Fields.d1),
            new Field(Fields.d2),
            new Field(Fields.d3),
            new Field(Fields.d4),
            new Field(Fields.d5),
            new Field(Fields.d6),
            new Field(Fields.d7),
            new Field(Fields.d8),

            new Field(Fields.e1),
            new Field(Fields.e2),
            new Field(Fields.e3),
            new Field(Fields.e4),
            new Field(Fields.e5),
            new Field(Fields.e6),
            new Field(Fields.e7),
            new Field(Fields.e8),

            new Field(Fields.f1),
            new Field(Fields.f2),
            new Field(Fields.f3),
            new Field(Fields.f4),
            new Field(Fields.f5),
            new Field(Fields.f6),
            new Field(Fields.f7),
            new Field(Fields.f8),

            new Field(Fields.g1),
            new Field(Fields.g2),
            new Field(Fields.g3),
            new Field(Fields.g4),
            new Field(Fields.g5),
            new Field(Fields.g6),
            new Field(Fields.g7),
            new Field(Fields.g8),

            new Field(Fields.h1),
            new Field(Fields.h2),
            new Field(Fields.h3),
            new Field(Fields.h4),
            new Field(Fields.h5),
            new Field(Fields.h6),
            new Field(Fields.h7),
            new Field(Fields.h8),
        };

    }
}
