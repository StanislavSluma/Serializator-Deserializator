using System.Text.Json;

namespace Serializator__Deserializator
{
    public class RequestSerializer
    {
        public static string Serialize(string tag, params object[] objs)
        {
            string request = tag;
            if (request[^1] != '?')
                request += '?';
            foreach (object obj in objs)
            {
                request += JsonSerializer.Serialize(obj) + "!";
            }
            return request;
        }

        public static List<string> Deserializer(string request)
        {
            string tag = request.Substring(0, request.IndexOf('?') + 1);
            request = request.Remove(0, request.IndexOf('?') + 1);
            List<string> parse_request = new List<string>() { tag };
            string arg = "";
            bool IsString = false;
            for (int i = 0; i < request.Length; i++)
            {
                if (request[i] == '\"')
                {
                    IsString = !IsString;
                    continue;
                }
                if (request[i] == '!' && !IsString)
                {
                    parse_request.Add(arg);
                    arg = "";
                    continue;
                }
                arg += request[i];
            }
            return parse_request;
        }
    }
}
