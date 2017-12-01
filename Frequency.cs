using System;

namespace MusicSharp
{
    /// <summary>
    /// Represents a single frequency, in hertz.
    /// </summary>
    public sealed class Frequency : IEquatable<Frequency>, IComparable<Frequency>, IComparable
    {
        // Note: The below constructor is currently flagged as internal,
        // but I could be convinced to make it public. We'll see how things go as I
        // get further along.

        /// <summary>
        /// The main entry point for the instantiation of a frequency instance.
        /// </summary>
        /// <param name="hertz"></param>
        /// <exception cref="InvalidFrequencyException"></exception>
        internal Frequency(double hertz)
        {
            // The only "invalid" frequency I can imagine is one that is negative.
            // While there is an upper limit for human hearing, there is no absolute physical limit I'm aware of (besides infinite).
            if(hertz < 0 || double.IsPositiveInfinity(hertz))
            {
                throw new InvalidFrequencyException(hertz);
            }

            Hertz = hertz;
        }

        /// <summary>
        /// Allows convenient conversions between numerical values and frequencies in hertz.
        /// </summary>
        /// <param name="hertz"></param>
        public static implicit operator Frequency(double hertz)
            => new Frequency(hertz: hertz);

        public static Frequency operator +(Frequency first, Frequency second)
            => new Frequency(first.Hertz + second.Hertz);

        public static Frequency operator -(Frequency first, Frequency second)
            => new Frequency(first.Hertz - second.Hertz);

        public static bool operator ==(Frequency first, Frequency second)
        {
            // This handles both values being null.
            if (ReferenceEquals(first, second))
                return true;

            // If they're not both null, but the first one is,
            // we know they can't be equal.
            if (ReferenceEquals(first, null))
                return false;

            // We know the first is not null, so the rest can safely pass through
            // our existing equality check.
            return first.Equals(second);
        }

        public static bool operator !=(Frequency first, Frequency second)
            => !(first == second);

        /// <summary>
        /// Returns the hertz value for 
        /// </summary>
        public double Hertz { get; }

        public bool Equals(Frequency other)
            => CompareTo(other) == 0;

        public override bool Equals(object other)
            => Equals(other as Frequency);

        public override int GetHashCode()
            => Hertz.GetHashCode();

        public int CompareTo(Frequency other)
        {
            // Any initialized value is always greater than null.
            // Use reference equals so my other operators can reference this.
            if (ReferenceEquals(other, null))
                return 1;

            // I can't just subtract the two values because of the possible
            // loss of decimal precision when casting to an int.
            if (Hertz > other.Hertz)
                return 1;

            // If two frequencies are exactly the same, they're equal.
            if (Hertz == other.Hertz)
                return 0;

            return -1;
        }


        public int CompareTo(object obj)
            => CompareTo(obj as Frequency);
    }

    public class InvalidFrequencyException : Exception
    {
        internal InvalidFrequencyException(double hertz) :
            base($"{hertz} hz is not a valid value for a frequency.")
        { }
    }
}
