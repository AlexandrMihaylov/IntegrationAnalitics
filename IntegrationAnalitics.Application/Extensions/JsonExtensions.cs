using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAnalitics.Application.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
        public static string ToJsonArray<T>(this List<T> obj) => JsonConvert.SerializeObject(obj);
    }
}
