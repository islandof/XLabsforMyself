using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using XLabs.Sample.Model;

namespace XLabs.Sample.Services
{
    public class QicheService
    {
        public async Task<List<Qiche>> GetData(string keyValues)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://cloud.tescar.cn/vehicle/") };

            var response = await client.GetAsync(string.IsNullOrEmpty(keyValues) ? "GetQicheData?isspec=1" : "GetQicheData?isspec=1&chepaino=" + keyValues);
            var itemListJson = response.Content.ReadAsStringAsync().Result;
            var fRows = JsonConvert.DeserializeObject<FormatRows>(itemListJson);
            var result = JsonConvert.DeserializeObject<List<Qiche>>(fRows.rows.ToString());
            return result;
        }

    }
}
