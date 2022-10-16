using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;

public static class SessionExtensions
{
    public static void SetObjectAsJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObjectFromJson<T>(this ISession session, string key)
    {
        var value = session.GetString(key);

        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
    }

    public static void SetObject(this ISession session, string key, object value)
    {
       
        var str = JsonConvert.SerializeObject(value);
        session.SetString(key, str);

        //session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static T GetObject<T>(this ISession session, string key)
    {
        
       var value = session.GetString(key);

        return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        //session.SetString(key, JsonConvert.SerializeObject(value));
    }
}