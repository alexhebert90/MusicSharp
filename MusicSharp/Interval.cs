namespace MusicSharp
{
    /// <summary>
    /// Represents an interval, or relation, between two musical notes or pitches.
    /// </summary>
    public class Interval
    {
        #region Constants

        /// <summary>
        /// Constant to denote the unchanging value of the number of cents that constitute an octave shift.
        /// </summary>
        private const int CentsPerOctave = 1200;

        #endregion Constants

        #region Private Constructors

        /// <summary>
        /// The main entry point for all interval instances.
        /// Kept private until I have a better idea of different contexts this should be created in.
        /// </summary>
        /// <param name="cents"></param>
        private Interval(int cents)
        {
            // Note: Intentionally not doing range or value checking here.
            // Negative, 0, and positive values are all value arguments for a cent value.
            Cents = cents;
        }

        #endregion Private Constructors

        #region Public Creation

        /// <summary>
        /// Creates an interval 
        /// </summary>
        /// <param name="cents"></param>
        /// <returns></returns>
        public static Interval FromCents(int cents)
            => new Interval(cents: cents);


        #endregion Public Creation

        #region Public Properties

        /// This is planned to be the main value that represents the interval.
        /// Any other future units should be derived from this one.
        /// Readonly for presumed immutability.

        /// <summary>
        /// Returns the cent value of the current interval.
        /// </summary>
        public int Cents { get; }

        #endregion Public Properties
    }
}
