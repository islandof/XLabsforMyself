using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XLabs.Sample.Model
{
    public class FormatRows
    {
        public object rows { get; set; }
        public object Data { get; set; }
        public int total { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(
                this, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, });
        }
    }
}
