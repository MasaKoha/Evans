using System;
using System.Collections.Generic;
using UnityEngine;

namespace Evans.Core
{
    public static class JsonHelper
    {
        public static List<TParam> GetListFromJson<TParam>(string json) where TParam : class
        {
            var wrapper = JsonUtility.FromJson<Wrapper<TParam>>(json);
            return wrapper.list;
        }

        public static string ConvertIntoJsonUtility(string csvText)
        {
            var json = CSVToJson.Convert(csvText);
            var newJson = "{ \"list\": " + json + "}";
            return newJson;
        }

        [Serializable]
        class Wrapper<TParam>
        {
            public List<TParam> list;
        }
    }
}