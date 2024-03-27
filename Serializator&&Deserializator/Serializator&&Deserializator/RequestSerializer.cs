using System.Text.Json;

namespace Serializator__Deserializator
{
    public class RequestSerializer
    {
        public static string Serialize(string tag, params object[] objs)
        {
            string res = tag;
            if (res[^1] != '?')
                res += '?';
            foreach (object obj in objs)
            {
                res += JsonSerializer.Serialize(obj) + "!";
            }
            return res;
        }

        public static List<string> Deserializer(string qwerty)
        {
            string tag = qwerty.Substring(0, qwerty.IndexOf('?') + 1);
            qwerty = qwerty.Remove(0, qwerty.IndexOf('?') + 1);
            List<string> res = new List<string>() { tag };
            string arg = "";
            bool IsString = false;
            for (int i = 0; i < qwerty.Length; i++)
            {
                if (qwerty[i] == '\"')
                {
                    IsString = !IsString;
                    continue;
                }
                if (qwerty[i] == '!' && !IsString)
                {
                    res.Add(arg);
                    arg = "";
                    continue;
                }
                arg += qwerty[i];
            }
            return res;
        }
    }
}
