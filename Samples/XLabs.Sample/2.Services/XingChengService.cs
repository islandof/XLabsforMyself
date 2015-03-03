using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XLabs.Sample.Model;

namespace XLabs.Sample.Services
{
    public class XingChengService
    {
        public async Task<List<XingCheng>> GetData(string keyValues)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://cloud.tescar.cn/vehicle/") };

            var response = await client.GetAsync(string.IsNullOrEmpty(keyValues) ? "GetMobileCarTraceData?isspec=1" : "GetMobileCarTraceData?isspec=1&tboxid=" + keyValues);
            var itemListJson = response.Content.ReadAsStringAsync().Result;
            var fRows = JsonConvert.DeserializeObject<FormatRows>(itemListJson);
            var result = JsonConvert.DeserializeObject<List<XingCheng>>(fRows.rows.ToString());
            return result;
        }
    }
}
