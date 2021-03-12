using System;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace AmazonApplication.Infrastructure
{
    //This is going to convert the cart object into a Json text file, and then back because we can't store Carts in a session
    public static class SessionExtensions
    {
        public static void SetJson (this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T> (this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}
