using System;
using System.IO;
using System.Text;

namespace XLabs.Serialization
{
    public static class StreamSerializerExtensions
    {
        public static T DeserializeFromString<T>(this IStreamSerializer serializer, string value, Encoding encoding = null)
        {
            //var encoder = encoding ?? Encoding.UTF8;

            //var bytes = encoder.GetBytes(value);
            var bytes = Convert.FromBase64String(value);
            using (var stream = new MemoryStream(bytes))
            {
                return serializer.Deserialize<T>(stream);
            }
        }

        public static object DeserializeFromString(this IStreamSerializer serializer, string value, Type type, Encoding encoding = null)
        {
            //var encoder = encoding ?? Encoding.UTF8;

            //var bytes = encoder.GetBytes(value);
            var bytes = Convert.FromBase64String(value);
            using (var stream = new MemoryStream(bytes))
            {
                return serializer.Deserialize(stream, type);
            }
        }

        public static string SerializeToString<T>(this IStreamSerializer serializer, T obj, Encoding encoding = null)
        {
            using (var stream = new MemoryStream())
            {
                serializer.Serialize<T>(obj, stream);
                stream.Position = 0;
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);

                if (encoding == null)
                {
                    return Convert.ToBase64String(bytes);
                }
                else
                {
                    return encoding.GetString(bytes, 0, bytes.Length);
                }
            }
        }

        public static T DeserializeFromBytes<T>(this IStreamSerializer serializer, byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                return serializer.Deserialize<T>(stream);
            }
        }

        public static object DeserializeFromBytes(this IStreamSerializer serializer, byte[] data, Type type)
        {
            using (var stream = new MemoryStream(data))
            {
                return serializer.Deserialize(stream, type);
            }
        }

        public static byte[] GetSerializedBytes(this IStreamSerializer serializer, object obj)
        {
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(obj, stream);
                return stream.ToArray();
            }
        }
    }
}
