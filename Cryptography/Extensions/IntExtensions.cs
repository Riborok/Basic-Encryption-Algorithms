namespace Cryptography.Extensions
{
    public static class IntExtensions
    {
        public static bool IsOdd(this int number) => (number & 1) == 1;
        public static bool IsEven(this int number) => (number & 1) == 0;
    }
}