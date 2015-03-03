using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Labs.Sample;
using XLabs.Sample.Model;

namespace XLabs.Sample.ViewModel
{
    public class ZhalanAlarmViewModel : Forms.Mvvm.ViewModel
    {

        public ZhalanAlarmViewModel(ZhalanAlarm item)
        {
            //	_dangerDrive = zhalanAlarm;

            alarmid = item.alarmid;
            tboxid = item.tboxid;
            qicheid = item.qicheid;
            xingchengid = item.xingchengid;
            zhalanid = item.zhalanid;
            zhalantype = item.zhalantype;
            zhalanname = item.zhalanname;
            condition = item.condition;
            if (!string.IsNullOrEmpty(item.dthappen))
            {
                dthappen = item.dthappen.Replace("T", " ");                
            }            
            hasalarm = item.hasalarm;
            if (!string.IsNullOrEmpty(item.createtime))
            {
                createtime = item.createtime.Replace("T", " ");
            }            
            ownercompanyname = item.ownercompanyname;
            chepaino = item.chepaino;
            ownercompanyid = item.ownercompanyid;
            companyid = item.companyid;

        }

        public string alarmid { get; set; }

        public string tboxid { get; set; }

        public string qicheid { get; set; }

        public string xingchengid { get; set; }

        public string zhalanid { get; set; }

        public string zhalantype { get; set; }

        public string zhalanname { get; set; }

        public string condition { get; set; }

        public string dthappen { get; set; }

        public string hasalarm { get; set; }

        public string createtime { get; set; }

        public string chepaino { get; set; }

        public string ownercompanyid { get; set; }

        public string ownercompanyname { get; set; }

        public string companyid { get; set; }
    }
}
