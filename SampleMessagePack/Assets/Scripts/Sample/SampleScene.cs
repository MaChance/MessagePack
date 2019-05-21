using Devcat;
using MessagePack;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleScene : MonoBehaviour
{
    public Text Text;

    private byte[] _serializeBytes;

    void Start()
    {
        Text.text = "Serialize 없음";
    }

    public void EnumDictionarySerialize()
    {
        try
        {
            _serializeBytes = MessagePackSerializer.Serialize(new ProtoEnumDictionary()
            {
                Datas = new EnumDictionary<KeyType, Data>()
                {
                    { KeyType.Key1, new Data()
                        {
                            Text = "Key1"
                        }
                    },
                    { KeyType.Key2, new Data()
                        {
                            Text = "Key2"
                        }
                    }
                }
            });

            Text.text = "Serialize 성공";
        }
        catch (Exception e)
        {
            Text.text = e.Message;
            throw new Exception(e.Message);
        }
    }

    public void EnumDictionaryDeserialize()
    {
        if (_serializeBytes == null || _serializeBytes.Length == 0)
        {
            Text.text = "Deserialize 실패\nBytes Is Null";
            return;
        }

        try
        {
            var protoEnumDictionary = MessagePackSerializer.Deserialize<ProtoEnumDictionary>(_serializeBytes);
            Text.text = "Deserialize 성공";
            foreach (var data in protoEnumDictionary.Datas)
            {
                Text.text += $"\nKey:{data.Key}, Value:{data.Value.Text}";
            }
        }
        catch (Exception e)
        {
            Text.text = e.Message;
            throw new Exception(e.Message);
        }
    }

    public void DictionarySerialize()
    {
        try
        {
            _serializeBytes = MessagePackSerializer.Serialize(new ProtoDictionary()
            {
                Datas = new Dictionary<KeyType, Data>()
                {
                    { KeyType.Key1, new Data()
                        {
                            Text = "Key1"
                        }
                    },
                    { KeyType.Key2, new Data()
                        {
                            Text = "Key2"
                        }
                    }
                }
            });

            Text.text = "Serialize 성공";
        }
        catch (Exception e)
        {
            Text.text = e.Message;
            throw new Exception(e.Message);
        }
    }

    public void DictionaryDeserialize()
    {
        if (_serializeBytes == null || _serializeBytes.Length == 0)
        {
            Text.text = "Deserialize 실패\nBytes Is Null";
            return;
        }

        try
        {
            var protoEnumDictionary = MessagePackSerializer.Deserialize<ProtoDictionary>(_serializeBytes);
            Text.text = "Deserialize 성공";
            foreach (var data in protoEnumDictionary.Datas)
            {
                Text.text += $"\nKey:{data.Key}, Value:{data.Value.Text}";
            }
        }
        catch (Exception e)
        {
            Text.text = e.Message;
            throw new Exception(e.Message);
        }
    }
}
