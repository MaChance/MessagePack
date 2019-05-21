using Devcat;
using MessagePack;

[MessagePackObject]
public class ProtoEnumDictionary
{
    [Key(0)]
    public EnumDictionary<KeyType, Data> Datas;
}
