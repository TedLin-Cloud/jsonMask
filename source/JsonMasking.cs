using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JsonMask
{
    public static class JsonMasking
    {
        public static string MaskFields(this string json, string[] blacklist, string mask)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentNullException("json");
            }

            if (blacklist == null)
            {
                throw new ArgumentNullException("blacklist");
            }

            if (!blacklist.Any())
            {
                return json;
            }

            JToken obj = (JToken)JsonConvert.DeserializeObject(json);
            MaskFieldsFromJToken(obj, blacklist, mask);
            return obj.ToString();
        }
        public static string EncryptFields(this string json, string[] blacklist)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentNullException("json");
            }

            if (blacklist == null)
            {
                throw new ArgumentNullException("blacklist");
            }

            if (!blacklist.Any())
            {
                return json;
            }

            JToken obj = (JToken)JsonConvert.DeserializeObject(json);
            MaskFieldsFromJToken(obj, blacklist, null);
            return obj.ToString();
        }

        private static void MaskFieldsFromJToken(JToken token, string[] blacklist, string mask)
        {
            JContainer jContainer = token as JContainer;
            if (jContainer == null)
            {
                return;
            }

            List<JToken> list = new List<JToken>();
            foreach (JToken item in jContainer.Children())
            {
                JProperty prop = item as JProperty;
                if (prop != null && blacklist.Any((string item2) => Regex.IsMatch(prop.Name, item2, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)))
                {
                    list.Add(item);
                }

                MaskFieldsFromJToken(item, blacklist, mask);
            }

            Maskjson(list, mask);
        }

        private static void Maskjson(List<JToken> jlist, string mask)
        {
            foreach (JProperty item in jlist.Cast<JProperty>())
            {
                if (mask == null)
                    item.Value = Convert.ToBase64String(Encoding.UTF8.GetBytes(item.Value.ToString()));
                else
                    item.Value = mask;
            }
        }

    }
}