using System.Collections.Generic;
using MessagePack;

[MessagePackObject]
public class ProtoDictionary
{
    [Key(0)]
    public Dictionary<KeyType, Data> Datas;
}
