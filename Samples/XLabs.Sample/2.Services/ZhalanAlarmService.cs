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
    public class ZhalanAlarmService
    {
        public async Task<List<ZhalanAlarm>> GetData(string keyValues)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://cloud.tescar.cn/vehicle/") };

            var response = await client.GetAsync(string.IsNullOrEmpty(keyValues) ? "gettboxxczhalanalarmdata?isspec=1" : "gettboxxczhalanalarmdata?isspec=1&keyValues=" + keyValues);
            var itemListJson = response.Content.ReadAsStringAsync().Result;
            var fRows = JsonConvert.DeserializeObject<FormatRows>(itemListJson);
            var result = JsonConvert.DeserializeObject<List<ZhalanAlarm>>(fRows.rows.ToString());
            return result;
        }

    }
}
