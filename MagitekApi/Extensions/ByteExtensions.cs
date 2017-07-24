using BinaryFormatter;

namespace MagitekApi.Extensions
{
    public static class ByteExtensions
    {
        public static T FromByteArray<T>(this byte[] bytes)
        {
            if (bytes == null)
                return default(T);

            var bf = new BinaryConverter();     
            return  bf.Deserialize<T>(bytes);   
        }
    }
}
