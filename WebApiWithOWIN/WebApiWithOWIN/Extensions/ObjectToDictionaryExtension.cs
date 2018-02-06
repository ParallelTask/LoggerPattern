using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWithOWIN.Extensions
{
    public static class ObjectToDictionaryExtension
    {
        public static IDictionary<string, TValue> ToDictionary<TValue>(this Object data) 
        {
            if (data == null || data is string)
            {
                return null;
            }

            var json = JsonConvert.SerializeObject(data);
            return JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
        }
    }
}