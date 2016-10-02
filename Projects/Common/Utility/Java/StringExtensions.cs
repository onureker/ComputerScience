// ReSharper disable InconsistentNaming
namespace Common.Utility.Java
{
    public static class StringExtensions
    {
        public static char[] toCharArray(this string extended)
        {
            return extended.ToCharArray();
        }

        public static int length(this string extended)
        {
            return extended.Length;
        }
    }
}
