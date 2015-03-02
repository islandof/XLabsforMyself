using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using XLabs.Sample.Model;

namespace XLabs.Sample.Services
{
    public class SijiService
    {
        public async Task<List<Siji>> GetData(string keyValues)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://cloud.tescar.cn/vehicle/") };

            var response = await client.GetAsync(string.IsNullOrEmpty(keyValues) ? "GetSijiData?isspec=1" : "GetSijiData?isspec=1&keyValues=" + keyValues);
            var itemListJson = response.Content.ReadAsStringAsync().Result;
            var fRows = JsonConvert.DeserializeObject<FormatRows>(itemListJson);
            var result = JsonConvert.DeserializeObject<List<Siji>>(fRows.rows.ToString());
            return result;
        }

    }
}
