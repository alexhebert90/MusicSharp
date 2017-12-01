using System;

namespace MusicSharp
{
    /// <summary>
    /// Represents a single musical pitch.
    /// </summary>
    public class Pitch
    {
        /// <summary>
        /// The main entry point for the creation of a pitch.
        /// </summary>
        /// <param name="frequency"></param>
        private Pitch(Frequency frequency)
        {
            Frequency = frequency ?? throw new ArgumentNullException(nameof(frequency));
        }

        /// <summary>
        /// Creates a new pitch from a provided frequency.
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidFrequencyException"></exception>
        public static Pitch FromFrequency(Frequency frequency)
            => new Pitch(frequency);

        /// <summary>
        /// The frequency value of the pitch.
        /// </summary>
        public Frequency Frequency { get; }
    }
}
