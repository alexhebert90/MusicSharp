using Xunit;

namespace MusicSharp.Tests
{
    public class FrequencyTests
    {
        [Theory]
        [InlineData(440.0)]
        public void ImplicitFromDouble(double input)
        {
            Frequency f = input;
            Assert.Equal(f.Hertz, input);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-.001)]
        [InlineData(-9999)]
        public void InvalidFrequencies(double invalidFreq)
        {
            Assert.Throws<InvalidFrequencyException>(() => 
                new Frequency(invalidFreq));
        }

        [Theory]
        [InlineData(300, 700)]
        public void PlusOperator(double freq1, double freq2)
        {
            Frequency f1 = freq1;
            Frequency f2 = freq2;

            // Here is the test point.
            Frequency sum = f1 + f2;

            // Make sure the summed frequency is equal to the actual sum of the two inputs.
            Assert.Equal(sum.Hertz, freq1 + freq2);
        }

        [Theory]
        [InlineData(6565.43, 34.5)]
        public void MinusOperator(double freq1, double freq2)
        {
            Frequency f1 = freq1;
            Frequency f2 = freq2;

            // Here is the test point.
            Frequency sum = f1 - f2;

            // Make sure the summed frequency is equal to the actual sum of the two inputs.
            Assert.Equal(sum.Hertz, freq1 - freq2);
        }
    }
}
