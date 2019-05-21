#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace MessagePack.Resolvers
{
    using System;
    using MessagePack;

    public class GeneratedResolver : global::MessagePack.IFormatterResolver
    {
        public static readonly global::MessagePack.IFormatterResolver Instance = new GeneratedResolver();

        GeneratedResolver()
        {

        }

        public global::MessagePack.Formatters.IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        static class FormatterCache<T>
        {
            public static readonly global::MessagePack.Formatters.IMessagePackFormatter<T> formatter;

            static FormatterCache()
            {
                var f = GeneratedResolverGetFormatterHelper.GetFormatter(typeof(T));
                if (f != null)
                {
                    formatter = (global::MessagePack.Formatters.IMessagePackFormatter<T>)f;
                }
            }
        }
    }

    internal static class GeneratedResolverGetFormatterHelper
    {
        static readonly global::System.Collections.Generic.Dictionary<Type, int> lookup;

        static GeneratedResolverGetFormatterHelper()
        {
            lookup = new global::System.Collections.Generic.Dictionary<Type, int>(5)
            {
                {typeof(global::System.Collections.Generic.Dictionary<global::KeyType, global::Data>), 0 },
                {typeof(global::KeyType), 1 },
                {typeof(global::Data), 2 },
                {typeof(global::ProtoDictionary), 3 },
                {typeof(global::ProtoEnumDictionary), 4 },
            };
        }

        internal static object GetFormatter(Type t)
        {
            int key;
            if (!lookup.TryGetValue(t, out key)) return null;

            switch (key)
            {
                case 0: return new global::MessagePack.Formatters.DictionaryFormatter<global::KeyType, global::Data>();
                case 1: return new MessagePack.Formatters.KeyTypeFormatter();
                case 2: return new MessagePack.Formatters.DataFormatter();
                case 3: return new MessagePack.Formatters.ProtoDictionaryFormatter();
                case 4: return new MessagePack.Formatters.ProtoEnumDictionaryFormatter();
                default: return null;
            }
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace MessagePack.Formatters
{
    using System;
    using MessagePack;

    public sealed class KeyTypeFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::KeyType>
    {
        public int Serialize(ref byte[] bytes, int offset, global::KeyType value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            return MessagePackBinary.WriteInt32(ref bytes, offset, (Int32)value);
        }
        
        public global::KeyType Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            return (global::KeyType)MessagePackBinary.ReadInt32(bytes, offset, out readSize);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612


#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

namespace MessagePack.Formatters
{
    using System;
    using MessagePack;


    public sealed class DataFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Data>
    {

        public int Serialize(ref byte[] bytes, int offset, global::Data value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }
            
            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedArrayHeaderUnsafe(ref bytes, offset, 1);
            offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Text, formatterResolver);
            return offset - startOffset;
        }

        public global::Data Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
            offset += readSize;

            var __Text__ = default(string);

            for (int i = 0; i < length; i++)
            {
                var key = i;

                switch (key)
                {
                    case 0:
                        __Text__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::Data();
            ____result.Text = __Text__;
            return ____result;
        }
    }


    public sealed class ProtoDictionaryFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::ProtoDictionary>
    {

        public int Serialize(ref byte[] bytes, int offset, global::ProtoDictionary value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }
            
            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedArrayHeaderUnsafe(ref bytes, offset, 1);
            offset += formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<global::KeyType, global::Data>>().Serialize(ref bytes, offset, value.Datas, formatterResolver);
            return offset - startOffset;
        }

        public global::ProtoDictionary Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
            offset += readSize;

            var __Datas__ = default(global::System.Collections.Generic.Dictionary<global::KeyType, global::Data>);

            for (int i = 0; i < length; i++)
            {
                var key = i;

                switch (key)
                {
                    case 0:
                        __Datas__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<global::KeyType, global::Data>>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::ProtoDictionary();
            ____result.Datas = __Datas__;
            return ____result;
        }
    }


    public sealed class ProtoEnumDictionaryFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::ProtoEnumDictionary>
    {

        public int Serialize(ref byte[] bytes, int offset, global::ProtoEnumDictionary value, global::MessagePack.IFormatterResolver formatterResolver)
        {
            if (value == null)
            {
                return global::MessagePack.MessagePackBinary.WriteNil(ref bytes, offset);
            }
            
            var startOffset = offset;
            offset += global::MessagePack.MessagePackBinary.WriteFixedArrayHeaderUnsafe(ref bytes, offset, 1);
            offset += formatterResolver.GetFormatterWithVerify<global::Devcat.EnumDictionary<global::KeyType, global::Data>>().Serialize(ref bytes, offset, value.Datas, formatterResolver);
            return offset - startOffset;
        }

        public global::ProtoEnumDictionary Deserialize(byte[] bytes, int offset, global::MessagePack.IFormatterResolver formatterResolver, out int readSize)
        {
            if (global::MessagePack.MessagePackBinary.IsNil(bytes, offset))
            {
                readSize = 1;
                return null;
            }

            var startOffset = offset;
            var length = global::MessagePack.MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize);
            offset += readSize;

            var __Datas__ = default(global::Devcat.EnumDictionary<global::KeyType, global::Data>);

            for (int i = 0; i < length; i++)
            {
                var key = i;

                switch (key)
                {
                    case 0:
                        __Datas__ = formatterResolver.GetFormatterWithVerify<global::Devcat.EnumDictionary<global::KeyType, global::Data>>().Deserialize(bytes, offset, formatterResolver, out readSize);
                        break;
                    default:
                        readSize = global::MessagePack.MessagePackBinary.ReadNextBlock(bytes, offset);
                        break;
                }
                offset += readSize;
            }

            readSize = offset - startOffset;

            var ____result = new global::ProtoEnumDictionary();
            ____result.Datas = __Datas__;
            return ____result;
        }
    }

}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
