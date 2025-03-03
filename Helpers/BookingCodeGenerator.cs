using System.Text;

namespace BookingSystem.Helpers
{
    public static class BookingCodeGenerator
    {
        private static readonly Random _random = new Random();
        private const string _chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Generate(int length = 6)
        {
            var code = new StringBuilder(length);
            lock (_random)
            {
                for (int i = 0; i < length; i++)
                {
                    code.Append(_chars[_random.Next(_chars.Length)]);
                }
            }
            return code.ToString();
        }
    }
}
