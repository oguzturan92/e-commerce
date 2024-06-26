using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebUI.Infrastructure
{
    public static class SessionExtentions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var data = session.GetString(key);

            if (data == null)
            {
                return default(T);
            } else
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }
    }
}