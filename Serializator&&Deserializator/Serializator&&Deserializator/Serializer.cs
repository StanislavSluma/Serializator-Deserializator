using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Serializator__Deserializator
{
    public class Serializer
    {
        public static string SerializeJson(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T? DeserializeJson<T>(string obj)
        {
            return JsonSerializer.Deserialize<T>(obj);
        }
    }
}
