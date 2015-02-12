namespace FizzBuzz.Extensions
{
    public static class IntExtensions
    {
        public static bool IsEvenlyDivisableBy(this int dividend, int divisor)
        {
            return dividend%divisor == 0;
        }
    }
}
