using System.ComponentModel;
using BinaryFormatter;

namespace MagitekApi.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] GetByteArray<T>(this T thing)
        {
            var bc = new BinaryConverter();
            return bc.Serialize(thing);
        }
    }
}
