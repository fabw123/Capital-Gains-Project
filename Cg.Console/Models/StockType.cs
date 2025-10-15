using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cg.Console.Models
{

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StockType
    {
        [EnumMember(Value = "typea")]
        TypeA = 1,

        [EnumMember(Value = "typeb")]
        TypeB = 2,

        [EnumMember(Value = "typec")]
        TypeC = 3
    }
}
