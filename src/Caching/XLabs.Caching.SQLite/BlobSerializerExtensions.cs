using System;
using System.Reflection;
using SQLite.Net;
using XLabs.Serialization;

namespace XLabs.Caching.SQLite
{
    public static class BlobSerializerExtensions
    {
        public static IBlobSerializer AsBlobSerializer(this IByteSerializer serializer)
        {
            return new BlobSerializerDelegate(
                serializer.SerializeToBytes,
                (data, type) => serializer.Deserialize(data, type),
                serializer.CanDeserialize);
        }

        private static bool CanDeserialize(this IByteSerializer serializer, Type type)
        {
            return true;
        }
    }
}
