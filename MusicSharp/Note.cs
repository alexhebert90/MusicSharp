using System;

namespace MusicSharp
{
    // I believe I intend this to simply be context-less letters.

    // Eg: A, A#, G natural, F double flat, etc.    

    public class Note
    {
        private Note(string noteName, short? accidentals)
        {
            // Parameter checking.
            if (string.IsNullOrWhiteSpace(noteName))
                throw new ArgumentException("Supplied note name must not be empty.", nameof(noteName));

            NoteName = noteName;

            // Null or 0 should resolve to 0 accidentals.
            Accidentals = accidentals.GetValueOrDefault();
        }

        private Note(string noteName) : 
            this(noteName: noteName, accidentals: default) { }

        private Note(Note copyNote, int accidentalAdjustments) :
            this(noteName: copyNote?.NoteName, accidentals: AdjustConstructorAccidentals(originalAccidentals: copyNote?.Accidentals, additionalAccidentals: accidentalAdjustments))
        {
            // Null checking of the incoming variable is handled implicitly by the null checking of each of the parameters when they hit
            // the main constructor.
        }

        private static short AdjustConstructorAccidentals(short? originalAccidentals, int additionalAccidentals)
        {
            short defaultedOriginal = originalAccidentals.GetValueOrDefault();
            int intSum = defaultedOriginal + additionalAccidentals;

            // Rudimentary range checking
            if (intSum > short.MaxValue || intSum < short.MinValue)
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(additionalAccidentals), 
                    message: $"Applying {additionalAccidentals} to an original value of {originalAccidentals} results in too many accidentals applied.");

            // Final return.
            return (short)intSum;
        }

        /// <summary>
        /// This will hold the note's actual letter. While technically this should only ever be a single character,
        /// leaving it as a string provides more flexibility for changes in the future(?) and support for things I don't know I know about note names.
        /// </summary>
        private string NoteName { get; }

        /// <summary>
        /// This one variable is meant to hold the "status" of the note in terms of how many sharp, flat, or (none) signs it has.
        /// "0" would represent a normal note, 1 would be 1 sharp, -1 would be 1 flat, etc.
        /// </summary>
        private short Accidentals { get; }


        public Note Sharp => Sharps(1);

        public Note Flat => Flats(1);

        public Note Sharps(short numberOfSharps) => new Note(this, accidentalAdjustments: numberOfSharps);

        public Note Flats(short numberOfFlats) => new Note(this, accidentalAdjustments: -1 * numberOfFlats);



        // Important: 
        // I BELIEVE I want note instances to be immutable. That is the ONLY reason why
        // I am treating each of these as singletons. If notes become mutable in the future, the below
        // concept will be _very_ bad!

        // ToDo: Write test to guarantee immutability of notes.

        public static Note A { get; } = new Note(NoteNames.A);

        public static Note B { get; } = new Note(NoteNames.B);

        public static Note C { get; } = new Note(NoteNames.C);

        public static Note D { get; } = new Note(NoteNames.D);

        public static Note E { get; } = new Note(NoteNames.E);

        public static Note F { get; } = new Note(NoteNames.F);

        public static Note G { get; } = new Note(NoteNames.G);



        private string AccidentalsToSymbol()
        {
            string symbol;

            if (Accidentals == 0)
            {
                symbol = null;
            }
            else if(Accidentals > 0)
            {
                // Sharps
                symbol = GetRepeatedChars(MusicSharp.Accidentals.Sharp);
            }
            else
            {
                // Flats
                symbol = GetRepeatedChars(MusicSharp.Accidentals.Flat);
            }


            return symbol;
        }

        private string GetRepeatedChars(char repeatedCharacter)
        {
            // Any negative number has already been compensated for by the passed-in char.
            // Get the aboslute value to determine the count of characters to create.
            short repetitions = Math.Abs(Accidentals);

            string output = string.Empty;
            for(short x = 0; x < repetitions; x++)
            {
                output += repeatedCharacter;
            }
            return output;
        }

        public override string ToString()
        {
            return $"{NoteName}{AccidentalsToSymbol()}";
        }
    }
}
