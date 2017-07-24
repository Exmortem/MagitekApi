using System.ComponentModel;

namespace MagitekApi.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] GetByteArray<T>(this T thing)
        {
            var obj = TypeDescriptor.GetConverter(thing.GetType());
            return (byte[])obj.ConvertTo(thing, typeof(byte[]));
        }
    }
}
