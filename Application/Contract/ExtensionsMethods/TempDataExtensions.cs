﻿

using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Application.Contract.ExtensionsMethods
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object value;
            tempData.TryGetValue(key, out value);
            return value == null ? null : JsonConvert.DeserializeObject<T>((string)value);
        }
    }
}
